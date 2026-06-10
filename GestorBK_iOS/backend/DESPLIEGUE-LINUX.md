# Despliegue GestorBK WhatsApp — Servidor Linux desde cero

## Requisitos
- Ubuntu 20.04 / 22.04 (recomendado)
- Mínimo 1 GB RAM (recomendado 2 GB — Chromium es pesado)
- Node.js 18+
- Acceso SSH con sudo

---

## 1. Instalar Node.js 18

```bash
curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs
node -v   # debe mostrar v18.x.x
```

---

## 2. Instalar Google Chrome

```bash
wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | sudo apt-key add -
echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" | sudo tee /etc/apt/sources.list.d/google-chrome.list
sudo apt-get update
sudo apt-get install -y google-chrome-stable
which google-chrome-stable   # debe mostrar /usr/bin/google-chrome-stable
```

---

## 3. Instalar dependencias del sistema para Puppeteer

```bash
sudo apt-get install -y \
  libgbm-dev libasound2 libatk1.0-0 libatk-bridge2.0-0 \
  libcups2 libdrm2 libxkbcommon0 libxcomposite1 \
  libxdamage1 libxfixes3 libxrandr2 libpango-1.0-0 \
  libnspr4 libnss3 libx11-xcb1 libxcb-dri3-0
```

---

## 4. Subir los archivos al servidor

Desde tu máquina local copia `package.json` e `index.js`:

```bash
scp package.json index.js usuario@IP_SERVIDOR:/var/www/gestorbk-wa/
```

O con FileZilla/WinSCP — destino: `/var/www/gestorbk-wa/`

---

## 5. Instalar dependencias Node

```bash
mkdir -p /var/www/gestorbk-wa
cd /var/www/gestorbk-wa
npm install
```

---

## 6. Instalar PM2 y arrancar el servicio

```bash
sudo npm install -g pm2
cd /var/www/gestorbk-wa
pm2 start index.js --name gestorbk-wa
pm2 save
pm2 startup   # copia y ejecuta el comando que te imprima
```

---

## 7. Configurar nginx (proxy inverso)

Edita el bloque `server {}` de tu sitio en nginx:

```nginx
location /wa/ {
    proxy_pass         http://127.0.0.1:3000/;
    proxy_http_version 1.1;
    proxy_set_header   Upgrade $http_upgrade;
    proxy_set_header   Connection 'upgrade';
    proxy_set_header   Host $host;
    proxy_cache_bypass $http_upgrade;
}
```

```bash
sudo nginx -t && sudo systemctl reload nginx
```

---

## 8. Primera vez — escanear el QR

```bash
pm2 logs gestorbk-wa
```

Abre en el navegador:

```
https://tu-dominio/wa/api/status
```

El campo `qr` contiene la imagen en base64. Pégala en https://www.base64-image.de/
o usa cualquier visor para mostrar el QR y escanearlo con el teléfono.

Cuando el campo `status` cambie a `READY`, el backend está funcionando.

---

## Comandos útiles PM2

```bash
pm2 status                    # ver estado
pm2 logs gestorbk-wa          # ver logs en tiempo real
pm2 restart gestorbk-wa       # reiniciar
pm2 stop gestorbk-wa          # detener
pm2 monit                     # monitor de CPU y RAM
```

---

## Endpoints disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/status | Estado de WhatsApp + QR |
| GET | /api/contacts | Lista de contactos |
| GET | /api/groups | Lista de grupos |
| GET | /api/messages | Mensajes programados |
| POST | /api/messages | Crear mensaje programado |
| PUT | /api/messages/:id | Editar mensaje |
| DELETE | /api/messages/:id | Eliminar mensaje |
| POST | /api/messages/:id/send | Envío manual inmediato |

> Los horarios se manejan en zona **Europe/Madrid** sin importar la zona del servidor.

---

## Notas

- La sesión de WhatsApp se guarda en `data/session/` — no la borres o tendrás que escanear el QR de nuevo.
- Los mensajes programados se guardan en `data/messages.json`.
- Si cambias el puerto, usa la variable de entorno: `PORT=4000 pm2 start index.js --name gestorbk-wa`
- Si Chrome está en otra ruta: `CHROMIUM_PATH=/ruta/chrome pm2 start index.js --name gestorbk-wa`
