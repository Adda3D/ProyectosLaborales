# scripts/transcribe_whisper_local.py
import argparse
import json
from pathlib import Path
import torch
from faster_whisper import WhisperModel

def run_transcribe(audio_path: Path, model_name: str, lang: str, out_json: Path | None) -> int:
    if not audio_path.is_file():
        print(f"[transcribe] No existe archivo de audio: {audio_path}")
        return 2

    print(f"[transcribe] Cargando modelo Whisper '{model_name}' (device={ 'cuda' if torch.cuda.is_available() else 'cpu' })…")
    model = WhisperModel(model_name, device="cuda" if torch.cuda.is_available() else "cpu")

    print(f"[transcribe] Transcribiendo {audio_path.name} (idioma={lang})…")
    segments, info = model.transcribe(str(audio_path), language=lang, word_timestamps=True)

    base = audio_path.with_suffix("")  # quita la extensión
    txt_path = base.with_suffix(".whisper.txt")
    json_path = out_json if out_json else base.with_suffix(".whisper.json")

    results = []
    with open(txt_path, "w", encoding="utf-8") as ftxt:
        for seg in segments:
            line = f"[{seg.start:.2f} → {seg.end:.2f}] {seg.text}"
            ftxt.write(line + "\n")
            results.append({
                "start": seg.start,
                "end": seg.end,
                "text": seg.text,
                "words": [
                    {"start": w.start, "end": w.end, "word": w.word}
                    for w in (seg.words or [])
                ],
            })

    with open(json_path, "w", encoding="utf-8") as fjson:
        json.dump(results, fjson, ensure_ascii=False, indent=2)

    print("[transcribe] OK")
    print("[transcribe] Guardado en:")
    print(" -", txt_path)
    print(" -", json_path)
    return 0

# --- API reutilizable desde la GUI ---
def main(file: str, model: str = "small", lang: str = "es", out_json: str | None = None) -> int:
    audio_path = Path(file).expanduser().resolve()
    out = Path(out_json).expanduser().resolve() if out_json else None
    return run_transcribe(audio_path, model, lang, out)

# --- CLI (puedes seguir ejecutando por consola si quieres) ---
if __name__ == "__main__":
    ap = argparse.ArgumentParser()
    ap.add_argument("--file", required=True, help="Ruta del audio (wav/mp3/mp4)")
    ap.add_argument("--model", default="small", help="Modelo (tiny, base, small, medium, large-v2)")
    ap.add_argument("--lang", default="es", help="Idioma, ej: es o en")
    ap.add_argument("--out", dest="out_json", default=None, help="Ruta JSON de salida (opcional)")
    args = ap.parse_args()
    raise SystemExit(main(args.file, args.model, args.lang, args.out_json))
