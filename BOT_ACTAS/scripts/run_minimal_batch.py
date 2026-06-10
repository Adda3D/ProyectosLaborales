# scripts/run_minimal_batch.py
import argparse
from pathlib import Path

from actas.config import load_settings
from actas.gcs_io import upload_file
from actas.stt_v2 import start_batch_recognize_minimal

def main():
    st = load_settings()  # lee .env
    ap = argparse.ArgumentParser()
    ap.add_argument("--file", required=True, help="Ruta local del .wav")
    ap.add_argument("--name", required=False, help="Nombre base (sin extensión)")
    args = ap.parse_args()

    src = Path(args.file).expanduser().resolve()
    if not src.is_file():
        raise SystemExit(f"No existe archivo: {src}")

    base = (args.name or src.stem).replace(" ", "_")
    in_object = f"in/{base}.wav"
    out_prefix = f"gs://{st.bucket}/out/transcripts/{base}/"

    print("[debug] PROJECT =", st.project_id)
    print("[debug] LOCATION =", st.location)
    print("[debug] BUCKET   =", st.bucket)
    print("[debug] LANG     =", st.lang)
    print(f"[1/2] Subiendo a GCS: {in_object}")

    gcs_uri = upload_file(str(src), st.bucket, in_object)
    print("   →", gcs_uri)

    print(f"[2/2] Lanzando BatchRecognize MINIMAL (solo idioma) → {out_prefix}")
    op_name = start_batch_recognize_minimal(
        project_id=st.project_id,
        location=st.location,          # debería ser "global"
        recognizer_id=st.recognizer_id,# "_"
        audio_uri=gcs_uri,
        gcs_output_prefix=out_prefix,
        lang=st.lang,                  # "es-ES" según tu .env
    )
    print("Operación creada:", op_name)
    print("Salida esperada en:", out_prefix)

if __name__ == "__main__":
    main()
