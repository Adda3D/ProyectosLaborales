import argparse
from pathlib import Path

from actas.config import load_settings
from actas.gcs_io import upload_file, list_objects
from actas.stt_v2 import start_batch_recognize_gcs



def main():
    st = load_settings()  # lee variables de entorno
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

    print(f"[1/2] Subiendo a GCS: {in_object}")
    gcs_uri = upload_file(str(src), st.bucket, in_object)
    print("   →", gcs_uri)

    print(f"[2/2] Lanzando BatchRecognize (v2) con diarización → {out_prefix}")
    op_name = start_batch_recognize_gcs(
        project_id=st.project_id,
        location=st.location,
        recognizer_id=st.recognizer_id,
        audio_uri=gcs_uri,
        gcs_output_prefix=out_prefix,
        lang=st.lang,
        min_speakers=2,
        max_speakers=10,
        enable_punct=True,
    )
    print("Operación creada:", op_name)
    print("El resultado aparecerá en:", out_prefix)

    # Listado no bloqueante (puede estar vacío inmediatamente):
    try:
        names = list_objects(st.bucket, f"out/transcripts/{base}/")
        if names:
            print("Objetos actuales:")
            for n in names:
                print(" -", n)
        else:
            print("(Aún no hay archivos de salida; la operación sigue corriendo en Google).")
    except Exception as e:
        print("No se pudo listar todavía:", e)

if __name__ == "__main__":
    main()
