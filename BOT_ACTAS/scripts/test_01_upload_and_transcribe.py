import argparse, os
from pathlib import Path
from actas.config import load_settings
from actas.gcs_io import upload_file, list_objects
from actas.stt_v2 import start_batch_recognize_gcs

def main():
    st = load_settings()
    ap = argparse.ArgumentParser()
    ap.add_argument("--file", required=True, help="Ruta local del .wav (10s para prueba)")
    ap.add_argument("--name", required=False, help="Nombre base (opcional)")
    args = ap.parse_args()

    src = Path(args.file).expanduser().resolve()
    if not src.is_file():
        raise SystemExit(f"No existe archivo: {src}")

    base = args.name or src.stem
    in_object = f"in/{base}.wav"
    out_prefix = f"gs://{st.bucket}/out/transcripts/{base}/"

    # 1) subir a GCS (como haces en n8n)
    gcs_uri = upload_file(str(src), st.bucket, in_object)
    print("Subido:", gcs_uri)

    # 2) disparar STT v2 con diarización + salida en GCS
    op_name = start_batch_recognize_gcs(
        project_id=st.project_id,
        location=st.location,
        recognizer_id=st.recognizer_id,  # "_" para recognizer implícito
        audio_uri=gcs_uri,
        gcs_output_prefix=out_prefix,
        lang=st.lang,
        min_speakers=2,
        max_speakers=10,
    )
    print("Operación lanzada:", op_name)
    print("El resultado se escribirá en:", out_prefix)
    print("Tip: para revisar después, lista objetos bajo ese prefijo.")

    # 3) ejemplo rápido de listado (no bloqueante)
    print("Objetos actuales en out/transcripts/<base>/ (puede estar vacío todavía):")
    try:
        names = list_objects(st.bucket, f"out/transcripts/{base}/")
        for n in names:
            print(" -", n)
    except Exception as e:
        print("No se pudo listar aún:", e)

if __name__ == "__main__":
    main()
