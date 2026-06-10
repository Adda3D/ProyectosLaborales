import SwiftUI

// MARK: - Root

struct InventarioView: View {
    @EnvironmentObject var store: InventoryStore
    @State private var tab = 0
    @State private var showSettings = false

    var body: some View {
        VStack(spacing: 0) {
            Picker("", selection: $tab) {
                Text("Consulta").tag(0)
                Text("Historial").tag(1)
                Text("Usuarios").tag(2)
            }
            .pickerStyle(.segmented)
            .padding(.horizontal).padding(.vertical, 8)

            Group {
                switch tab {
                case 0:  InvConsultaView()
                case 1:  InvHistorialView()
                default: InvUsuariosView()
                }
            }
            .frame(maxWidth: .infinity, maxHeight: .infinity)
        }
        .navigationTitle("Inventario BK")
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showSettings = true } label: { Image(systemName: "gear") }
            }
        }
        .sheet(isPresented: $showSettings) { InvSettingsView() }
        .alert("Error", isPresented: Binding(
            get: { store.errorMessage != nil },
            set: { if !$0 { store.errorMessage = nil } }
        )) {
            Button("OK") { store.errorMessage = nil }
        } message: {
            Text(store.errorMessage ?? "")
        }
        .task {
            if !store.isLoggedIn { await store.login() }
            await store.fetchHistory()
        }
    }
}

// MARK: - Consulta (por día)

struct InvConsultaView: View {
    @EnvironmentObject var store: InventoryStore
    @State private var selectedDate = Date()
    @State private var snapshot: InvDaySnapshot?
    @State private var isLoading = false
    @State private var loadError: String?

    var body: some View {
        List {
            Section {
                DatePicker("Fecha", selection: $selectedDate, displayedComponents: .date)
                    .datePickerStyle(.compact)
                    .onChange(of: selectedDate) { _, _ in Task { await load() } }
            }

            if isLoading {
                Section {
                    HStack { Spacer(); ProgressView("Cargando…"); Spacer() }
                }
            } else if let err = loadError {
                Section {
                    Label(err, systemImage: "exclamationmark.triangle").foregroundStyle(.red)
                }
            } else if let snap = snapshot {
                if !snap.hasAny {
                    Section {
                        ContentUnavailableView("Sin registros", systemImage: "tray",
                            description: Text("No hay datos para este día."))
                    }
                } else {
                    InvDayHeaderSection(snap: snap)
                    InvComparisonSection(snap: snap)
                }
            }
        }
        .listStyle(.insetGrouped)
        .task { await load() }
    }

    private func load() async {
        let key = invDateKey(selectedDate)
        isLoading = true; loadError = nil
        do {
            snapshot = try await InvAPI.fetchDaySnapshot(date: key)
        } catch {
            loadError = error.localizedDescription
        }
        isLoading = false
    }
}

// MARK: - Day header (who submitted cierre and apertura)

struct InvDayHeaderSection: View {
    let snap: InvDaySnapshot

    var body: some View {
        Section("Registros del día") {
            if let c = snap.cierre {
                NavigationLink {
                    InvEntryDetailView(entry: c)
                } label: {
                    InvEntryHeaderRow(entry: c)
                }
            } else {
                Label("Sin registro de Cierre", systemImage: "exclamationmark.triangle.fill")
                    .foregroundStyle(.orange).font(.subheadline)
            }

            if let a = snap.apertura {
                NavigationLink {
                    InvEntryDetailView(entry: a)
                } label: {
                    InvEntryHeaderRow(entry: a)
                }
            } else {
                Label("Sin registro de Apertura", systemImage: "exclamationmark.triangle.fill")
                    .foregroundStyle(.orange).font(.subheadline)
            }
        }
    }
}

struct InvEntryHeaderRow: View {
    let entry: InvEntryDetail
    var body: some View {
        HStack(spacing: 10) {
            invMomentIcon(entry.moment)
            VStack(alignment: .leading, spacing: 2) {
                Text(entry.momentLabel).font(.subheadline.weight(.semibold))
                Text("\(entry.submittedTime) · \(entry.submittedBy)")
                    .font(.caption).foregroundStyle(.secondary)
            }
            Spacer()
            invBadge(entry.momentLabel, color: entry.moment == "apertura" ? .orange : .indigo)
        }
    }
}

// MARK: - Single entry detail (raw counts, no operations)

struct InvEntryDetailView: View {
    let entry: InvEntryDetail

    var body: some View {
        List {
            Section("Información") {
                LabeledContent("Momento", value: entry.momentLabel)
                LabeledContent("Registrado por", value: entry.submittedBy)
                LabeledContent("Hora", value: entry.submittedTime)
            }

            Section {
                // Column headers
                HStack {
                    Text("Producto").font(.caption.bold()).foregroundStyle(.secondary)
                        .frame(maxWidth: .infinity, alignment: .leading)
                    Text("U1").font(.caption.bold()).foregroundStyle(.secondary).frame(width: 36, alignment: .trailing)
                    Text("U2").font(.caption.bold()).foregroundStyle(.secondary).frame(width: 36, alignment: .trailing)
                    Text("Suel.").font(.caption.bold()).foregroundStyle(.secondary).frame(width: 40, alignment: .trailing)
                }
                .listRowBackground(Color(.systemGroupedBackground))

                ForEach(InvProduct.all, id: \.key) { product in
                    if let item = entry.item(for: product.key) {
                        InvRawCountRow(product: product, item: item)
                    } else {
                        HStack {
                            Text(product.name).font(.subheadline).foregroundStyle(.secondary)
                                .frame(maxWidth: .infinity, alignment: .leading)
                            Text("–").font(.caption).foregroundStyle(.secondary)
                        }
                    }
                }
            } header: {
                Text("Productos (U1 = \(entry.momentLabel == "Apertura" ? "unidad 1" : "unidad 1"), U2 = unidad 2, Suel. = sueltos)")
            }
        }
        .listStyle(.insetGrouped)
        .navigationTitle(entry.momentLabel)
        .navigationBarTitleDisplayMode(.inline)
    }
}

struct InvRawCountRow: View {
    let product: InvProduct
    let item: InvItem

    var body: some View {
        HStack {
            Text(product.name)
                .font(.subheadline)
                .lineLimit(1)
                .minimumScaleFactor(0.8)
                .frame(maxWidth: .infinity, alignment: .leading)
            Text(invFmt(item.unit1_count))
                .font(.subheadline.monospacedDigit())
                .frame(width: 36, alignment: .trailing)
            Text(product.unit2Name != nil ? invFmt(item.unit2_count) : "–")
                .font(.subheadline.monospacedDigit())
                .foregroundStyle(product.unit2Name != nil ? .primary : .secondary)
                .frame(width: 36, alignment: .trailing)
            Text(invFmt(item.loose_count))
                .font(.subheadline.monospacedDigit())
                .frame(width: 40, alignment: .trailing)
        }
        .padding(.vertical, 2)
    }
}

// MARK: - Comparison table (raw counts, no multiplication)

struct InvComparisonSection: View {
    let snap: InvDaySnapshot

    var body: some View {
        Section {
            ForEach(InvProduct.all, id: \.key) { product in
                InvProductCompareRow(product: product, snap: snap)
            }
        } header: {
            Text("Comparativa · Cierre vs Apertura")
        } footer: {
            Text("U1 / U2 / Sueltos — valores exactos sin operaciones")
                .font(.caption)
        }
    }
}

struct InvProductCompareRow: View {
    let product: InvProduct
    let snap: InvDaySnapshot

    var cierreItem: InvItem?   { snap.cierre?.item(for: product.key) }
    var aperturaItem: InvItem? { snap.apertura?.item(for: product.key) }

    var matches: Bool? {
        guard let c = cierreItem, let a = aperturaItem else { return nil }
        return c.unit1_count == a.unit1_count
            && c.unit2_count == a.unit2_count
            && c.loose_count == a.loose_count
    }

    func fmt(_ item: InvItem?) -> String {
        guard let i = item else { return "–" }
        if product.unit2Name != nil {
            return "\(invFmt(i.unit1_count))/\(invFmt(i.unit2_count))/\(invFmt(i.loose_count))"
        }
        return "\(invFmt(i.unit1_count))/\(invFmt(i.loose_count))"
    }

    var body: some View {
        VStack(alignment: .leading, spacing: 5) {
            HStack {
                Text(product.name)
                    .font(.subheadline.weight(.medium))
                    .frame(maxWidth: .infinity, alignment: .leading)
                if let m = matches {
                    Image(systemName: m ? "checkmark.circle.fill" : "exclamationmark.circle.fill")
                        .foregroundStyle(m ? .green : .red)
                        .font(.subheadline)
                }
            }
            HStack(spacing: 12) {
                Label(fmt(cierreItem), systemImage: "sunset.fill")
                    .font(.caption.monospacedDigit())
                    .foregroundStyle(.indigo)
                Label(fmt(aperturaItem), systemImage: "sunrise.fill")
                    .font(.caption.monospacedDigit())
                    .foregroundStyle(.orange)
            }
        }
        .padding(.vertical, 3)
    }
}

// MARK: - Historial

struct InvHistorialView: View {
    @EnvironmentObject var store: InventoryStore

    var body: some View {
        Group {
            if store.isLoadingHistory {
                ProgressView("Cargando historial…").frame(maxWidth: .infinity, maxHeight: .infinity)
            } else if store.historyDates.isEmpty {
                ContentUnavailableView("Sin historial", systemImage: "calendar.badge.clock",
                    description: Text("No se encontraron registros recientes."))
            } else {
                List {
                    ForEach(store.historyDates, id: \.self) { date in
                        NavigationLink {
                            InvDayFromHistoryView(date: date)
                        } label: {
                            InvHistorialRow(date: date,
                                           hasCierre: store.hasCierre(for: date),
                                           hasApertura: store.hasApertura(for: date))
                        }
                    }
                }
                .listStyle(.insetGrouped)
                .refreshable { await store.fetchHistory() }
            }
        }
    }
}

struct InvHistorialRow: View {
    let date: String
    let hasCierre: Bool
    let hasApertura: Bool

    var displayDate: String {
        let f = DateFormatter()
        f.locale = Locale(identifier: "es_ES")
        f.dateFormat = "yyyy-MM-dd"
        guard let d = f.date(from: date) else { return date }
        f.dateStyle = .medium
        f.timeStyle = .none
        return f.string(from: d)
    }

    var body: some View {
        HStack {
            VStack(alignment: .leading, spacing: 4) {
                Text(displayDate).font(.subheadline.weight(.semibold))
                HStack(spacing: 6) {
                    invStatusChip("Cierre",   active: hasCierre,   color: .indigo)
                    invStatusChip("Apertura", active: hasApertura, color: .orange)
                }
            }
            Spacer()
            if hasCierre && hasApertura {
                Image(systemName: "checkmark.circle.fill").foregroundStyle(.green)
            } else {
                Image(systemName: "exclamationmark.triangle.fill").foregroundStyle(.orange)
            }
        }
        .padding(.vertical, 4)
    }
}

// Navigate to consulta for a specific date
struct InvDayFromHistoryView: View {
    let date: String
    @State private var snapshot: InvDaySnapshot?
    @State private var isLoading = false
    @State private var error: String?

    var body: some View {
        List {
            if isLoading {
                Section { HStack { Spacer(); ProgressView(); Spacer() } }
            } else if let err = error {
                Section { Label(err, systemImage: "xmark.circle").foregroundStyle(.red) }
            } else if let snap = snapshot {
                InvDayHeaderSection(snap: snap)
                InvComparisonSection(snap: snap)
            }
        }
        .listStyle(.insetGrouped)
        .navigationTitle(snapshot?.displayDate ?? date)
        .navigationBarTitleDisplayMode(.inline)
        .task { await load() }
    }

    private func load() async {
        isLoading = true
        do { snapshot = try await InvAPI.fetchDaySnapshot(date: date) }
        catch { self.error = error.localizedDescription }
        isLoading = false
    }
}

// MARK: - Usuarios

struct InvUsuariosView: View {
    @EnvironmentObject var store: InventoryStore
    @State private var showAdd = false
    @State private var userToEdit: InvUser? = nil

    var body: some View {
        Group {
            if store.isLoadingUsers {
                ProgressView("Cargando usuarios…").frame(maxWidth: .infinity, maxHeight: .infinity)
            } else if store.users.isEmpty {
                ContentUnavailableView("Sin usuarios", systemImage: "person.slash",
                    description: Text("Pulsa + para crear el primer usuario."))
            } else {
                List {
                    ForEach(store.users) { user in
                        InvUserRow(user: user)
                            .contentShape(Rectangle())
                            .onTapGesture { userToEdit = user }
                            .swipeActions(edge: .trailing) {
                                Button(role: .destructive) {
                                    Task { try? await store.deleteUser(id: user.id) }
                                } label: {
                                    Label("Eliminar", systemImage: "trash.fill")
                                }
                            }
                    }
                }
                .listStyle(.insetGrouped)
                .refreshable { await store.fetchUsers() }
            }
        }
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showAdd = true } label: {
                    Image(systemName: "plus.circle.fill").font(.title3)
                }
            }
        }
        .sheet(isPresented: $showAdd) {
            AddEditUserView(existing: nil)
        }
        .sheet(item: $userToEdit) { user in
            AddEditUserView(existing: user)
        }
        .task { await store.fetchUsers() }
    }
}

struct InvUserRow: View {
    let user: InvUser

    var body: some View {
        HStack(spacing: 12) {
            ZStack {
                Circle()
                    .fill(user.role == "manager"
                          ? LinearGradient(colors: [.blue, .purple], startPoint: .topLeading, endPoint: .bottomTrailing)
                          : LinearGradient(colors: [.green, .teal], startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 38, height: 38)
                Text(String(user.username.prefix(1)).uppercased())
                    .font(.system(.callout, design: .rounded, weight: .bold))
                    .foregroundStyle(.white)
            }
            VStack(alignment: .leading, spacing: 3) {
                Text(user.username).font(.system(.body, design: .rounded, weight: .medium))
                HStack(spacing: 6) {
                    invBadge(user.roleLabel, color: user.role == "manager" ? .blue : .green)
                    if !user.isActive {
                        invBadge("Inactivo", color: .gray)
                    }
                }
            }
        }
        .padding(.vertical, 4)
        .opacity(user.isActive ? 1 : 0.5)
    }
}

// MARK: - Add/Edit User

struct AddEditUserView: View {
    @EnvironmentObject var store: InventoryStore
    @Environment(\.dismiss) var dismiss

    let existing: InvUser?
    var isEditing: Bool { existing != nil }

    @State private var username    = ""
    @State private var password    = ""
    @State private var role        = "operator"
    @State private var active      = true
    @State private var isSaving    = false
    @State private var saveError:  String? = nil
    @State private var showValidation = false

    init(existing: InvUser?) {
        self.existing = existing
        if let u = existing {
            _username = State(initialValue: u.username)
            _role     = State(initialValue: u.role)
            _active   = State(initialValue: u.isActive)
        }
    }

    var body: some View {
        NavigationStack {
            Form {
                Section("Datos del usuario") {
                    TextField("Nombre de usuario", text: $username)
                        .autocorrectionDisabled()
                        .textInputAutocapitalization(.never)
                    if showValidation && username.trimmingCharacters(in: .whitespaces).isEmpty {
                        Text("El nombre es obligatorio").font(.caption).foregroundStyle(.red)
                    }

                    SecureField(isEditing ? "Nueva contraseña (dejar vacío para no cambiar)" : "Contraseña", text: $password)
                    if showValidation && !isEditing && password.isEmpty {
                        Text("La contraseña es obligatoria").font(.caption).foregroundStyle(.red)
                    }
                }

                Section("Rol") {
                    Picker("Rol", selection: $role) {
                        Text("Operador (solo registrar)").tag("operator")
                        Text("Manager (registrar + consultar)").tag("manager")
                    }
                    .pickerStyle(.inline)
                    .labelsHidden()
                }

                if isEditing {
                    Section {
                        Toggle("Usuario activo", isOn: $active)
                    }
                }
            }
            .navigationTitle(isEditing ? "Editar usuario" : "Nuevo usuario")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    if isSaving { ProgressView() } else {
                        Button(isEditing ? "Guardar" : "Crear", action: save)
                            .fontWeight(.semibold)
                    }
                }
            }
            .alert("Error", isPresented: Binding(
                get: { saveError != nil },
                set: { if !$0 { saveError = nil } }
            )) {
                Button("OK") { saveError = nil }
            } message: {
                Text(saveError ?? "")
            }
        }
        .presentationDetents([.medium, .large])
        .presentationDragIndicator(.visible)
    }

    private func save() {
        let cleanName = username.trimmingCharacters(in: .whitespaces)
        guard !cleanName.isEmpty, isEditing || !password.isEmpty else {
            showValidation = true
            return
        }
        isSaving = true
        Task {
            do {
                if isEditing, let u = existing {
                    var fields: [String: Any] = ["role": role, "active": active ? 1 : 0]
                    if !cleanName.isEmpty { fields["username"] = cleanName }
                    if !password.isEmpty  { fields["password"] = password }
                    try await store.updateUser(id: u.id, fields: fields)
                } else {
                    try await store.createUser(username: cleanName, password: password, role: role)
                }
                dismiss()
            } catch {
                saveError = error.localizedDescription
            }
            isSaving = false
        }
    }
}

// MARK: - Settings

struct InvSettingsView: View {
    @EnvironmentObject var store: InventoryStore
    @Environment(\.dismiss) var dismiss
    @State private var testResult: String? = nil
    @State private var isTesting = false

    var body: some View {
        NavigationStack {
            Form {
                Section {
                    TextField("URL base", text: $store.baseURL)
                        .autocorrectionDisabled()
                        .textInputAutocapitalization(.never)
                        .keyboardType(.URL)
                } header: { Text("Servidor") }
                  footer: { Text("Ej: http://204.48.16.192:3000/api/inv") }

                Section("Credenciales de acceso") {
                    TextField("Usuario admin", text: $store.adminUsername)
                        .autocorrectionDisabled()
                        .textInputAutocapitalization(.never)
                    SecureField("Contraseña", text: $store.adminPassword)
                }

                Section {
                    Button {
                        isTesting = true; testResult = nil
                        InvTokenManager.shared.clearToken()
                        Task {
                            do {
                                _ = try await InvAPI.login()
                                testResult = "✓ Conexión correcta"
                            } catch {
                                testResult = "✗ \(error.localizedDescription)"
                            }
                            isTesting = false
                        }
                    } label: {
                        HStack {
                            if isTesting { ProgressView().scaleEffect(0.85) }
                            else { Image(systemName: "antenna.radiowaves.left.and.right") }
                            Text("Probar conexión")
                        }
                    }

                    if let r = testResult {
                        Text(r).font(.callout)
                            .foregroundStyle(r.hasPrefix("✓") ? .green : .red)
                    }
                }
            }
            .navigationTitle("Ajustes de Inventario")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .confirmationAction) {
                    Button("Listo") { dismiss() }
                }
            }
        }
        .presentationDetents([.large])
    }
}

// MARK: - Shared UI helpers

private func invMomentIcon(_ moment: String) -> some View {
    ZStack {
        RoundedRectangle(cornerRadius: 8, style: .continuous)
            .fill(moment == "apertura"
                  ? LinearGradient(colors: [.orange, .yellow], startPoint: .topLeading, endPoint: .bottomTrailing)
                  : LinearGradient(colors: [.indigo, .purple], startPoint: .topLeading, endPoint: .bottomTrailing))
            .frame(width: 34, height: 34)
        Image(systemName: moment == "apertura" ? "sunrise.fill" : "sunset.fill")
            .font(.system(size: 14, weight: .semibold))
            .foregroundStyle(.white)
    }
}

private func invBadge(_ text: String, color: Color) -> some View {
    Text(text)
        .font(.caption2.bold())
        .foregroundStyle(.white)
        .padding(.horizontal, 7)
        .padding(.vertical, 3)
        .background(color.gradient, in: Capsule())
}

private func invStatusChip(_ label: String, active: Bool, color: Color) -> some View {
    HStack(spacing: 3) {
        Image(systemName: active ? "checkmark.circle.fill" : "minus.circle")
            .font(.caption2)
        Text(label).font(.caption2)
    }
    .foregroundStyle(active ? color : Color.secondary)
}

private func invDateKey(_ date: Date) -> String {
    let f = DateFormatter()
    f.locale = Locale(identifier: "en_US_POSIX")
    f.dateFormat = "yyyy-MM-dd"
    return f.string(from: date)
}
