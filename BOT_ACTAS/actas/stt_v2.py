from google.cloud.speech_v2 import SpeechClient
from google.cloud.speech_v2.types import cloud_speech

def start_batch_recognize_gcs(
    project_id: str,
    location: str,
    recognizer_id: str,
    audio_uri: str,
    gcs_output_prefix: str,
    lang: str = "es-CO",
    model = "latest_long",
    min_speakers: int = 2,
    max_speakers: int = 6,
    enable_punct: bool = True,
):
    """
    Lanza BatchRecognize (v2) con diarización y salida en GCS (prefijo de carpeta).
    Devuelve el nombre de la operación LRO.
    """
    client = SpeechClient()

    # Config de reconocimiento (v2)
    features = cloud_speech.RecognitionFeatures(
        enable_automatic_punctuation=enable_punct,
        diarization_config=cloud_speech.SpeakerDiarizationConfig(
            min_speaker_count=min_speakers,
            max_speaker_count=max_speakers,
        ),
    )

    config = cloud_speech.RecognitionConfig(
        auto_decoding_config=cloud_speech.AutoDetectDecodingConfig(),
        language_codes=[lang],
        model=model,
        features=features,
    )

    files = [cloud_speech.BatchRecognizeFileMetadata(uri=audio_uri)]

    output = cloud_speech.RecognitionOutputConfig(
        gcs_output_config=cloud_speech.GcsOutputConfig(uri=gcs_output_prefix)
    )

    recognizer = f"projects/{project_id}/locations/{location}/recognizers/{recognizer_id}"
    op = client.batch_recognize(
        request=cloud_speech.BatchRecognizeRequest(
            recognizer=recognizer,
            config=config,
            files=files,
            recognition_output_config=output,
        )
    )
    # no bloqueamos; devolvemos el nombre de la operación
    return op.operation.name


# --- NUEVO: versión mínima, sin modelo ni features ---
# actas/stt_v2.py (versión mínima ajustada)
from google.cloud.speech_v2 import SpeechClient
from google.cloud.speech_v2.types import cloud_speech

def start_batch_recognize_minimal(
    project_id: str,
    location: str,           # "global"
    recognizer_id: str,      # "_"
    audio_uri: str,
    gcs_output_prefix: str,
    lang: str,               # p.ej. "es-ES"
    model: str = "latest_long",  # ✅ modelo requerido en v2
):
    client = SpeechClient()

    config = cloud_speech.RecognitionConfig(
        auto_decoding_config=cloud_speech.AutoDetectDecodingConfig(),
        language_codes=[lang],
        model=model,  # ✅ ahora sí enviamos modelo
    )

    files = [cloud_speech.BatchRecognizeFileMetadata(uri=audio_uri)]

    output = cloud_speech.RecognitionOutputConfig(
        gcs_output_config=cloud_speech.GcsOutputConfig(uri=gcs_output_prefix)
    )

    recognizer = f"projects/{project_id}/locations/{location}/recognizers/{recognizer_id}"
    op = client.batch_recognize(
        request=cloud_speech.BatchRecognizeRequest(
            recognizer=recognizer,
            config=config,
            files=files,
            recognition_output_config=output,
        )
    )
    return op.operation.name
