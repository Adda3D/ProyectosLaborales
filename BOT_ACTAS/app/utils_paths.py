# app/utils_paths.py
import os
import sys
from pathlib import Path

def app_root() -> Path:
    """
    Directorio base desde donde leer recursos empaquetados con PyInstaller.
    En 'frozen' usa sys._MEIPASS; en desarrollo usa CWD.
    """
    return Path(getattr(sys, "_MEIPASS", Path.cwd()))

def resource_path(rel: str | os.PathLike) -> Path:
    """Construye ruta absoluta a un recurso empacado (relativo al bundle)."""
    return app_root() / Path(rel)
