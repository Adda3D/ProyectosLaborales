#7106634667: "Angelica"
import telebot
import gspread
import os
from googleapiclient.discovery import build
from googleapiclient.http import MediaFileUpload
from google.oauth2.service_account import Credentials
from datetime import datetime
import requests

N8N_WEBHOOK_URL = os.getenv("N8N_WEBHOOK_URL", "http://localhost:5678/webhook-test/bot-logic")
SHARED_SECRET = os.getenv("N8N_SHARED_SECRET", "")  # opcional
TOKEN = os.getenv("TELEGRAM_BOT_TOKEN", "")
bot = telebot.TeleBot(TOKEN)

USUARIOS_AUTORIZADOS = {
    7106634667: "Angelica",
    8446180879: "Daniel",
    8389697710: "Bianey",
}

DRIVE_FOLDER_ID = "12is4T3O4b3CqVr1AkehaclDccBayRGGl"

CRED_FILE = "credentials.json"
NOMBRE_ARCHIVO_SHEETS = "Registro_Tramites_DobleO"
SCOPES = [
    "https://www.googleapis.com/auth/spreadsheets",
    "https://www.googleapis.com/auth/drive"
]
credentials = Credentials.from_service_account_file(CRED_FILE, scopes=SCOPES)
gc = gspread.authorize(credentials)
sh = gc.open(NOMBRE_ARCHIVO_SHEETS)
worksheet = sh.worksheet("Seguimiento_Tramites")
service = build('drive', 'v3', credentials=credentials)

@bot.message_handler(commands=["Registrar"])
def registrar_inicio(message):
    if message.from_user.id in USUARIOS_AUTORIZADOS:
        bot.user_step = {}
        bot.user_step[message.from_user.id] = {}
        markup = telebot.types.ReplyKeyboardMarkup(one_time_keyboard=True, resize_keyboard=True)
        markup.add("Sí", "No")
        msg = bot.send_message(message.chat.id, "¿Registrar con la fecha de hoy? (Sí/No)", reply_markup=markup)
        bot.register_next_step_handler(msg, registrar_fecha, bot.user_step[message.from_user.id])
    else:
        bot.send_message(message.chat.id, "Numero no autorizadooo")

def registrar_fecha(message, datos):
    respuesta = message.text.strip().lower()
    if respuesta == "sí" or respuesta == "si":
        datos['Fecha'] = datetime.now().strftime('%d/%m/%y')
        return registrar_tramite(message, datos)
    elif respuesta == "no":
        msg = bot.send_message(message.chat.id, "Por favor, escribe la fecha en formato dd/mm/aa:")
        bot.register_next_step_handler(msg, registrar_fecha_manual, datos)
    else:
        msg = bot.send_message(message.chat.id, "Por favor, responde 'Sí' o 'No'")
        bot.register_next_step_handler(msg, registrar_fecha, datos)

def registrar_fecha_manual(message, datos):
    fecha = message.text.strip()
    datos['Fecha'] = fecha
    registrar_tramite(message, datos)

def registrar_tramite(message, datos):
    markup = telebot.types.ReplyKeyboardMarkup(one_time_keyboard=True, resize_keyboard=True)
    markup.add("Inicio", "Seguimiento", "Finalizacion")
    msg = bot.send_message(message.chat.id, "¿Qué tipo de trámite es?", reply_markup=markup)
    bot.register_next_step_handler(msg, registrar_tipo_tramite, datos)

def registrar_tipo_tramite(message, datos):
    tipo = message.text.strip().capitalize()
    if tipo not in ["Inicio", "Seguimiento", "Finalizacion"]:
        msg = bot.send_message(message.chat.id, "Elige una opción válida: Inicio, Seguimiento, Finalizacion")
        bot.register_next_step_handler(msg, registrar_tipo_tramite, datos)
        return
    datos['Informacion_Registrar'] = tipo
    pedir_placa(message, datos)

def pedir_placa(message, datos):
    msg = bot.send_message(message.chat.id, "Por favor, escribe la placa:")
    bot.register_next_step_handler(msg, registrar_placa, datos)

def registrar_placa(message, datos):
    placa = message.text.strip().upper()
    datos['PlacaC'] = placa
    msg = bot.send_message(message.chat.id, "Ahora escribe una descripción para el trámite:")
    bot.register_next_step_handler(msg, registrar_descripcion, datos)

def registrar_descripcion(message, datos):
    descripcion = message.text.strip()
    datos['Descripcion'] = descripcion
    markup = telebot.types.ReplyKeyboardMarkup(one_time_keyboard=True, resize_keyboard=True)
    markup.add("Sí", "No")
    msg = bot.send_message(message.chat.id, "¿Quieres añadir fotografías al trámite?", reply_markup=markup)
    bot.register_next_step_handler(msg, preguntar_fotos_drive, datos)

def preguntar_fotos_drive(message, datos):
    respuesta = message.text.strip().lower()
    if respuesta == "sí" or respuesta == "si":
        datos['Soporte_Tramite'] = []
        msg = bot.send_message(message.chat.id, "Envíame las fotos, por cada una escribeme 'Listo').")
        bot.register_next_step_handler(msg, recibir_fotos_drive, datos)
    else:
        guardar_registro_drive(message, datos)

def recibir_fotos_drive(message, datos):
    if message.content_type == 'photo':
        file_id = message.photo[-1].file_id
        file_info = bot.get_file(file_id)
        file_path = file_info.file_path
        url = f'https://api.telegram.org/file/bot{TOKEN}/{file_path}'
        response = requests.get(url)
        local_filename = f"temp_{file_id}.jpg"
        with open(local_filename, 'wb') as f:
            f.write(response.content)
        # Subir a Drive y obtener el enlace
        link = subir_a_drive(local_filename, f"{datos['PlacaC']}_{file_id}.jpg")
        datos['Soporte_Tramite'].append(link)
        os.remove(local_filename)
        msg = bot.send_message(message.chat.id, "Foto recibida y guardada en Drive. Envía otra o escribe 'Listo' si terminaste.")
        bot.register_next_step_handler(msg, recibir_fotos_drive, datos)
    elif message.text and message.text.lower() == "listo":
        guardar_registro_drive(message, datos)
    else:
        msg = bot.send_message(message.chat.id, "Por favor, envía una foto o escribe 'Listo' si ya terminaste.")
        bot.register_next_step_handler(msg, recibir_fotos_drive, datos)

def subir_a_drive(filepath, filename):
    file_metadata = {
        'name': filename,
        'parents': [DRIVE_FOLDER_ID]
    }
    media = MediaFileUpload(filepath, mimetype='image/jpeg')
    file = service.files().create(body=file_metadata, media_body=media, fields='id').execute()
    file_id = file.get('id')
    service.permissions().create(fileId=file_id, body={'type': 'anyone', 'role': 'reader'}).execute()
    link = f'https://drive.google.com/uc?id={file_id}'
    return link

def guardar_registro_drive(message, datos):
    fotos_str = ",".join(datos.get('Soporte_Tramite', []))
    worksheet.append_row([
        datos['Fecha'],
        datos['Informacion_Registrar'],
        datos['PlacaC'],
        datos['Descripcion'],
        fotos_str
    ])
    bot.send_message(message.chat.id, "¡Registro exitoso! ✅")

#########################################
def enviar_a_n8n(payload: dict) -> dict:
    try:
        headers = {"X-Bridge-Secret": SHARED_SECRET}
        r = requests.post(N8N_WEBHOOK_URL, json=payload, headers=headers, timeout=15)
        r.raise_for_status()
        data = r.json() if r.headers.get("content-type","").startswith("application/json") else {}
        return data or {"reply_text": "No recibí respuesta válida del orquestador."}
    except Exception as e:
        return {"reply_text": f"Error al contactar orquestador: {e}"}

def autorizado(user_id: int) -> bool:
    return user_id in USUARIOS_AUTORIZADOS

@bot.message_handler(content_types=['text'])
def manejar_texto(message):
    user_id = message.from_user.id
    chat_id = message.chat.id
    text = message.text.strip()

    if not autorizado(user_id):
        bot.send_message(chat_id, "Número no autorizado.")
        return

    # Construye el payload que n8n espera
    payload = {
        "chat_id": chat_id,
        "user_id": user_id,
        "username": message.from_user.username,
        "name": USUARIOS_AUTORIZADOS.get(user_id, ""),
        "text": text
    }

    # Envía a n8n y responde con lo que devuelva
    resp = enviar_a_n8n(payload)
    reply = resp.get("reply_text", "Sin respuesta del orquestador.")
    bot.send_message(chat_id, reply)

# (Opcional) Fotos → por ahora solo avisamos. Luego puedes enrutar a n8n también.
@bot.message_handler(content_types=['photo'])
def manejar_foto(message):
    user_id = message.from_user.id
    chat_id = message.chat.id
    if not autorizado(user_id):
        bot.send_message(chat_id, "Número no autorizado.")
        return
    bot.send_message(chat_id, "Por ahora solo estoy procesando texto. Envía /consultar PLACA.")

bot.polling()


@bot.message_handler(commands=["Consultar"])
def consultar(message):
    if message.from_user.id in USUARIOS_AUTORIZADOS:
        msg = bot.send_message(message.chat.id, "Por favor, escribe el número de placa que quieres consultar:")
        bot.register_next_step_handler(msg, consultar_placa)
    else:
        bot.send_message(message.chat.id, "Numero no autorizadooo")

def consultar_placa(message):
    if message.from_user.id not in USUARIOS_AUTORIZADOS:
        bot.send_message(message.chat.id, "Numero no autorizadooo")
        return
    placa = message.text.strip()
    descripcion = buscar_placa(placa)
    if descripcion:
        bot.send_message(message.chat.id, f"Descripción de la placa {placa.upper()}:\n{descripcion}")
    else:
        bot.send_message(message.chat.id, f"No encontré información para la placa {placa.upper()}")

# --- Función para buscar la placa en la hoja ---
def buscar_placa(placa_buscar):
    data = worksheet.get_all_records()
    for fila in data:
        # "Placa" debe coincidir con el encabezado de la columna O de tu hoja
        if str(fila.get("PlacaC", "")).strip().upper() == placa_buscar.strip().upper():
            # "Descripcion" debe coincidir con el encabezado de la columna P de tu hoja
            return fila.get("Descripcion", "Sin descripción")
    return None

@bot.message_handler(func=lambda m: m.text and m.text.lower() in ["hola", "hello", "buenas", "buenos días"])
def saludar(message):
    if message.from_user.id in USUARIOS_AUTORIZADOS:
        nombre = USUARIOS_AUTORIZADOS[message.from_user.id]
        bot.send_message(
            message.chat.id,
            f"¡Hola {nombre}! Puedes usar:\n/Consultar - para consultar una placa\n/Registrar - para registrar información"
        )
    else:
        bot.send_message(message.chat.id, "Numero no autorizadooo")

bot.polling()
