# actas/config.py
import os
from dataclasses import dataclass

@dataclass
class Settings:
    project_id: str
    location: str
    bucket: str
    recognizer_id: str
    lang: str

def load_settings() -> Settings:
    # Fuerza a que .env reemplace variables del entorno (override=True)
    try:
        from dotenv import load_dotenv
        load_dotenv(override=True)
    except Exception:
        pass

    project_id = os.getenv("GOOGLE_CLOUD_PROJECT") or ""
    location = os.getenv("LOCATION", "global")
    bucket = os.getenv("BUCKET", "actas-audio")
    recognizer_id = os.getenv("RECOGNIZER_ID", "_")
    # ✅ lee tu nueva variable, con fallback a es-ES
    lang = os.getenv("SPEECH_LANG", "es-ES")

    if not project_id:
        raise RuntimeError("Falta GOOGLE_CLOUD_PROJECT en variables de entorno")
    if not os.getenv("GOOGLE_APPLICATION_CREDENTIALS"):
        raise RuntimeError("Falta GOOGLE_APPLICATION_CREDENTIALS (ruta al .json)")

    return Settings(project_id, location, bucket, recognizer_id, lang)
