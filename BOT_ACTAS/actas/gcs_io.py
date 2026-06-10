from google.cloud import storage
from pathlib import Path

def upload_file(local_path: str, bucket_name: str, object_name: str) -> str:
    """
    Sube un archivo a GCS. Devuelve la URI gs://...
    """
    client = storage.Client()
    bucket = client.bucket(bucket_name)
    blob = bucket.blob(object_name)
    # content_type básico para WAV; ajusta si usas otros formatos
    content_type = "audio/wave" if local_path.lower().endswith(".wav") else None
    blob.upload_from_filename(local_path, content_type=content_type)
    return f"gs://{bucket_name}/{object_name}"

def ensure_prefix_slashless(prefix: str) -> str:
    return prefix.strip("/")

def list_objects(bucket_name: str, prefix: str):
    client = storage.Client()
    bucket = client.bucket(bucket_name)
    return [b.name for b in client.list_blobs(bucket, prefix=ensure_prefix_slashless(prefix))]
