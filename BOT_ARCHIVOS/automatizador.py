import tkinter as tk
from tkinter import filedialog, messagebox
import pandas as pd
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from webdriver_manager.chrome import ChromeDriverManager
from PIL import Image
from fpdf import FPDF
from PyPDF2 import PdfMerger
import time
import os
from docx import Document
from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas
from pptx import Presentation
import win32com.client


# Variables globales para credenciales
email = ""
password = ""
nombre_oficina = ""

# Función para combinar imágenes en un PDF
def combinar_imagenes_en_pdf(carpeta_capturas, archivo_pdf_salida):
    """
    Combina todas las imágenes de una carpeta en un solo PDF y elimina las imágenes después de crear el PDF.
    :param carpeta_capturas: Carpeta donde están las capturas de pantalla.
    :param archivo_pdf_salida: Nombre del archivo PDF de salida.
    """
    # Obtener todas las imágenes de la carpeta en orden alfabético
    imagenes = sorted([f for f in os.listdir(carpeta_capturas) if f.endswith('.png')])

    if not imagenes:
        print("No se encontraron imágenes para combinar.")
        return

    # Crear el objeto PDF
    pdf = FPDF(orientation="P", unit="mm", format="A4")
    imagenes_para_pdf = []

    for imagen in imagenes:
        ruta_imagen = os.path.join(carpeta_capturas, imagen)
        try:
            # Abrir la imagen para obtener sus dimensiones
            with Image.open(ruta_imagen) as img:
                img_width, img_height = img.size

                # Convertir las dimensiones de píxeles a mm (A4 tiene 210x297 mm)
                pdf_width = 297  # Ancho de A4 en mm
                pdf_height = 210  # Ajuste personalizado de altura

                # Agregar la página al PDF
                pdf.add_page()
                pdf.image(ruta_imagen, x=0, y=0, w=pdf_width, h=pdf_height)

                # Agregar la imagen a la lista para conversión si es necesario
                imagenes_para_pdf.append(img)
        except Exception as e:
            print(f"Error al procesar la imagen {ruta_imagen}: {e}")

    # Guardar el PDF
    pdf.output(archivo_pdf_salida)
    print(f"PDF generado correctamente: {archivo_pdf_salida}")

    # Eliminar las imágenes después de crear el PDF
    for imagen in imagenes:
        ruta_imagen = os.path.join(carpeta_capturas, imagen)
        try:
            os.remove(ruta_imagen)
            print(f"Imagen eliminada: {ruta_imagen}")
        except Exception as e:
            print(f"Error al eliminar la imagen {ruta_imagen}: {e}")

# Función para capturar imágenes por scroll
def capturar_scroll(driver, scroll_container, carpeta_capturas, prefix="captura"):
    scroll_height = driver.execute_script("return arguments[0].scrollHeight;", scroll_container)
    scroll_position = 0
    step = 1000  # Altura a desplazar en cada iteración
    screenshot_count = 0

    # Crear la carpeta si no existe
    os.makedirs(carpeta_capturas, exist_ok=True)

    while scroll_position < scroll_height:
        driver.execute_script("arguments[0].scrollTop = arguments[1];", scroll_container, scroll_position)
        time.sleep(1)

        screenshot_path = os.path.join(carpeta_capturas, f"{prefix}_{screenshot_count}.png")
        scroll_container.screenshot(screenshot_path)
        print(f"Captura guardada: {screenshot_path}")

        scroll_position += step
        screenshot_count += 1

        if scroll_position >= scroll_height:
            break

def crear_carpetas_desde_pagina(driver, caso_a1):
    """
    Navega por cada carpeta de documentos y descarga los archivos dentro de ella.
    :param driver: Instancia del navegador.
    :param caso_a1: Nombre principal de la carpeta (obtenido del Excel).
    """
    documentos = driver.find_element(By.XPATH, '//*[@id="btnmostrardocumentosnegocio"]')
    documentos.click()

    # Inicializar el índice de carpetas
    carpeta_index = 2  # Los <ul> comienzan en la posición 2

    while True:
        try:
            # Recalcular el elemento de la carpeta actual
            carpeta_xpath = f'//*[@id="ObtenerDocumentos"]/ul[{carpeta_index}]/li[1]/a'
            carpeta_elemento = driver.find_element(By.XPATH, carpeta_xpath)
            nombre_carpeta = carpeta_elemento.text.strip()

            # Crear la carpeta en el sistema de archivos
            ruta_carpeta = os.path.join(caso_a1, nombre_carpeta)
            os.makedirs(ruta_carpeta, exist_ok=True)
            print(f"Carpeta creada o ya existente: {ruta_carpeta}")

            # Configurar la carpeta de descargas para esta carpeta específica
            driver.execute_cdp_cmd(
                "Page.setDownloadBehavior",
                {
                    "behavior": "allow",
                    "downloadPath": os.path.abspath(ruta_carpeta),
                },
            )

            # Entrar en la carpeta haciendo clic en el enlace
            carpeta_elemento.click()
            time.sleep(10)  # Esperar a que se carguen los archivos

            # Iterar para descargar los archivos dentro de la carpeta actual
            archivo_index = 1
            while True:
                try:
                    # Abrir el menú del archivo
                    menu_xpath = f'//*[@id="ObtenerDocumentos"]/ul[{archivo_index + 1}]/li[7]'
                    menu_elemento = driver.find_element(By.XPATH, menu_xpath)
                    menu_elemento.click()
                    time.sleep(2)

                    # Hacer clic en el botón de descarga
                    descargar_xpath = f'//*[@id="ObtenerDocumentos"]/ul[{archivo_index + 1}]/li[7]/div/a[2]'
                    boton_descarga = driver.find_element(By.XPATH, descargar_xpath)
                    boton_descarga.click()
                    time.sleep(5)  # Esperar a que se complete la descarga

                    print(f"Archivo {archivo_index} descargado en la carpeta: {nombre_carpeta}")
                    archivo_index += 1  # Incrementar el índice para el siguiente archivo
                except Exception:
                    # Si no encuentra más archivos, salir del bucle
                    print(f"No se encontraron más archivos en la carpeta: {nombre_carpeta}")
                    break

            # Volver a la lista principal de carpetas
            driver.find_element(By.XPATH, '//*[@id="fixedPaginacion"]/div[1]/nav/ol/li[2]').click()
            time.sleep(5)

            # Incrementar el índice de carpetas para la siguiente
            carpeta_index += 1

        except Exception as e:
            # Si no encuentra más carpetas, salir del bucle
            print(f"No se encontraron más carpetas para procesar o error procesando: {e}")
            break

def convertir_imagenes_a_pdf(carpeta_principal):
    """
    Itera sobre las subcarpetas en la carpeta principal, convierte las imágenes en un solo PDF por subcarpeta,
    y elimina los archivos originales después de crear el PDF.
    :param carpeta_principal: Ruta principal donde se encuentran las subcarpetas con imágenes.
    """
    # Iterar sobre cada subcarpeta en la carpeta principal
    for carpeta in os.listdir(carpeta_principal):
        ruta_carpeta = os.path.join(carpeta_principal, carpeta)

        # Verificar si es una carpeta
        if not os.path.isdir(ruta_carpeta):
            continue

        print(f"Procesando carpeta: {ruta_carpeta}")

        # Obtener todas las imágenes dentro de la carpeta, ordenadas alfabéticamente
        imagenes = sorted(
            [f for f in os.listdir(ruta_carpeta) if f.lower().endswith(('.png', '.jpg', '.jpeg'))]
        )
        if not imagenes:
            print(f"No se encontraron imágenes en la carpeta: {ruta_carpeta}")
            continue

        # Convertir las imágenes a un único PDF
        pdf_path = os.path.join(ruta_carpeta, f"{carpeta}.pdf")
        imagenes_para_pdf = []

        for imagen in imagenes:
            ruta_imagen = os.path.join(ruta_carpeta, imagen)
            try:
                # Abrir la imagen
                img = Image.open(ruta_imagen)
                # Convertir a modo RGB si es necesario
                if img.mode != 'RGB':
                    img = img.convert('RGB')
                imagenes_para_pdf.append(img)
            except Exception as e:
                print(f"Error al procesar la imagen {ruta_imagen}: {e}")

        # Guardar las imágenes como PDF
        if imagenes_para_pdf:
            imagenes_para_pdf[0].save(
                pdf_path,
                save_all=True,
                append_images=imagenes_para_pdf[1:]
            )
            print(f"PDF creado: {pdf_path}")

            # Eliminar las imágenes originales
            for imagen in imagenes:
                ruta_imagen = os.path.join(ruta_carpeta, imagen)
                os.remove(ruta_imagen)
            print(f"Imágenes eliminadas en la carpeta: {ruta_carpeta}")
        else:
            print(f"No se pudo generar el PDF para la carpeta: {ruta_carpeta}")

def unir_pdfs_en_carpeta(carpeta_principal):
    """
    Une todos los PDFs en cada subcarpeta dentro de la carpeta principal.
    En la carpeta "01SolicitudAudiencia", asegura que "captura_completa.pdf" sea el primero.
    Elimina los PDFs originales después de generar el PDF combinado, pero no elimina el PDF combinado.
    :param carpeta_principal: Ruta principal donde están las subcarpetas con PDFs.
    """
    # Iterar sobre cada subcarpeta en la carpeta principal
    for carpeta in os.listdir(carpeta_principal):
        ruta_carpeta = os.path.join(carpeta_principal, carpeta)

        # Verificar si es una carpeta
        if not os.path.isdir(ruta_carpeta):
            continue

        print(f"Procesando carpeta: {ruta_carpeta}")

        # Obtener todos los PDFs dentro de la carpeta
        pdfs = sorted([f for f in os.listdir(ruta_carpeta) if f.lower().endswith('.pdf')])
        if not pdfs:
            print(f"No se encontraron PDFs en la carpeta: {ruta_carpeta}")
            continue

        # En la carpeta "01SolicitudAudiencia", asegura que "captura_completa.pdf" sea el primero
        pdfs_finales = []
        if carpeta == "01SolicitudAudiencia" and "captura_completa.pdf" in pdfs:
            pdfs_finales.append("captura_completa.pdf")
            pdfs.remove("captura_completa.pdf")
        pdfs_finales.extend(pdfs)  # Agregar los demás PDFs

        # Combinar los PDFs
        pdf_combinado_path = os.path.join(ruta_carpeta, f"{carpeta}.pdf")
        merger = PdfMerger()

        for pdf in pdfs_finales:
            ruta_pdf = os.path.join(ruta_carpeta, pdf)
            try:
                merger.append(ruta_pdf)
                print(f"Añadiendo {pdf} al PDF combinado.")
            except Exception as e:
                print(f"Error al añadir {pdf}: {e}")

        # Guardar el PDF combinado
        merger.write(pdf_combinado_path)
        merger.close()
        print(f"PDF combinado creado: {pdf_combinado_path}")

        # Eliminar los PDFs originales, excepto el combinado
        for pdf in pdfs_finales:
            ruta_pdf = os.path.join(ruta_carpeta, pdf)
            if ruta_pdf == pdf_combinado_path:  # No eliminar el PDF combinado
                continue
            try:
                os.remove(ruta_pdf)
                print(f"Archivo eliminado: {ruta_pdf}")
            except Exception as e:
                print(f"Error al eliminar {ruta_pdf}: {e}")

def convertir_doc_a_docx(ruta_archivo):
    """
    Convierte un archivo .doc a .docx utilizando Microsoft Word.
    :param ruta_archivo: Ruta completa del archivo .doc.
    :return: Ruta del archivo convertido (.docx).
    """
    word = win32com.client.Dispatch("Word.Application")
    word.Visible = False  # Mantener la ventana oculta
    try:
        doc = word.Documents.Open(ruta_archivo)
        ruta_convertida = ruta_archivo.replace('.doc', '.docx')
        doc.SaveAs(ruta_convertida, FileFormat=16)  # 16 es el formato para .docx
        doc.Close()
        print(f"Archivo convertido de .doc a .docx: {ruta_convertida}")
        return ruta_convertida
    except Exception as e:
        print(f"Error al convertir el archivo .doc: {e}")
    finally:
        word.Quit()

def convertir_docx_a_pdf(ruta_archivo, pdf_output):
    """
    Convierte un archivo .docx en un PDF.
    :param ruta_archivo: Ruta completa del archivo .docx.
    :param pdf_output: Ruta completa del archivo de salida .pdf.
    """
    word = win32com.client.Dispatch("Word.Application")
    word.Visible = False  # Ejecutar en segundo plano
    try:
        # Convertir rutas relativas a absolutas
        ruta_archivo = os.path.abspath(ruta_archivo)
        pdf_output = os.path.abspath(pdf_output)

        # Abrir y guardar el archivo
        doc = word.Documents.Open(ruta_archivo)
        doc.SaveAs(pdf_output, FileFormat=17)  # 17 es el formato para guardar como PDF
        doc.Close()
        print(f"Archivo convertido a PDF: {pdf_output}")
    except Exception as e:
        print(f"Error al convertir {ruta_archivo} a PDF: {e}")
    finally:
        word.Quit()

def convertir_txt_a_pdf(ruta_archivo, pdf_output):
    """
    Convierte un archivo de texto (.txt) en un PDF.
    :param ruta_archivo: Ruta completa del archivo .txt.
    :param pdf_output: Ruta completa del archivo de salida .pdf.
    """
    pdf = canvas.Canvas(pdf_output, pagesize=letter)
    pdf.setFont("Helvetica", 12)
    with open(ruta_archivo, 'r', encoding='utf-8') as file:
        y = 750
        for line in file:
            pdf.drawString(50, y, line.strip())
            y -= 15
            if y < 50:
                pdf.showPage()
                y = 750
    pdf.save()
    print(f"Archivo convertido a PDF: {pdf_output}")

def convertir_archivos_a_pdf(carpeta_principal):
    """
    Convierte archivos de texto, Word (.doc y .docx) en PDFs individuales.
    Elimina los archivos originales después de la conversión.
    :param carpeta_principal: Ruta principal donde se encuentran las subcarpetas con archivos.
    """
    for carpeta in os.listdir(carpeta_principal):
        ruta_carpeta = os.path.join(carpeta_principal, carpeta)

        if not os.path.isdir(ruta_carpeta):
            continue

        print(f"Procesando carpeta: {ruta_carpeta}")

        # Obtener todos los archivos soportados
        archivos = sorted(
            [f for f in os.listdir(ruta_carpeta) if f.lower().endswith(('.txt', '.doc', '.docx'))]
        )
        if not archivos:
            print(f"No se encontraron archivos soportados en la carpeta: {ruta_carpeta}")
            continue

        for archivo in archivos:
            ruta_archivo = os.path.join(ruta_carpeta, archivo)
            pdf_output = os.path.splitext(ruta_archivo)[0] + ".pdf"  # Cambiar la extensión a .pdf

            try:
                # Manejar archivos .doc convirtiéndolos a .docx
                if archivo.lower().endswith('.doc'):
                    ruta_archivo = convertir_doc_a_docx(ruta_archivo)
                    os.remove(os.path.join(ruta_carpeta, archivo))  # Eliminar el archivo .doc original

                # Manejar archivos Word (.docx)
                if archivo.lower().endswith('.docx'):
                    convertir_docx_a_pdf(ruta_archivo, pdf_output)

                # Manejar archivos de texto
                elif archivo.lower().endswith('.txt'):
                    convertir_txt_a_pdf(ruta_archivo, pdf_output)

                # Eliminar el archivo original después de convertirlo
                os.remove(ruta_archivo)
                print(f"Archivo original eliminado: {ruta_archivo}")
            except Exception as e:
                print(f"Error al procesar el archivo {ruta_archivo}: {e}")

def iniciar_proceso(driver, caso_a1, primera_vez):
    """
    Inicia el proceso de automatización con el caso especificado.
    :param driver: Instancia del navegador.
    :param caso_a1: Identificador del caso a procesar.
    :param primera_vez: Indica si es la primera vez que se ejecuta el proceso (para realizar el inicio de sesión).
    """
    try:
        if primera_vez:
            driver.get("https://www.legisoffice.com/consultorio/Casos/Index/2")
            driver.implicitly_wait(10)

            # Realizar inicio de sesión con credenciales globales
            driver.find_element(By.XPATH, '//*[@id="Email"]').send_keys(email)
            driver.find_element(By.XPATH, '//*[@id="Password"]').send_keys(password)
            driver.find_element(By.XPATH, '//*[@id="NombreOficina"]').send_keys(nombre_oficina)
            driver.find_element(By.XPATH, '//*[@id="btnInicio"]').click()
            time.sleep(2)

            driver.find_element(By.XPATH, '//*[@id="continuar"]').click()
            time.sleep(5)

            print("Inicio de sesión completado.")

        driver.find_element(By.XPATH, '//*[@id="liCasosIndex"]/a').click()
        time.sleep(5)

        print(f"Procesando el caso: {caso_a1}")

        driver.find_element(By.XPATH, '//*[@id="select2-select_Buscador-container"]').click()
        search_field = driver.find_element(By.XPATH, '/html/body/span/span/span[1]/input')
        search_field.send_keys(str(caso_a1))
        search_field.send_keys(Keys.ENTER)
        time.sleep(5)

        texto_caso = WebDriverWait(driver, 10).until(
            EC.element_to_be_clickable((By.XPATH, '//*[@id="texto_caso"]'))
        )
        texto_caso.click()
        time.sleep(5)

        info_button = WebDriverWait(driver, 10).until(
            EC.element_to_be_clickable((By.XPATH, '//*[@id="BtnDatosBasicos"]'))
        )
        info_button.click()
        time.sleep(30)

        # Ampliar las cajas de texto
        textareas = [
            '//*[@id="acordeonBasicos_0"]/div/div/div[10]/div/textarea',
            '//*[@id="acordeonBasicos_0"]/div/div/div[11]/div/textarea'
        ]

        for textarea_xpath in textareas:
            textarea_element = driver.find_element(By.XPATH, textarea_xpath)
            driver.execute_script("arguments[0].style.height = arguments[0].scrollHeight + 'px';", textarea_element)
            print(f"Caja de texto ampliada: {textarea_xpath}")

        # Primera captura
        scroll_container = driver.find_element(By.CSS_SELECTOR, ".content_pagina")
        capturar_scroll(driver, scroll_container, f"{caso_a1}/01SolicitudAudiencia", prefix="captura_primera")

        # Verificar contenido en la nueva pestaña
        info_button = WebDriverWait(driver, 10).until(
            EC.element_to_be_clickable((By.XPATH, '//*[@id="BtnDatosBasicos"]'))
        )
        info_button.click()
        time.sleep(30)
        driver.find_element(By.TAG_NAME, 'body').send_keys(Keys.F5)
        # Verificar contenido en la nueva pestaña
        nueva_pestana = driver.find_element(By.XPATH, '//*[@id="validateform"]/div[1]/div/ul/li[2]')
        nueva_pestana.click()
        time.sleep(10)  # Espera adicional para cargar la nueva pestaña

        elemento_verificar = driver.find_element(By.XPATH, '//*[@id="ID_3c405fb8-89c9-49f8-ae3e-ccb50c1a8589"]')
        if elemento_verificar.get_attribute("value").strip():
            print("El elemento tiene contenido. Capturando imágenes de la nueva pestaña...")
            capturar_scroll(driver, scroll_container, f"{caso_a1}/01SolicitudAudiencia", prefix="captura_segunda")
        else:
            print("El elemento está vacío. No se capturarán imágenes adicionales.")

        # Generar el PDF
        combinar_imagenes_en_pdf(f"{caso_a1}/01SolicitudAudiencia", f"{caso_a1}/01SolicitudAudiencia/captura_completa.pdf")

        crear_carpetas_desde_pagina(driver, caso_a1)
        time.sleep(5)
        convertir_imagenes_a_pdf(caso_a1)
        time.sleep(5)
        convertir_archivos_a_pdf(caso_a1)
        time.sleep(5)
        unir_pdfs_en_carpeta(caso_a1)
        time.sleep(5)
        print("PROCESO TERMINADO CON EXITO")

    except Exception as e:
        print(f"Error durante el procesamiento del caso {caso_a1}: {e}")
        messagebox.showerror("Error", f"Error durante el procesamiento del caso {caso_a1}: {e}")

def guardar_credenciales():
    """
    Guarda las credenciales ingresadas en las variables globales.
    """
    global email, password, nombre_oficina
    email = email_entry.get().strip()
    password = password_entry.get().strip()
    nombre_oficina = oficina_entry.get().strip()

    if not email or not password or not nombre_oficina:
        messagebox.showwarning("Advertencia", "Por favor, complete todos los campos de credenciales.")
    else:
        messagebox.showinfo("Información", "Credenciales guardadas correctamente.")

def procesar_casos_desde_excel(archivo_excel):
    """
    Procesa múltiples casos desde un archivo Excel.
    :param archivo_excel: Ruta al archivo Excel que contiene los casos.
    """
    try:
        data = pd.read_excel(archivo_excel, header=None)
        driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
        driver.maximize_window()

        primera_vez = True
        for _, row in data.iterrows():
            caso_a1 = row[0]  # Leer el caso de la fila actual
            iniciar_proceso(driver, caso_a1, primera_vez)
            primera_vez = False  # No repetir inicio de sesión

    finally:
        driver.quit()

def procesar_caso_manual(caso_a1):
    """
    Procesa un caso ingresado manualmente.
    :param caso_a1: Identificador del caso a procesar.
    """
    try:
        driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
        driver.maximize_window()

        iniciar_proceso(driver, caso_a1, True)  # Siempre iniciar sesión para casos manuales

    finally:
        driver.quit()


def cargar_excel():
    """
    Permite al usuario cargar un archivo Excel y procesar cada caso iterativamente.
    """
    archivo = filedialog.askopenfilename(
        title="Seleccione un archivo Excel",
        filetypes=[("Archivos Excel", "*.xlsx")]
    )
    if archivo:
        try:
            procesar_casos_desde_excel(archivo)  # Procesar el Excel cargado
        except Exception as e:
            messagebox.showerror("Error", f"Error al leer el archivo Excel: {e}")


def ejecutar_manual():
    """
    Procesa el caso ingresado manualmente en la caja de texto.
    """
    caso_a1 = entrada_manual.get().strip().replace("\n", "").replace("\r", "")  # Eliminar espacios y saltos de línea
    if caso_a1:
        try:
            procesar_caso_manual(caso_a1)  # Procesar el caso ingresado manualmente
        except Exception as e:
            messagebox.showerror("Error", f"Error al procesar el caso manual: {e}")
    else:
        messagebox.showwarning("Advertencia", "Por favor, ingrese un caso válido.")


# Interfaz gráfica
root = tk.Tk()
root.title("Robot Consultorio Jurídico Casos")
root.geometry("400x300")

logo_label = tk.Label(text="RPA Consultorio Juridico", bg="lightgray", height=5, width=30)
logo_label.pack()

# Campos de entrada para credenciales
frame_credenciales = tk.Frame(root)
frame_credenciales.pack(pady=10)

tk.Label(frame_credenciales, text="Correo:").grid(row=0, column=0, padx=5, pady=5)
email_entry = tk.Entry(frame_credenciales, width=30)
email_entry.grid(row=0, column=1, padx=5, pady=5)

tk.Label(frame_credenciales, text="Contraseña:").grid(row=1, column=0, padx=5, pady=5)
password_entry = tk.Entry(frame_credenciales, show="*", width=30)
password_entry.grid(row=1, column=1, padx=5, pady=5)

tk.Label(frame_credenciales, text="Oficina:").grid(row=2, column=0, padx=5, pady=5)
oficina_entry = tk.Entry(frame_credenciales, width=30)
oficina_entry.grid(row=2, column=1, padx=5, pady=5)

guardar_credenciales_button = tk.Button(root, text="Guardar Credenciales", command=guardar_credenciales)
guardar_credenciales_button.pack(pady=10)


# Botón para cargar Excel
boton_cargar_excel = tk.Button(root, text="Cargar Excel", command=cargar_excel, width=20)
boton_cargar_excel.pack(pady=10)

# Entrada manual
entrada_manual = tk.Entry(root, width=30)
entrada_manual.pack(pady=5)
boton_ejecutar_manual = tk.Button(root, text="Ejecutar Caso Manual", command=ejecutar_manual, width=20)
boton_ejecutar_manual.pack(pady=10)

# Mostrar la ventana
root.mainloop()
