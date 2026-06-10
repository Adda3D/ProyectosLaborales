# GeneradorActas.spec
entry_script = 'app\\main_app.py'  # <- tu GUI

block_cipher = None

from PyInstaller.utils.hooks import collect_submodules, collect_all

hidden = []
binaries = []
datas = []

# --- paquetes que requieren TODO (código + data + metadata) ---
for pkg in [
    'speechbrain',
    'win10toast',
    'sklearn',
    'scipy',
    'librosa',
    'soundfile',
    'docx',          # python-docx
    'faster_whisper'
]:
    _datas, _binaries, _hidden = collect_all(pkg)
    datas    += _datas
    binaries += _binaries
    hidden   += _hidden

# --- tus datos propios embebidos ---
datas += [
    ('app\\promp.txt', 'app'),
    ('app\\ffmpeg\\ffmpeg.exe', 'app/ffmpeg'),
    ('app\\ffmpeg\\ffprobe.exe', 'app/ffmpeg'),
]

a = Analysis(
    [entry_script],
    pathex=['.', 'app', 'scripts'],
    binaries=binaries,
    datas=datas,
    hiddenimports=hidden,
    hookspath=[],            # no necesitas hooks custom con collect_all
    hooksconfig={},
    runtime_hooks=[],
    excludes=[],
    noarchive=False,
)

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    [],
    exclude_binaries=True,
    name='GeneradorActas',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    console=True,    # ¡SÍ, EN TRUE! -> necesitamos logs
    disable_windowed_traceback=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
    icon=None,
)

coll = COLLECT(
    exe,
    a.binaries,
    a.zipfiles,
    a.datas,
    strip=False,
    upx=True,
    upx_exclude=[],
    name='GeneradorActas',
)
