import os
from dataclasses import dataclass
from typing import List

from pyannote.audio import Pipeline
from dotenv import load_dotenv
load_dotenv(override=True)  # <-- carga .env antes de leer variables



@dataclass
class SpeakerSegment:
    start: float  # seconds
    end: float    # seconds
    speaker: str  # e.g., "SPEAKER_00"


def diarize_to_segments(wav_path: str, hf_token: str | None = None) -> List[SpeakerSegment]:
    """
    Corre diarización local (pyannote) y devuelve segmentos (start, end, speaker_id).
    Requiere HUGGINGFACE_TOKEN en entorno o pasado por parámetro.
    """
    token = hf_token or os.getenv("HUGGINGFACE_TOKEN")
    if not token:
        raise RuntimeError("Falta HUGGINGFACE_TOKEN (env o parámetro) para pyannote.")

    # Pipeline estable (CPU ok). Si te pide acceso, acepta los términos del repo en HF.
    pipeline = Pipeline.from_pretrained("pyannote/speaker-diarization-3.1", use_auth_token=token)

    # Inferencia
    diarization = pipeline(wav_path)

    segs: List[SpeakerSegment] = []
    # diarization: iterable con turnos (segment, speaker)
    for turn, _, speaker in diarization.itertracks(yield_label=True):
        segs.append(SpeakerSegment(start=turn.start, end=turn.end, speaker=speaker))
    # Ordenamos por inicio
    segs.sort(key=lambda s: s.start)
    return segs
