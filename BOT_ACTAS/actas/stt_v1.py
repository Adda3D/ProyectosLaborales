from typing import Optional
from google.cloud import speech_v1p1beta1 as speech

def long_running_recognize_gcs(
    gcs_uri: str,
    language_code: str = "es-ES",
    enable_punct: bool = True,
    min_speakers: int = 2,
    max_speakers: int = 2,      # forzamos 2
    model: str = "default",     # <-- aquí el cambio clave
    audio_channel_count: Optional[int] = None,
    separate_per_channel: bool = False,
):
    client = speech.SpeechClient()

    config_kwargs = dict(
        language_code=language_code,
        enable_automatic_punctuation=enable_punct,
        model=model,
    )

    if audio_channel_count and audio_channel_count > 1 and separate_per_channel:
        config = speech.RecognitionConfig(
            **config_kwargs,
            audio_channel_count=audio_channel_count,
            enable_separate_recognition_per_channel=True,
        )
    else:
        diarization_config = speech.SpeakerDiarizationConfig(
            enable_speaker_diarization=True,
            min_speaker_count=min_speakers,
            max_speaker_count=max_speakers,
        )
        config = speech.RecognitionConfig(
            **config_kwargs,
            audio_channel_count=audio_channel_count,
            enable_separate_recognition_per_channel=True,
            enable_word_time_offsets=True,  # <-- añade esto
        )


    audio = speech.RecognitionAudio(uri=gcs_uri)
    print("Esperando a que termine la operación...")
    response = speech.SpeechClient().long_running_recognize(config=config, audio=audio).result(timeout=600)
    return response
