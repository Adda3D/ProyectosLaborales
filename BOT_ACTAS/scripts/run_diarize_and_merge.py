import argparse
import json
from pathlib import Path
from collections import defaultdict

from actas.diarize_local import diarize_to_segments

# Mapear IDs de pyannote ("SPEAKER_00", "SPEAKER_01") -> Persona 1, 2, ...
def build_speaker_map(sorted_speaker_ids):
    persona_map = {}
    for idx, spk in enumerate(sorted_speaker_ids, start=1):
        persona_map[spk] = f"Persona {idx}"
    return persona_map

def midpoint(start_s, end_s):
    return 0.5 * (start_s + end_s)

def load_words_from_v1_json(json_path: Path):
    """
    Lee tu JSON de v1 (MessageToDict) y devuelve lista de palabras con timestamps:
    [{'word': 'Hola', 'start': 0.5, 'end': 0.9}, ...]
    """
    data = json.loads(json_path.read_text(encoding="utf-8"))
    words = []
    results = data.get("results", [])
    if not results:
        return words

    # Usamos el último result (suele consolidar palabras)
    last = results[-1]
    alts = last.get("alternatives", [])
    if not alts:
        return words
    alt0 = alts[0]
    for w in alt0.get("words", []):
        # Tiempos vienen como "1.234s"
        def s2f(s):
            if not s:
                return None
            if s.endswith("s"):
                s = s[:-1]
            try:
                return float(s)
            except:
                return None
        ws = s2f(w.get("startTime"))
        we = s2f(w.get("endTime"))
        if ws is None or we is None:
            # si faltan tiempos, los saltamos
            continue
        words.append({
            "word": w.get("word", ""),
            "start": ws,
            "end": we,
        })
    return words

def assign_speakers(words, segments):
    """
    Para cada palabra, toma el punto medio y busca el segmento de diarización que lo contiene.
    Devuelve lista de (persona_label, word) en orden.
    """
    # Índice lineal simple (lista corta); para audios largos podríamos usar bisect
    assigned = []
    for w in words:
        t = midpoint(w["start"], w["end"])
        spk = None
        for seg in segments:
            if seg.start <= t <= seg.end:
                spk = seg.speaker
                break
        assigned.append({
            "word": w["word"],
            "speaker": spk  # puede ser None si cae en un hueco
        })
    return assigned

def render_paragraphs(assigned_words, persona_map, max_chars=120):
    """
    Renderiza en párrafos por cambios de hablante, con envoltura suave.
    """
    lines = []
    current_speaker = None
    current_line = ""

    def flush():
        nonlocal current_line
        if current_line.strip():
            lines.append(current_line.strip())
        current_line = ""

    for token in assigned_words:
        spk = token["speaker"]
        label = persona_map.get(spk, "Persona ?")
        if label != current_speaker:
            # cambio de parlante → cerrar párrafo anterior y abrir uno nuevo
            flush()
            current_speaker = label
            current_line = f"{label}: {token['word']}"
        else:
            # misma persona; controlar largo
            if len(current_line) + 1 + len(token["word"]) > max_chars:
                lines.append(current_line.strip())
                current_line = f"{label}: {token['word']}"
            else:
                current_line += " " + token["word"]
    flush()
    return lines

def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--wav", required=True, help="Ruta local del WAV original.")
    ap.add_argument("--json", required=True, help="Ruta al JSON de Google v1 (MessageToDict).")
    ap.add_argument("--out", required=False, help="Ruta de salida .txt (opcional).")
    args = ap.parse_args()

    wav_path = Path(args.wav).resolve()
    json_path = Path(args.json).resolve()
    if not wav_path.is_file():
        raise SystemExit(f"No existe WAV: {wav_path}")
    if not json_path.is_file():
        raise SystemExit(f"No existe JSON: {json_path}")

    print("Diarizando localmente con pyannote…")
    segments = diarize_to_segments(str(wav_path))  # lee HUGGINGFACE_TOKEN del entorno
    if not segments:
        raise SystemExit("No se detectaron segmentos de hablantes.")

    # Construir mapa consistente de speakers -> Persona N (orden por primer aparición)
    seen_order = []
    for seg in segments:
        if seg.speaker not in seen_order:
            seen_order.append(seg.speaker)
    persona_map = build_speaker_map(seen_order)

    print("Cargando palabras del JSON de Google v1…")
    words = load_words_from_v1_json(json_path)
    if not words:
        raise SystemExit("No se encontraron palabras con timestamps en el JSON.")

    print("Asignando hablantes a palabras…")
    assigned = assign_speakers(words, segments)

    print("Renderizando diálogo…")
    lines = render_paragraphs(assigned, persona_map)

    out_path = Path(args.out) if args.out else json_path.with_suffix(".txt")
    out_path.write_text("\n".join(lines), encoding="utf-8")
    print(f"Listo: {out_path}")

    # Resumen rápido
    from collections import Counter
    counts = Counter([a["speaker"] for a in assigned if a["speaker"]])
    pretty = {persona_map.get(k, str(k)): v for k, v in counts.items()}
    print("Conteo de tokens por persona:", pretty)


if __name__ == "__main__":
    main()
