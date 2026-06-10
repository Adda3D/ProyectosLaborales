import argparse
from pathlib import Path
import json
from collections import Counter

from google.protobuf.json_format import MessageToDict

from actas.config import load_settings
from actas.gcs_io import upload_file
from actas.stt_v1 import long_running_recognize_gcs


def print_diarized_preview(response):
    """Imprime vista rápida con Persona N y conteo de palabras por hablante."""
    if not response.results:
        print("La respuesta no contiene 'results'.")
        return

    # Caso 1: separación por canal (cuando enable_separate_recognition_per_channel=True)
    # En este caso, cada result suele corresponder a un canal.
    # Detectamos por la presencia de channel_tag en las palabras.
    has_channel_tag = False
    for r in response.results:
        if r.alternatives and r.alternatives[0].words:
            if any(getattr(w, "channel_tag", 0) for w in r.alternatives[0].words):
                has_channel_tag = True
                break

    if has_channel_tag:
        print("\n--- Transcripción por canal ---")
        for i, r in enumerate(response.results, start=1):
            if not r.alternatives:
                continue
            alt = r.alternatives[0]
            canal = alt.words[0].channel_tag if alt.words else i
            print(f"\n[Canal {canal}]")
            print(alt.transcript.strip())
        print("-------------------------------------")
        return

    # Caso 2: diarización (speaker_tag en words)
    diar_result = response.results[-1]  # suele traer diarización consolidada
    if not diar_result.alternatives or not diar_result.alternatives[0].words:
        print("No hay palabras con diarización en el último resultado.")
        return

    words = diar_result.alternatives[0].words

    # Conteo de palabras por hablante
    counts = Counter([w.speaker_tag for w in words if w.speaker_tag])
    print("\nConteo de palabras por hablante:", dict(counts))

    print("\n--- Transcripción (con hablantes) ---")
    last_speaker = None
    for w in words:
        tag = w.speaker_tag or 0
        if tag != last_speaker:
            # salto de línea y etiqueta
            print(f"\nPersona {tag}: ", end="")
            last_speaker = tag
        print(w.word, end=" ")
    print("\n-------------------------------------")


def main():
    st = load_settings()
    ap = argparse.ArgumentParser()
    ap.add_argument("--file", required=True, help="Ruta local del .wav")
    ap.add_argument("--name", required=False, help="Nombre base (sin extensión)")
    ap.add_argument("--channels", type=int, default=1, help="Canales del audio (1=mono, 2=estéreo)")
    ap.add_argument("--separate-per-channel", action="store_true",
                    help="Si tu WAV es estéreo y cada persona está en un canal distinto.")
    ap.add_argument("--model", default="video", help='Modelo v1: "video", "default" o "phone_call"')
    ap.add_argument("--min-speakers", type=int, default=2, help="Mínimo de hablantes (diarización)")
    ap.add_argument("--max-speakers", type=int, default=2, help="Máximo de hablantes (diarización)")
    args = ap.parse_args()

    src = Path(args.file).expanduser().resolve()
    if not src.is_file():
        raise SystemExit(f"No existe archivo: {src}")

    base = (args.name or src.stem).replace(" ", "_")
    in_object = f"in/{base}.wav"
    gcs_uri = upload_file(str(src), st.bucket, in_object)
    print(f"Archivo subido a: {gcs_uri}")

    # Lanzar transcripción (v1) con la estrategia elegida
    response = long_running_recognize_gcs(
        gcs_uri=gcs_uri,
        language_code=st.lang,       # SPEECH_LANG de tu .env (p.ej., es-ES)
        enable_punct=True,
        min_speakers=args.min_speakers,
        max_speakers=args.max_speakers,
        model=args.model,
        audio_channel_count=args.channels if args.channels > 1 else None,
        separate_per_channel=args.separate_per_channel,
    )

    # Guardar el JSON completo
    resp_dict = MessageToDict(response._pb, preserving_proto_field_name=True)
    out_json = src.parent / f"{base}_transcript_v1.json"
    with open(out_json, "w", encoding="utf-8") as f:
        json.dump(resp_dict, f, ensure_ascii=False, indent=2)
    print(f"Respuesta guardada en: {out_json}")

    # Vista rápida
    print_diarized_preview(response)


if __name__ == "__main__":
    main()
