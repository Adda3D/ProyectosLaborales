# scripts/diarize_speechbrain_merge.py
import argparse
import json
import warnings
from pathlib import Path
import numpy as np
import librosa

warnings.filterwarnings("ignore", category=UserWarning)

def load_audio_mono(path, sr=16000):
    y, sr = librosa.load(path, sr=sr, mono=True)
    return y, sr

def frame_embeddings(y, sr, hop_sec=0.5, win_sec=1.5):
    # Import pesado AQUÍ (no en import global)
    try:
        import torch
        from speechbrain.inference.speaker import EncoderClassifier
    except Exception as e:
        raise RuntimeError(
            "No se pudo cargar 'speechbrain/torch' dentro de diarización. "
            f"Detalle: {e}"
        )

    classifier = EncoderClassifier.from_hparams(source="speechbrain/spkrec-ecapa-voxceleb")
    classifier.eval()

    hop = int(hop_sec * sr)
    win = int(win_sec * sr)
    frames, centers = [], []
    for start in range(0, max(len(y) - win, 1), hop):
        chunk = y[start:start + win]
        if len(chunk) < win:
            pad = np.zeros(win - len(chunk), dtype=np.float32)
            chunk = np.concatenate([chunk.astype(np.float32), pad], axis=0)
        else:
            chunk = chunk.astype(np.float32)

        import torch  # ya está disponible
        wavs = torch.from_numpy(chunk).unsqueeze(0)
        wav_lens = torch.tensor([1.0], dtype=torch.float32)

        with torch.no_grad():
            emb = classifier.encode_batch(wavs, wav_lens).squeeze().cpu().numpy()

        frames.append(emb)
        centers.append((start + win // 2) / sr)

    if len(frames) == 0:
        return np.zeros((0, 192)), np.array([])
    return np.vstack(frames), np.array(centers)

def cluster_speakers(embs, n_spk=2):
    # Import pesado AQUÍ
    try:
        from sklearn.cluster import AgglomerativeClustering
    except Exception as e:
        raise RuntimeError(
            "No se pudo cargar 'sklearn' para clustering. "
            f"Detalle: {e}"
        )

    if len(embs) == 0:
        return np.array([])
    try:
        clus = AgglomerativeClustering(n_clusters=n_spk, metric="cosine", linkage="average")
    except TypeError:
        clus = AgglomerativeClustering(n_clusters=n_spk, affinity="cosine", linkage="average")
    labels = clus.fit_predict(embs)
    return labels

def load_whisper_words(json_path):
    data = json.loads(Path(json_path).read_text(encoding="utf-8"))
    segments = data if isinstance(data, list) else data.get("segments", [])
    words = []
    for seg in segments:
        for w in seg.get("words", []):
            if w.get("start") is None or w.get("end") is None:
                continue
            words.append({
                "word": (w.get("word") or "").strip(),
                "start": float(w["start"]),
                "end": float(w["end"]),
            })
    return words

def assign_speakers_to_words(words, centers, labels):
    assigned = []
    for w in words:
        mid = 0.5 * (w["start"] + w["end"])
        spk = int(labels[int(np.argmin(np.abs(centers - mid)))]) if len(centers) else 0
        assigned.append({"word": w["word"], "speaker": spk})
    return assigned

def render_dialog(assigned, max_line=120):
    lines = []
    cur_spk = None
    cur = ""
    for t in assigned:
        label = f"Persona {t['speaker'] + 1}"
        if label != cur_spk:
            if cur.strip():
                lines.append(cur.strip())
            cur_spk = label
            cur = f"{label}: {t['word']}"
        else:
            nxt = cur + " " + t["word"]
            if len(nxt) > max_line:
                lines.append(cur.strip())
                cur = f"{label}: {t['word']}"
            else:
                cur = nxt
    if cur.strip():
        lines.append(cur.strip())
    return lines

def run_diarize(wav_path: Path, whisper_json: Path, speakers: int, out_spk: Path | None) -> int:
    if not wav_path.is_file():
        print(f"[diarize] No existe WAV: {wav_path}")
        return 2
    if not whisper_json.is_file():
        print(f"[diarize] No existe JSON de Whisper: {whisper_json}")
        return 3

    print("[diarize] Cargando audio…")
    y, sr = load_audio_mono(str(wav_path), sr=16000)
    print("[diarize] Extrayendo embeddings…")
    embs, centers = frame_embeddings(y, sr, hop_sec=0.5, win_sec=1.5)
    print(f"[diarize] Ventanas: {len(centers)}")

    print("[diarize] Clustering…")
    labels = cluster_speakers(embs, n_spk=speakers)

    print("[diarize] Cargando palabras de Whisper…")
    words = load_whisper_words(str(whisper_json))
    if not words:
        print("[diarize] El JSON no trae 'words'. Revisa word_timestamps=True en la transcripción.")
        return 4

    print("[diarize] Asignando hablantes…")
    assigned = assign_speakers_to_words(words, centers, labels)

    out_txt = out_spk if out_spk else whisper_json.with_suffix(".spk.txt")
    out_txt.write_text("\n".join(render_dialog(assigned)), encoding="utf-8")
    print(f"[diarize] OK -> {out_txt}")
    return 0

# --- API reutilizable ---
def main(wav: str, json_path: str, speakers: int = 2, out_spk: str | None = None) -> int:
    wav_path = Path(wav).expanduser().resolve()
    jpath = Path(json_path).expanduser().resolve()
    out = Path(out_spk).expanduser().resolve() if out_spk else None
    return run_diarize(wav_path, jpath, speakers, out)

# --- CLI ---
if __name__ == "__main__":
    ap = argparse.ArgumentParser()
    ap.add_argument("--wav", required=True, help="Ruta al WAV/MP3 local")
    ap.add_argument("--json", required=True, help="JSON de faster-whisper con words+timestamps")
    ap.add_argument("--speakers", type=int, default=2, help="N° de hablantes (2 por defecto)")
    ap.add_argument("--out", dest="out_spk", default=None, help="Ruta de salida .spk.txt (opcional)")
    args = ap.parse_args()
    raise SystemExit(main(args.wav, args.json, args.speakers, args.out_spk))
