# 📅 RemindersPro — iPad App en SwiftUI

App de recordatorios para iPad con categorías diferenciadas (Empleados, Administrativos, Gestión)
y notificaciones locales configurables.

---

## 📁 Estructura del proyecto

```
RemindersApp/
├── RemindersApp.swift                  ← Entry point (@main)
├── Models/
│   └── ReminderModel.swift             ← Modelos: Reminder, ReminderCategory
├── Stores/
│   └── ReminderStore.swift             ← Persistencia (UserDefaults + JSON)
├── Managers/
│   └── NotificationManager.swift       ← Notificaciones locales (UNUserNotificationCenter)
└── Views/
    ├── ContentView.swift               ← NavigationSplitView + Sidebar
    ├── ReminderListView.swift          ← Listas por categoría y vista general
    └── AddEditReminderView.swift       ← Formulario añadir/editar
```

---

## 🚀 Cómo crear el proyecto en Xcode

1. **Xcode → File → New → Project**
2. Elige **iOS → App**
3. Configura:
   - Product Name: `RemindersApp`
   - Interface: **SwiftUI**
   - Language: **Swift**
   - Minimum Deployments: **iOS 16+** (recomendado iOS 17)
4. Elimina el `ContentView.swift` que genera Xcode
5. Crea los grupos de carpetas (New Group) tal como se muestra arriba
6. Arrastra o crea cada archivo `.swift` con el contenido correspondiente

---

## 🔔 Permisos de notificaciones

Agrega esto a tu `Info.plist`:

```xml
<key>NSUserNotificationUsageDescription</key>
<string>Esta app necesita enviar notificaciones para recordarte tus tareas.</string>
```

O en Xcode: Target → Info → Custom iOS Target Properties
→ Add row: `Privacy - User Notifications Usage Description`

---

## ✨ Funcionalidades

| Feature | Descripción |
|---|---|
| 3 categorías | Empleados 👥 · Administrativos 📄 · Gestión 📊 |
| Notificación anticipada | Por defecto 10 min, configurable: 5m / 10m / 15m / 30m / 1h / 2h / 1d |
| Persistencia | JSON en UserDefaults, sobrevive reinicios |
| Swipe actions | Desliza para completar o eliminar |
| Edición | Toca cualquier recordatorio para editar |
| iPad optimizado | NavigationSplitView con sidebar y vista de detalle |
| Recordatorios pasados | Se agrupan como "anteriores" y se pueden mostrar/ocultar |

---

## 🎨 Paleta de colores

- **Empleados**: Azul (#3B82F6 → #2563EB)
- **Administrativos**: Ámbar (#FCD34D → #D97706)
- **Gestión**: Violeta (#A78BFA → #7C3AED)

---

## 📱 Requisitos

- Xcode 15+
- iOS/iPadOS 16.0+
- Sin dependencias externas (100% SwiftUI nativo)
