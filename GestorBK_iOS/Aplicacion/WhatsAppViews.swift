import SwiftUI

// MARK: - Main WhatsApp View

struct WAView: View {
    @EnvironmentObject var waStore: WAStore
    @State private var showingAdd        = false
    @State private var messageToEdit: WAMessage? = nil
    @State private var showingSettings  = false
    @State private var showingContacts  = false

    var body: some View {
        Group {
            if waStore.messages.isEmpty {
                WAEmptyView(showingAdd: $showingAdd)
            } else {
                List {
                    Section {
                        WAStatusBanner()
                    }

                    Section("Mensajes programados") {
                        ForEach(waStore.messages) { msg in
                            WAMessageRow(message: msg)
                                .contentShape(Rectangle())
                                .onTapGesture { messageToEdit = msg }
                                .swipeActions(edge: .trailing) {
                                    Button(role: .destructive) {
                                        Task { try? await waStore.deleteMessage(msg) }
                                    } label: {
                                        Label("Eliminar", systemImage: "trash.fill")
                                    }
                                }
                                .swipeActions(edge: .leading) {
                                    Button {
                                        Task { try? await waStore.sendNow(msg) }
                                    } label: {
                                        Label("Enviar ahora", systemImage: "paperplane.fill")
                                    }
                                    .tint(Color(hex: "#25D366"))
                                }
                        }
                    }
                }
                .listStyle(.insetGrouped)
            }
        }
        .navigationTitle("WhatsApp")
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showingAdd = true } label: {
                    Image(systemName: "plus.circle.fill")
                        .font(.title3)
                        .foregroundStyle(Color(hex: "#25D366"))
                }
            }
            ToolbarItem(placement: .navigationBarLeading) {
                HStack(spacing: 12) {
                    Button { showingContacts = true } label: {
                        Image(systemName: "person.2.fill")
                            .foregroundStyle(Color(hex: "#25D366"))
                    }
                    Button { showingSettings = true } label: {
                        Image(systemName: "gearshape.fill")
                            .foregroundStyle(.secondary)
                    }
                }
            }
        }
        .sheet(isPresented: $showingAdd) {
            AddEditWAMessageView(existing: nil)
        }
        .sheet(item: $messageToEdit) { msg in
            AddEditWAMessageView(existing: msg)
        }
        .sheet(isPresented: $showingSettings) {
            WASettingsView()
        }
        .sheet(isPresented: $showingContacts) {
            WAContactsView()
        }
        .task { await waStore.refresh() }
    }
}

// MARK: - Status Banner

struct WAStatusBanner: View {
    @EnvironmentObject var waStore: WAStore

    var body: some View {
        switch waStore.waStatus.status {
        case "READY":
            HStack(spacing: 10) {
                Circle()
                    .fill(Color(hex: "#25D366"))
                    .frame(width: 10, height: 10)
                Text("WhatsApp conectado")
                    .font(.system(.callout, design: .rounded, weight: .medium))
                    .foregroundStyle(Color(hex: "#25D366"))
                Spacer()
                if waStore.isLoading {
                    ProgressView().scaleEffect(0.8)
                }
            }
            .padding(.vertical, 4)

        case "QR_READY":
            VStack(spacing: 12) {
                HStack(spacing: 8) {
                    Image(systemName: "qrcode")
                        .foregroundStyle(.blue)
                    Text("Escanea el código QR con WhatsApp")
                        .font(.system(.callout, design: .rounded, weight: .semibold))
                    Spacer()
                    Button {
                        Task { await waStore.refresh() }
                    } label: {
                        Image(systemName: "arrow.clockwise")
                            .font(.callout)
                    }
                }
                if let qrStr = waStore.waStatus.qr,
                   let data  = Data(base64Encoded: qrStr.replacingOccurrences(
                       of: "data:image/png;base64,", with: "")),
                   let uiImg = UIImage(data: data) {
                    Image(uiImage: uiImg)
                        .resizable()
                        .interpolation(.none)
                        .scaledToFit()
                        .frame(maxWidth: 200, maxHeight: 200)
                        .cornerRadius(12)
                        .padding(.vertical, 4)
                }
                Text("Abre WhatsApp → Dispositivos vinculados → Vincular dispositivo")
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
            }
            .padding(.vertical, 8)

        case "AUTHENTICATED":
            HStack(spacing: 8) {
                ProgressView().scaleEffect(0.9)
                Text("Conectando con WhatsApp...")
                    .font(.callout)
                    .foregroundStyle(.secondary)
            }
            .padding(.vertical, 4)

        case "DISCONNECTED":
            HStack(spacing: 10) {
                Image(systemName: "exclamationmark.triangle.fill")
                    .foregroundStyle(.orange)
                VStack(alignment: .leading, spacing: 2) {
                    Text("WhatsApp no autenticado")
                        .font(.system(.callout, design: .rounded, weight: .semibold))
                    Text("Servidor OK. Reinicia el proceso en el servidor para generar el QR.")
                        .font(.caption)
                        .foregroundStyle(.secondary)
                }
                Spacer()
                Button {
                    Task { await waStore.refresh() }
                } label: {
                    Image(systemName: "arrow.clockwise")
                        .foregroundStyle(.orange)
                }
            }
            .padding(.vertical, 4)

        default:
            HStack(spacing: 10) {
                Image(systemName: "xmark.circle.fill")
                    .foregroundStyle(.red)
                VStack(alignment: .leading, spacing: 2) {
                    Text("No se puede conectar con el servidor")
                        .font(.system(.callout, design: .rounded, weight: .semibold))
                    Text("Revisa la URL en Ajustes y que el servidor esté en marcha.")
                        .font(.caption)
                        .foregroundStyle(.secondary)
                }
                Spacer()
                Button {
                    Task { await waStore.refresh() }
                } label: {
                    Image(systemName: "arrow.clockwise")
                        .foregroundStyle(.red)
                }
            }
            .padding(.vertical, 4)
        }
    }
}

// MARK: - Message Row

struct WAMessageRow: View {
    @EnvironmentObject var waStore: WAStore
    let message: WAMessage

    var recipientSummary: String {
        message.recipients.isEmpty
            ? "Sin destinatarios"
            : message.recipients.map { $0.name }.joined(separator: ", ")
    }

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                RoundedRectangle(cornerRadius: 10, style: .continuous)
                    .fill(LinearGradient(
                        colors: [Color(hex: "#25D366"), Color(hex: "#128C7E")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 40, height: 40)
                Image(systemName: "message.fill")
                    .font(.system(size: 17, weight: .semibold))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 4) {
                Text(message.name)
                    .font(.system(.body, design: .rounded, weight: .semibold))
                    .lineLimit(1)
                Text(recipientSummary)
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .lineLimit(1)
                Text(message.schedule.displayString)
                    .font(.caption)
                    .foregroundStyle(.secondary)
            }

            Spacer()

            Toggle("", isOn: Binding(
                get: { message.isActive },
                set: { _ in waStore.toggleActive(message) }
            ))
            .labelsHidden()
        }
        .padding(.vertical, 4)
        .opacity(message.isActive ? 1 : 0.5)
    }
}

// MARK: - Add / Edit Message View

struct AddEditWAMessageView: View {
    @EnvironmentObject var waStore: WAStore
    @Environment(\.dismiss) var dismiss

    let existing: WAMessage?
    private var isEditing: Bool { existing != nil }

    @State private var name         = ""
    @State private var messageText  = ""
    @State private var selectedDays = Set<Weekday>()
    @State private var time: Date   = Calendar.current.date(bySettingHour: 9, minute: 0, second: 0, of: Date()) ?? Date()
    @State private var isActive     = true
    @State private var recipients: [WARecipient] = []

    @State private var showValidation       = false
    @State private var isSaving             = false
    @State private var saveError: String?   = nil
    @State private var showingAddRecipient  = false
    @State private var showingContactPicker = false
    @State private var showingDeleteConfirm = false
    @State private var recipientToEdit: WARecipient? = nil
    @State private var newRecipientID   = ""
    @State private var newRecipientName = ""
    @State private var newRecipientType = WARecipientType.contact

    init(existing: WAMessage?) {
        self.existing = existing
        guard let e = existing else { return }
        _name         = State(initialValue: e.name)
        _messageText  = State(initialValue: e.message)
        _isActive     = State(initialValue: e.isActive)
        _recipients   = State(initialValue: e.recipients)
        _selectedDays = State(initialValue: Set(e.schedule.days.compactMap { Weekday.from(jsWeekday: $0) }))
        let parts = e.schedule.time.split(separator: ":").compactMap { Int($0) }
        if parts.count == 2,
           let d = Calendar.current.date(bySettingHour: parts[0], minute: parts[1], second: 0, of: Date()) {
            _time = State(initialValue: d)
        }
    }

    var body: some View {
        NavigationStack {
            Form {
                // ── Información ──────────────────────────────────────────────
                Section("Información") {
                    TextField("Nombre del mensaje", text: $name)
                        .font(.system(.body, design: .rounded))

                    if showValidation && name.trimmingCharacters(in: .whitespaces).isEmpty {
                        validationLabel("El nombre es obligatorio")
                    }

                    ZStack(alignment: .topLeading) {
                        if messageText.isEmpty {
                            Text("Texto del mensaje...")
                                .foregroundStyle(.secondary)
                                .padding(.top, 8)
                                .padding(.leading, 4)
                                .font(.system(size: 17))
                                .allowsHitTesting(false)
                        }
                        TextEditor(text: $messageText)
                            .frame(minHeight: 100)
                    }
                    if showValidation && messageText.trimmingCharacters(in: .whitespaces).isEmpty {
                        validationLabel("El mensaje es obligatorio")
                    }
                }

                // ── Destinatarios ─────────────────────────────────────────────
                Section {
                    ForEach(recipients) { recipient in
                        HStack(spacing: 10) {
                            Image(systemName: recipient.type.icon)
                                .foregroundStyle(recipient.type == .group ? .blue : Color(hex: "#25D366"))
                                .frame(width: 20)
                            VStack(alignment: .leading, spacing: 2) {
                                Text(recipient.name)
                                    .font(.system(.callout, design: .rounded, weight: .medium))
                                Text(recipient.id)
                                    .font(.caption)
                                    .foregroundStyle(.secondary)
                            }
                            Spacer()
                            Text(recipient.type.label)
                                .font(.caption2.bold())
                                .foregroundStyle(.white)
                                .padding(.horizontal, 6)
                                .padding(.vertical, 2)
                                .background(
                                    recipient.type == .group
                                    ? Color.blue.gradient
                                    : Color(hex: "#25D366").gradient,
                                    in: Capsule()
                                )
                        }
                        .swipeActions(edge: .trailing) {
                            Button(role: .destructive) {
                                recipients.removeAll { $0.id == recipient.id }
                            } label: {
                                Label("Quitar", systemImage: "trash.fill")
                            }
                        }
                        .swipeActions(edge: .leading) {
                            Button {
                                recipientToEdit  = recipient
                                newRecipientID   = recipient.id
                                newRecipientName = recipient.name
                                newRecipientType = recipient.type
                                showingAddRecipient = true
                            } label: {
                                Label("Editar", systemImage: "pencil")
                            }
                            .tint(.blue)
                        }
                    }

                    // Pick from saved contacts
                    Button {
                        showingContactPicker = true
                    } label: {
                        Label("Añadir de contactos guardados", systemImage: "person.2.fill")
                            .foregroundStyle(Color(hex: "#25D366"))
                    }

                    // Add manually
                    Button {
                        recipientToEdit  = nil
                        newRecipientID   = ""
                        newRecipientName = ""
                        newRecipientType = .contact
                        showingAddRecipient = true
                    } label: {
                        Label("Añadir destinatario manual", systemImage: "plus.circle")
                            .foregroundStyle(.secondary)
                    }

                    if showValidation && recipients.isEmpty {
                        validationLabel("Añade al menos un destinatario")
                    }
                } header: {
                    Text("Destinatarios (\(recipients.count))")
                } footer: {
                    Text("Desliza a la izquierda para editar un destinatario, a la derecha para quitarlo del mensaje.")
                        .font(.caption)
                }

                // ── Días ──────────────────────────────────────────────────────
                Section {
                    WeekdayPickerView(selectedDays: $selectedDays)
                        .listRowInsets(EdgeInsets(top: 12, leading: 12, bottom: 12, trailing: 12))
                    if showValidation && selectedDays.isEmpty {
                        validationLabel("Selecciona al menos un día")
                    }
                } header: {
                    Text("Días de envío")
                }

                // ── Hora ──────────────────────────────────────────────────────
                Section("Hora de envío") {
                    DatePicker("Hora", selection: $time, displayedComponents: .hourAndMinute)
                        .datePickerStyle(.wheel)
                        .labelsHidden()
                        .frame(maxWidth: .infinity)
                }

                // ── Activo ────────────────────────────────────────────────────
                if isEditing {
                    Section {
                        Toggle("Mensaje activo", isOn: $isActive)
                    }
                }

                // ── Eliminar mensaje ──────────────────────────────────────────
                if isEditing {
                    Section {
                        Button(role: .destructive) {
                            showingDeleteConfirm = true
                        } label: {
                            HStack {
                                Spacer()
                                Label("Eliminar mensaje", systemImage: "trash.fill")
                                    .font(.system(.callout, design: .rounded, weight: .semibold))
                                Spacer()
                            }
                        }
                    }
                }
            }
            .navigationTitle(isEditing ? "Editar mensaje" : "Nuevo mensaje")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    if isSaving {
                        ProgressView()
                    } else {
                        Button(isEditing ? "Guardar" : "Añadir", action: save)
                            .fontWeight(.semibold)
                    }
                }
            }
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
        .alert("Error al guardar", isPresented: Binding(
            get: { saveError != nil },
            set: { if !$0 { saveError = nil } }
        )) {
            Button("OK") { saveError = nil }
        } message: {
            Text(saveError ?? "")
        }
        .confirmationDialog(
            "¿Eliminar mensaje?",
            isPresented: $showingDeleteConfirm,
            titleVisibility: .visible
        ) {
            Button("Eliminar", role: .destructive) {
                Task {
                    if let msg = existing {
                        try? await waStore.deleteMessage(msg)
                    }
                    dismiss()
                }
            }
            Button("Cancelar", role: .cancel) {}
        } message: {
            Text("Esta acción no se puede deshacer.")
        }
        .sheet(isPresented: $showingAddRecipient) {
            AddRecipientSheet(
                recipientID:   $newRecipientID,
                recipientName: $newRecipientName,
                recipientType: $newRecipientType,
                isEditing:     recipientToEdit != nil
            ) { recipient in
                if let editing = recipientToEdit {
                    if let idx = recipients.firstIndex(where: { $0.id == editing.id }) {
                        recipients[idx] = recipient
                    }
                    recipientToEdit = nil
                } else {
                    if !recipients.contains(where: { $0.id == recipient.id }) {
                        recipients.append(recipient)
                    }
                }
            }
        }
        .sheet(isPresented: $showingContactPicker) {
            ContactPickerSheet(currentRecipients: recipients) { recipient in
                if !recipients.contains(where: { $0.id == recipient.id }) {
                    recipients.append(recipient)
                }
            }
        }
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private func validationLabel(_ msg: String) -> some View {
        Label(msg, systemImage: "exclamationmark.circle")
            .font(.caption)
            .foregroundStyle(.red)
    }

    private func save() {
        let cleanName = name.trimmingCharacters(in: .whitespaces)
        let cleanMsg  = messageText.trimmingCharacters(in: .whitespaces)
        guard !cleanName.isEmpty, !cleanMsg.isEmpty, !selectedDays.isEmpty, !recipients.isEmpty else {
            showValidation = true
            return
        }

        let comps    = Calendar.current.dateComponents([.hour, .minute], from: time)
        let timeStr  = String(format: "%02d:%02d", comps.hour ?? 0, comps.minute ?? 0)
        let jsDays   = selectedDays.map { $0.jsWeekday }.sorted()
        let schedule = WASchedule(days: jsDays, time: timeStr)

        isSaving = true
        Task {
            do {
                if isEditing, var updated = existing {
                    updated.name       = cleanName
                    updated.message    = cleanMsg
                    updated.recipients = recipients
                    updated.schedule   = schedule
                    updated.isActive   = isActive
                    try await waStore.updateMessage(updated)
                } else {
                    let input = WAMessageInput(
                        name:       cleanName,
                        recipients: recipients,
                        message:    cleanMsg,
                        schedule:   schedule,
                        isActive:   true
                    )
                    try await waStore.addMessage(input)
                }
                dismiss()
            } catch {
                saveError = error.localizedDescription
            }
            isSaving = false
        }
    }
}

// MARK: - Add Recipient Sheet (manual entry)

struct AddRecipientSheet: View {
    @Environment(\.dismiss) var dismiss
    @Binding var recipientID:   String
    @Binding var recipientName: String
    @Binding var recipientType: WARecipientType
    let isEditing: Bool
    let onAdd: (WARecipient) -> Void

    @State private var showValidation = false

    var body: some View {
        NavigationStack {
            Form {
                Section {
                    Picker("Tipo", selection: $recipientType) {
                        ForEach(WARecipientType.allCases, id: \.self) { t in
                            Label(t.label, systemImage: t.icon).tag(t)
                        }
                    }
                    .pickerStyle(.segmented)
                } header: {
                    Text("Tipo de destinatario")
                }

                Section {
                    TextField("Nombre para mostrar", text: $recipientName)
                    TextField(
                        recipientType == .contact
                            ? "Número con código de país (ej. 34612345678)"
                            : "ID numérico del grupo (ej. 120363XXXXXXXXX)",
                        text: $recipientID
                    )
                    .autocorrectionDisabled()
                    .textInputAutocapitalization(.never)
                    .keyboardType(recipientType == .contact ? .numberPad : .emailAddress)

                    if showValidation {
                        if recipientName.trimmingCharacters(in: .whitespaces).isEmpty {
                            Label("El nombre es obligatorio", systemImage: "exclamationmark.circle")
                                .font(.caption).foregroundStyle(.red)
                        }
                        if recipientID.trimmingCharacters(in: .whitespaces).isEmpty {
                            Label("El ID es obligatorio", systemImage: "exclamationmark.circle")
                                .font(.caption).foregroundStyle(.red)
                        }
                    }
                } header: {
                    Text("Datos")
                } footer: {
                    if recipientType == .contact {
                        Text("Solo escribe el número con código de país, sin +. El @c.us se añade automáticamente.")
                            .font(.caption)
                    } else {
                        Text("Pega solo el ID numérico del grupo. El @g.us se añade automáticamente.")
                            .font(.caption)
                    }
                }
            }
            .navigationTitle(isEditing ? "Editar destinatario" : "Añadir manualmente")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    Button(isEditing ? "Guardar" : "Añadir") {
                        let cleanName = recipientName.trimmingCharacters(in: .whitespaces)
                        var cleanID   = recipientID
                            .trimmingCharacters(in: .whitespaces)
                            .replacingOccurrences(of: "+", with: "")
                            .replacingOccurrences(of: " ", with: "")
                            .replacingOccurrences(of: "-", with: "")
                        guard !cleanName.isEmpty, !cleanID.isEmpty else {
                            showValidation = true
                            return
                        }
                        if !cleanID.contains("@") {
                            cleanID += recipientType == .group ? "@g.us" : "@c.us"
                        }
                        onAdd(WARecipient(id: cleanID, name: cleanName, type: recipientType))
                        dismiss()
                    }
                    .fontWeight(.semibold)
                }
            }
        }
        .presentationDetents([.medium])
        .presentationDragIndicator(.visible)
    }
}

// MARK: - Contact Picker Sheet (pick from saved contacts)

struct ContactPickerSheet: View {
    @EnvironmentObject var waStore: WAStore
    @Environment(\.dismiss) var dismiss
    let currentRecipients: [WARecipient]
    let onSelect: (WARecipient) -> Void

    @State private var addedInSession: Set<String> = []

    var savedContacts: [WAContact] { waStore.contacts.filter { $0.type == .contact } }
    var savedGroups: [WAContact]   { waStore.contacts.filter { $0.type == .group } }

    func isAlreadyAdded(_ c: WAContact) -> Bool {
        addedInSession.contains(c.waId) ||
        currentRecipients.contains(where: { $0.id == c.waId })
    }

    var body: some View {
        NavigationStack {
            Group {
                if waStore.contacts.isEmpty && !waStore.isLoading {
                    VStack(spacing: 16) {
                        Spacer()
                        Image(systemName: "person.2")
                            .font(.system(size: 60))
                            .foregroundStyle(.secondary)
                        Text("Sin contactos guardados")
                            .font(.system(.title3, design: .rounded, weight: .bold))
                        Text("Añade contactos en la sección Contactos (ícono de personas en la pantalla principal).")
                            .font(.callout)
                            .foregroundStyle(.secondary)
                            .multilineTextAlignment(.center)
                            .padding(.horizontal, 32)
                        Spacer()
                    }
                } else {
                    List {
                        if !savedContacts.isEmpty {
                            Section("Contactos") {
                                ForEach(savedContacts) { contact in
                                    ContactPickerRow(
                                        contact: contact,
                                        isAdded: isAlreadyAdded(contact)
                                    ) {
                                        onSelect(contact.asRecipient)
                                        addedInSession.insert(contact.waId)
                                    }
                                }
                            }
                        }
                        if !savedGroups.isEmpty {
                            Section("Grupos") {
                                ForEach(savedGroups) { contact in
                                    ContactPickerRow(
                                        contact: contact,
                                        isAdded: isAlreadyAdded(contact)
                                    ) {
                                        onSelect(contact.asRecipient)
                                        addedInSession.insert(contact.waId)
                                    }
                                }
                            }
                        }
                    }
                    .listStyle(.insetGrouped)
                }
            }
            .navigationTitle("Seleccionar destinatario")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .confirmationAction) {
                    Button("Cerrar") { dismiss() }
                }
            }
        }
        .presentationDetents([.medium, .large])
        .presentationDragIndicator(.visible)
    }
}

struct ContactPickerRow: View {
    let contact: WAContact
    let isAdded: Bool
    let onTap: () -> Void

    var body: some View {
        Button {
            if !isAdded { onTap() }
        } label: {
            HStack(spacing: 12) {
                ZStack {
                    RoundedRectangle(cornerRadius: 8, style: .continuous)
                        .fill(
                            contact.type == .group
                            ? LinearGradient(colors: [.blue.opacity(0.8), .blue], startPoint: .topLeading, endPoint: .bottomTrailing)
                            : LinearGradient(colors: [Color(hex: "#25D366"), Color(hex: "#128C7E")], startPoint: .topLeading, endPoint: .bottomTrailing)
                        )
                        .frame(width: 36, height: 36)
                    Image(systemName: contact.type.icon)
                        .font(.system(size: 16, weight: .semibold))
                        .foregroundStyle(.white)
                }
                VStack(alignment: .leading, spacing: 2) {
                    Text(contact.name)
                        .font(.system(.body, design: .rounded, weight: .medium))
                        .foregroundStyle(.primary)
                    Text(contact.waId)
                        .font(.caption)
                        .foregroundStyle(.secondary)
                        .lineLimit(1)
                }
                Spacer()
                if isAdded {
                    Image(systemName: "checkmark.circle.fill")
                        .foregroundStyle(Color(hex: "#25D366"))
                        .font(.title3)
                } else {
                    Image(systemName: "plus.circle.fill")
                        .foregroundStyle(Color(hex: "#25D366"))
                        .font(.title3)
                }
            }
            .padding(.vertical, 2)
        }
        .buttonStyle(.plain)
        .disabled(isAdded)
    }
}

// MARK: - Contacts Management View

struct WAContactsView: View {
    @EnvironmentObject var waStore: WAStore
    @Environment(\.dismiss) var dismiss

    @State private var showingAdd       = false
    @State private var contactToEdit: WAContact? = nil
    @State private var deleteError: String? = nil

    var contacts: [WAContact] { waStore.contacts.filter { $0.type == .contact } }
    var groups: [WAContact]   { waStore.contacts.filter { $0.type == .group } }

    var body: some View {
        NavigationStack {
            Group {
                if waStore.contacts.isEmpty && !waStore.isLoading {
                    WAContactsEmptyView()
                } else {
                    List {
                        if !contacts.isEmpty {
                            Section("Contactos") {
                                ForEach(contacts) { contact in
                                    WAContactRow(contact: contact)
                                        .contentShape(Rectangle())
                                        .onTapGesture { contactToEdit = contact }
                                        .swipeActions(edge: .trailing) {
                                            Button(role: .destructive) {
                                                Task {
                                                    do {
                                                        try await waStore.deleteContact(contact)
                                                    } catch {
                                                        deleteError = error.localizedDescription
                                                    }
                                                }
                                            } label: {
                                                Label("Eliminar", systemImage: "trash.fill")
                                            }
                                        }
                                        .swipeActions(edge: .leading) {
                                            Button {
                                                contactToEdit = contact
                                            } label: {
                                                Label("Editar", systemImage: "pencil")
                                            }
                                            .tint(.blue)
                                        }
                                }
                            }
                        }
                        if !groups.isEmpty {
                            Section("Grupos") {
                                ForEach(groups) { contact in
                                    WAContactRow(contact: contact)
                                        .contentShape(Rectangle())
                                        .onTapGesture { contactToEdit = contact }
                                        .swipeActions(edge: .trailing) {
                                            Button(role: .destructive) {
                                                Task {
                                                    do {
                                                        try await waStore.deleteContact(contact)
                                                    } catch {
                                                        deleteError = error.localizedDescription
                                                    }
                                                }
                                            } label: {
                                                Label("Eliminar", systemImage: "trash.fill")
                                            }
                                        }
                                        .swipeActions(edge: .leading) {
                                            Button {
                                                contactToEdit = contact
                                            } label: {
                                                Label("Editar", systemImage: "pencil")
                                            }
                                            .tint(.blue)
                                        }
                                }
                            }
                        }
                    }
                    .listStyle(.insetGrouped)
                }
            }
            .navigationTitle("Contactos y Grupos")
            .navigationBarTitleDisplayMode(.large)
            .toolbar {
                ToolbarItem(placement: .confirmationAction) {
                    Button { showingAdd = true } label: {
                        Image(systemName: "plus.circle.fill")
                            .font(.title3)
                            .foregroundStyle(Color(hex: "#25D366"))
                    }
                }
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cerrar") { dismiss() }
                }
            }
            .overlay {
                if waStore.isLoading && waStore.contacts.isEmpty {
                    ProgressView("Cargando...")
                        .padding()
                        .background(.regularMaterial, in: RoundedRectangle(cornerRadius: 12))
                }
            }
        }
        .sheet(isPresented: $showingAdd) {
            AddEditContactView(existing: nil)
        }
        .sheet(item: $contactToEdit) { contact in
            AddEditContactView(existing: contact)
        }
        .alert("Error", isPresented: Binding(
            get: { deleteError != nil },
            set: { if !$0 { deleteError = nil } }
        )) {
            Button("OK") { deleteError = nil }
        } message: {
            Text(deleteError ?? "")
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
    }
}

struct WAContactRow: View {
    let contact: WAContact

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                RoundedRectangle(cornerRadius: 10, style: .continuous)
                    .fill(
                        contact.type == .group
                        ? LinearGradient(colors: [.blue.opacity(0.8), .blue], startPoint: .topLeading, endPoint: .bottomTrailing)
                        : LinearGradient(colors: [Color(hex: "#25D366"), Color(hex: "#128C7E")], startPoint: .topLeading, endPoint: .bottomTrailing)
                    )
                    .frame(width: 40, height: 40)
                Image(systemName: contact.type.icon)
                    .font(.system(size: 17, weight: .semibold))
                    .foregroundStyle(.white)
            }
            VStack(alignment: .leading, spacing: 3) {
                Text(contact.name)
                    .font(.system(.body, design: .rounded, weight: .semibold))
                Text(contact.waId)
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .lineLimit(1)
            }
            Spacer()
            Text(contact.type.label)
                .font(.caption2.bold())
                .foregroundStyle(.white)
                .padding(.horizontal, 6)
                .padding(.vertical, 2)
                .background(
                    contact.type == .group ? Color.blue.gradient : Color(hex: "#25D366").gradient,
                    in: Capsule()
                )
        }
        .padding(.vertical, 2)
    }
}

// MARK: - Add / Edit Contact View

struct AddEditContactView: View {
    @EnvironmentObject var waStore: WAStore
    @Environment(\.dismiss) var dismiss

    let existing: WAContact?
    private var isEditing: Bool { existing != nil }

    @State private var name        = ""
    @State private var waId        = ""
    @State private var type        = WARecipientType.contact
    @State private var isSaving    = false
    @State private var saveError: String? = nil
    @State private var showValidation = false

    init(existing: WAContact?) {
        self.existing = existing
        if let c = existing {
            _name = State(initialValue: c.name)
            _waId = State(initialValue: c.waId)
            _type = State(initialValue: c.type)
        }
    }

    var body: some View {
        NavigationStack {
            Form {
                Section {
                    Picker("Tipo", selection: $type) {
                        ForEach(WARecipientType.allCases, id: \.self) { t in
                            Label(t.label, systemImage: t.icon).tag(t)
                        }
                    }
                    .pickerStyle(.segmented)
                } header: {
                    Text("Tipo")
                }

                Section {
                    TextField("Nombre para mostrar", text: $name)

                    TextField(
                        type == .contact
                            ? "Número con código de país (ej. 34612345678)"
                            : "ID numérico del grupo (ej. 120363XXXXXXXXX)",
                        text: $waId
                    )
                    .autocorrectionDisabled()
                    .textInputAutocapitalization(.never)
                    .keyboardType(type == .contact ? .numberPad : .emailAddress)

                    if showValidation {
                        if name.trimmingCharacters(in: .whitespaces).isEmpty {
                            Label("El nombre es obligatorio", systemImage: "exclamationmark.circle")
                                .font(.caption).foregroundStyle(.red)
                        }
                        if waId.trimmingCharacters(in: .whitespaces).isEmpty {
                            Label("El ID es obligatorio", systemImage: "exclamationmark.circle")
                                .font(.caption).foregroundStyle(.red)
                        }
                    }
                } header: {
                    Text("Datos")
                } footer: {
                    if type == .contact {
                        Text("Escribe el número con código de país, sin +. El @c.us se añade automáticamente.")
                            .font(.caption)
                    } else {
                        Text("Pega solo el ID numérico del grupo. El @g.us se añade automáticamente.")
                            .font(.caption)
                    }
                }
            }
            .navigationTitle(isEditing ? "Editar contacto" : "Nuevo contacto")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    if isSaving {
                        ProgressView()
                    } else {
                        Button(isEditing ? "Guardar" : "Añadir", action: save)
                            .fontWeight(.semibold)
                    }
                }
            }
        }
        .presentationDetents([.medium])
        .presentationDragIndicator(.visible)
        .alert("Error", isPresented: Binding(
            get: { saveError != nil },
            set: { if !$0 { saveError = nil } }
        )) {
            Button("OK") { saveError = nil }
        } message: {
            Text(saveError ?? "")
        }
    }

    private func save() {
        let cleanName = name.trimmingCharacters(in: .whitespaces)
        var cleanID   = waId
            .trimmingCharacters(in: .whitespaces)
            .replacingOccurrences(of: "+", with: "")
            .replacingOccurrences(of: " ", with: "")
            .replacingOccurrences(of: "-", with: "")

        guard !cleanName.isEmpty, !cleanID.isEmpty else {
            showValidation = true
            return
        }
        if !cleanID.contains("@") {
            cleanID += type == .group ? "@g.us" : "@c.us"
        }

        isSaving = true
        Task {
            do {
                if isEditing, var updated = existing {
                    updated.name = cleanName
                    updated.waId = cleanID
                    updated.type = type
                    try await waStore.updateContact(updated)
                } else {
                    let input = WAContactInput(waId: cleanID, name: cleanName, type: type)
                    try await waStore.addContact(input)
                }
                dismiss()
            } catch {
                saveError = error.localizedDescription
            }
            isSaving = false
        }
    }
}

// MARK: - Settings View

struct WASettingsView: View {
    @EnvironmentObject var waStore: WAStore
    @Environment(\.dismiss) var dismiss
    @State private var testResult: String? = nil
    @State private var isTesting = false

    var body: some View {
        NavigationStack {
            Form {
                Section {
                    TextField("URL del servidor", text: $waStore.serverURL)
                        .keyboardType(.URL)
                        .autocorrectionDisabled()
                        .textInputAutocapitalization(.never)
                } header: {
                    Text("Servidor Node.js")
                } footer: {
                    Text("URL completa del servidor. Ej: https://tudominio.com. Usada también por Recordatorios, Pedidos y Mantenimiento.")
                        .font(.caption)
                }

                Section {
                    Button {
                        isTesting = true
                        testResult = nil
                        Task {
                            await waStore.refresh()
                            switch waStore.waStatus.status {
                            case "READY":         testResult = "✓ Servidor OK — WhatsApp listo"
                            case "QR_READY":      testResult = "✓ Servidor OK — escanea el QR en la pestaña WhatsApp"
                            case "AUTHENTICATED": testResult = "✓ Servidor OK — autenticando WhatsApp..."
                            case "DISCONNECTED":  testResult = "✓ Servidor OK — WhatsApp no autenticado"
                            default:              testResult = "✗ No se puede contactar con el servidor. Revisa la URL."
                            }
                            isTesting = false
                        }
                    } label: {
                        HStack {
                            if isTesting {
                                ProgressView().scaleEffect(0.85)
                            } else {
                                Image(systemName: "antenna.radiowaves.left.and.right")
                            }
                            Text("Probar conexión")
                        }
                    }
                    .foregroundStyle(Color(hex: "#25D366"))

                    if let result = testResult {
                        Text(result)
                            .font(.callout)
                            .foregroundStyle(result.hasPrefix("✓") ? Color(hex: "#25D366") : .red)
                    }
                }

                Section {
                    VStack(alignment: .leading, spacing: 8) {
                        Text("Cómo iniciar el servidor:")
                            .font(.system(.callout, design: .rounded, weight: .semibold))
                        Text("""
                        1. Pide el codigo QR
                        2. Elimina la conexión anterior si existió
                        3. Escanea el codigo QR
                        4. Vuelve a la app y valida el estado
                        """)
                        .font(.caption)
                        .foregroundStyle(.secondary)
                    }
                    .padding(.vertical, 4)
                } header: {
                    Text("Instrucciones")
                }
            }
            .navigationTitle("Configuración WhatsApp")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .confirmationAction) {
                    Button("Cerrar") { dismiss() }
                }
            }
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
    }
}

// MARK: - Empty States

struct WAEmptyView: View {
    @Binding var showingAdd: Bool

    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#25D366"), Color(hex: "#128C7E")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 100, height: 100)
                Image(systemName: "message.fill")
                    .font(.system(size: 44))
                    .foregroundStyle(.white)
            }
            VStack(spacing: 8) {
                Text("Sin mensajes automáticos")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text("Crea mensajes programados que se enviarán automáticamente por WhatsApp")
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 40)
            }
            Button {
                showingAdd = true
            } label: {
                Label("Crear mensaje", systemImage: "plus.circle.fill")
                    .font(.system(.callout, design: .rounded, weight: .semibold))
                    .foregroundStyle(.white)
                    .padding(.horizontal, 24)
                    .padding(.vertical, 12)
                    .background(Color(hex: "#25D366").gradient, in: Capsule())
            }
            Spacer()
        }
    }
}

struct WAContactsEmptyView: View {
    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#25D366"), Color(hex: "#128C7E")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 100, height: 100)
                Image(systemName: "person.2.fill")
                    .font(.system(size: 44))
                    .foregroundStyle(.white)
            }
            VStack(spacing: 8) {
                Text("Sin contactos guardados")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text("Guarda contactos y grupos para usarlos rápidamente al crear mensajes")
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 40)
            }
            Spacer()
        }
    }
}
