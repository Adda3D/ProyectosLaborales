import SwiftUI

// MARK: - Main Maintenance View

struct MaintenanceView: View {
    @EnvironmentObject var maintenanceStore: MaintenanceStore
    @State private var showingAdd      = false
    @State private var showingArchived = false
    @State private var itemToEdit: MaintenanceItem? = nil

    private var pending:  [MaintenanceItem] { maintenanceStore.pending }
    private var resolved: [MaintenanceItem] { maintenanceStore.resolvedNotArchived }

    var body: some View {
        Group {
            if pending.isEmpty && resolved.isEmpty {
                MaintenanceEmptyView()
            } else {
                List {
                    // PENDING — visually prominent
                    if !pending.isEmpty {
                        Section {
                            ForEach(pending) { item in
                                PendingMaintenanceRow(item: item)
                                    .contentShape(Rectangle())
                                    .onTapGesture { itemToEdit = item }
                                    .swipeActions(edge: .leading) {
                                        Button {
                                            maintenanceStore.resolve(item)
                                        } label: {
                                            Label("Solucionar", systemImage: "checkmark.circle.fill")
                                        }
                                        .tint(.green)
                                    }
                                    .swipeActions(edge: .trailing) {
                                        Button(role: .destructive) {
                                            maintenanceStore.delete(item)
                                        } label: {
                                            Label("Eliminar", systemImage: "trash.fill")
                                        }
                                        Button {
                                            maintenanceStore.archive(item)
                                        } label: {
                                            Label("Archivar", systemImage: "archivebox.fill")
                                        }
                                        .tint(.blue)
                                    }
                            }
                        } header: {
                            HStack(spacing: 6) {
                                Image(systemName: "exclamationmark.triangle.fill")
                                    .foregroundStyle(.red)
                                Text("Pendiente")
                                    .foregroundStyle(.red)
                                    .font(.headline)
                                Text("\(pending.count)")
                                    .font(.caption.bold())
                                    .foregroundStyle(.white)
                                    .padding(.horizontal, 8)
                                    .padding(.vertical, 2)
                                    .background(Color.red.gradient, in: Capsule())
                            }
                        }
                    }

                    // RESOLVED (not archived)
                    if !resolved.isEmpty {
                        Section("Solucionado") {
                            ForEach(resolved) { item in
                                SolvedMaintenanceRow(item: item)
                                    .swipeActions(edge: .trailing) {
                                        Button {
                                            maintenanceStore.archive(item)
                                        } label: {
                                            Label("Archivar", systemImage: "archivebox.fill")
                                        }
                                        .tint(.blue)
                                        Button(role: .destructive) {
                                            maintenanceStore.delete(item)
                                        } label: {
                                            Label("Eliminar", systemImage: "trash.fill")
                                        }
                                    }
                            }
                        }
                    }
                }
                .listStyle(.insetGrouped)
            }
        }
        .navigationTitle("Mantenimiento")
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showingAdd = true } label: {
                    Image(systemName: "plus.circle.fill")
                        .font(.title3)
                        .foregroundStyle(Color(hex: "#EF4444"))
                }
            }
            ToolbarItem(placement: .navigationBarLeading) {
                Button { showingArchived = true } label: {
                    HStack(spacing: 4) {
                        Image(systemName: "archivebox")
                        if !maintenanceStore.archived.isEmpty {
                            Text("\(maintenanceStore.archived.count)")
                                .font(.caption2.bold())
                        }
                    }
                    .foregroundStyle(.secondary)
                }
            }
        }
        .sheet(isPresented: $showingAdd) {
            AddMaintenanceView()
        }
        .sheet(item: $itemToEdit) { item in
            EditMaintenanceView(item: item)
        }
        .sheet(isPresented: $showingArchived) {
            ArchivedMaintenanceView()
        }
    }
}

// MARK: - Pending Row (visually prominent)

struct PendingMaintenanceRow: View {
    let item: MaintenanceItem

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#FCA5A5"), Color(hex: "#DC2626")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 48, height: 48)
                    .shadow(color: Color(hex: "#DC2626").opacity(0.4), radius: 8, x: 0, y: 4)
                Image(systemName: "wrench.and.screwdriver.fill")
                    .font(.system(size: 20, weight: .semibold))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 5) {
                Text(item.descriptionText)
                    .font(.system(.body, design: .rounded, weight: .semibold))
                    .foregroundStyle(.primary)
                    .lineLimit(3)
                HStack(spacing: 4) {
                    Image(systemName: "calendar")
                        .font(.caption2)
                    Text(item.createdAt.formatted(date: .abbreviated, time: .omitted))
                        .font(.caption)
                }
                .foregroundStyle(.secondary)
            }

            Spacer()

            // Pulsing badge
            Text("PENDIENTE")
                .font(.system(size: 9, weight: .heavy, design: .rounded))
                .foregroundStyle(.white)
                .padding(.horizontal, 6)
                .padding(.vertical, 3)
                .background(Color.red.gradient, in: RoundedRectangle(cornerRadius: 4))
        }
        .padding(.vertical, 6)
        .listRowBackground(
            RoundedRectangle(cornerRadius: 12)
                .fill(Color(hex: "#EF4444").opacity(0.07))
                .padding(.vertical, 2)
        )
    }
}

// MARK: - Solved Row

struct SolvedMaintenanceRow: View {
    let item: MaintenanceItem

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                RoundedRectangle(cornerRadius: 10, style: .continuous)
                    .fill(LinearGradient(
                        colors: [Color(hex: "#6EE7B7"), Color(hex: "#059669")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 40, height: 40)
                Image(systemName: "checkmark.seal.fill")
                    .font(.system(size: 17, weight: .semibold))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 4) {
                Text(item.descriptionText)
                    .font(.system(.body, design: .rounded, weight: .medium))
                    .foregroundStyle(.secondary)
                    .lineLimit(2)
                if let resolved = item.resolvedAt {
                    HStack(spacing: 4) {
                        Image(systemName: "checkmark.circle")
                            .font(.caption2)
                        Text("Resuelto \(resolved.formatted(date: .abbreviated, time: .omitted))")
                            .font(.caption)
                    }
                    .foregroundStyle(Color(hex: "#059669"))
                }
            }

            Spacer()
        }
        .padding(.vertical, 4)
    }
}

// MARK: - Add Maintenance View

struct AddMaintenanceView: View {
    @EnvironmentObject var maintenanceStore: MaintenanceStore
    @Environment(\.dismiss) var dismiss

    @State private var description  = ""
    @State private var showValidation = false

    var body: some View {
        NavigationStack {
            Form {
                Section {
                    ZStack(alignment: .topLeading) {
                        if description.isEmpty {
                            Text("Describe el problema de mantenimiento...")
                                .foregroundStyle(.secondary)
                                .padding(.top, 8)
                                .padding(.leading, 4)
                                .font(.system(size: 17))
                                .allowsHitTesting(false)
                        }
                        TextEditor(text: $description)
                            .frame(minHeight: 140)
                    }
                    if showValidation && description.trimmingCharacters(in: .whitespaces).isEmpty {
                        Label("La descripción es obligatoria", systemImage: "exclamationmark.circle")
                            .font(.caption)
                            .foregroundStyle(.red)
                    }
                } header: {
                    Text("Descripción")
                } footer: {
                    Text("Aparecerá como PENDIENTE hasta que lo marques como solucionado (desliza a la derecha).")
                        .font(.caption)
                }
            }
            .navigationTitle("Nueva incidencia")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    Button("Añadir") {
                        let clean = description.trimmingCharacters(in: .whitespaces)
                        guard !clean.isEmpty else { showValidation = true; return }
                        maintenanceStore.add(MaintenanceItem(descriptionText: clean))
                        dismiss()
                    }
                    .fontWeight(.semibold)
                }
            }
        }
        .presentationDetents([.medium, .large])
        .presentationDragIndicator(.visible)
    }
}

// MARK: - Edit Maintenance View

struct EditMaintenanceView: View {
    @EnvironmentObject var maintenanceStore: MaintenanceStore
    @Environment(\.dismiss) var dismiss

    let item: MaintenanceItem
    @State private var description: String
    @State private var status: MaintenanceStatus

    init(item: MaintenanceItem) {
        self.item   = item
        _description = State(initialValue: item.descriptionText)
        _status      = State(initialValue: item.status)
    }

    var body: some View {
        NavigationStack {
            Form {
                Section("Descripción") {
                    ZStack(alignment: .topLeading) {
                        TextEditor(text: $description)
                            .frame(minHeight: 100)
                    }
                }

                Section("Estado") {
                    Picker("Estado", selection: $status) {
                        ForEach(MaintenanceStatus.allCases) { s in
                            Label(s.rawValue, systemImage: s.icon).tag(s)
                        }
                    }
                    .pickerStyle(.segmented)
                }

                if status == .solved && item.status == .pending {
                    Section {
                        HStack(spacing: 8) {
                            Image(systemName: "archivebox")
                                .foregroundStyle(.blue)
                            Text("Al guardar se marcará la fecha de resolución.")
                                .font(.callout)
                                .foregroundStyle(.secondary)
                        }
                    }
                }
            }
            .navigationTitle("Editar incidencia")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    Button("Guardar") {
                        var updated = item
                        updated.descriptionText = description.trimmingCharacters(in: .whitespaces)
                        updated.status          = status
                        if status == .solved && item.status == .pending {
                            updated.resolvedAt = Date()
                        }
                        maintenanceStore.update(updated)
                        dismiss()
                    }
                    .fontWeight(.semibold)
                }
            }
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
    }
}

// MARK: - Archived Maintenance View

struct ArchivedMaintenanceView: View {
    @EnvironmentObject var maintenanceStore: MaintenanceStore
    @Environment(\.dismiss) var dismiss

    var body: some View {
        NavigationStack {
            Group {
                if maintenanceStore.archived.isEmpty {
                    VStack(spacing: 16) {
                        Spacer()
                        Image(systemName: "archivebox")
                            .font(.system(size: 60))
                            .foregroundStyle(.secondary)
                        Text("Sin elementos archivados")
                            .font(.system(.title3, design: .rounded, weight: .bold))
                            .foregroundStyle(.secondary)
                        Spacer()
                    }
                } else {
                    List {
                        ForEach(maintenanceStore.archived) { item in
                            ArchivedMaintenanceRow(item: item)
                                .swipeActions(edge: .trailing) {
                                    Button(role: .destructive) {
                                        maintenanceStore.delete(item)
                                    } label: {
                                        Label("Eliminar", systemImage: "trash.fill")
                                    }
                                }
                        }
                    }
                    .listStyle(.insetGrouped)
                }
            }
            .navigationTitle("Archivados")
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

// MARK: - Archived Row

struct ArchivedMaintenanceRow: View {
    let item: MaintenanceItem

    var body: some View {
        HStack(spacing: 12) {
            Image(systemName: "archivebox.fill")
                .font(.title3)
                .foregroundStyle(.secondary)

            VStack(alignment: .leading, spacing: 4) {
                Text(item.descriptionText)
                    .font(.system(.body, design: .rounded))
                    .foregroundStyle(.secondary)
                    .lineLimit(2)
                if let resolved = item.resolvedAt {
                    Text("Resuelto \(resolved.formatted(date: .abbreviated, time: .omitted))")
                        .font(.caption)
                        .foregroundStyle(.tertiary)
                }
            }
        }
        .padding(.vertical, 4)
    }
}

// MARK: - Empty State

struct MaintenanceEmptyView: View {
    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#FCA5A5"), Color(hex: "#DC2626")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 100, height: 100)
                Image(systemName: "wrench.and.screwdriver.fill")
                    .font(.system(size: 44))
                    .foregroundStyle(.white)
            }
            VStack(spacing: 8) {
                Text("Sin incidencias")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text("Registra incidencias de mantenimiento con el botón +")
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 40)
            }
            Spacer()
        }
    }
}
