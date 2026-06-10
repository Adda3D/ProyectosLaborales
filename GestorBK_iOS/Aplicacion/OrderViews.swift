import SwiftUI

// MARK: - Main Orders View

struct OrdersView: View {
    @EnvironmentObject var orderStore: OrderStore
    @EnvironmentObject var notificationManager: NotificationManager
    @State private var showingAdd = false
    @State private var showingSettings = false
    @State private var orderToEdit: Order? = nil

    var body: some View {
        Group {
            if orderStore.orders.isEmpty {
                OrdersEmptyView()
            } else {
                List {
                    // Pending confirmation section — shown only when needed
                    let pending = orderStore.pendingConfirmationOrders
                    if !pending.isEmpty {
                        Section {
                            ForEach(pending) { order in
                                PendingConfirmationRow(order: order)
                            }
                        } header: {
                            HStack(spacing: 6) {
                                Image(systemName: "exclamationmark.triangle.fill")
                                    .foregroundStyle(.orange)
                                Text("Confirmar llegada")
                                    .foregroundStyle(.orange)
                                    .font(.headline)
                                Text("\(pending.count)")
                                    .font(.caption.bold())
                                    .foregroundStyle(.white)
                                    .padding(.horizontal, 8)
                                    .padding(.vertical, 2)
                                    .background(Color.orange.gradient, in: Capsule())
                            }
                        }
                    }

                    Section("Pedidos programados") {
                        ForEach(orderStore.orders) { order in
                            OrderRowView(order: order)
                                .contentShape(Rectangle())
                                .onTapGesture { orderToEdit = order }
                                .swipeActions(edge: .trailing) {
                                    Button(role: .destructive) {
                                        notificationManager.cancelOrderNotifications(order: order)
                                        orderStore.delete(order)
                                    } label: {
                                        Label("Eliminar", systemImage: "trash.fill")
                                    }
                                }
                        }
                    }
                }
                .listStyle(.insetGrouped)
            }
        }
        .navigationTitle("Pedidos")
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showingAdd = true } label: {
                    Image(systemName: "plus.circle.fill")
                        .font(.title3)
                        .foregroundStyle(Color(hex: "#059669"))
                }
            }
            ToolbarItem(placement: .navigationBarLeading) {
                Button { showingSettings = true } label: {
                    Image(systemName: "gearshape.fill")
                        .font(.body)
                        .foregroundStyle(.secondary)
                }
            }
        }
        .sheet(isPresented: $showingAdd) {
            AddEditOrderView(existingOrder: nil)
        }
        .sheet(item: $orderToEdit) { order in
            AddEditOrderView(existingOrder: order)
        }
        .sheet(isPresented: $showingSettings) {
            SupplierSettingsView()
        }
    }
}

// MARK: - Pending Confirmation Row

struct PendingConfirmationRow: View {
    @EnvironmentObject var orderStore: OrderStore
    @EnvironmentObject var notificationManager: NotificationManager
    let order: Order

    var supplierName: String {
        orderStore.supplier(for: order.supplierID)?.name ?? "Proveedor"
    }

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#FB923C"), Color(hex: "#DC2626")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 48, height: 48)
                Image(systemName: "shippingbox.fill")
                    .font(.system(size: 22, weight: .semibold))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 4) {
                Text(supplierName)
                    .font(.system(.body, design: .rounded, weight: .bold))
                Text("Programado a las \(order.timeString)")
                    .font(.caption)
                    .foregroundStyle(.secondary)
            }

            Spacer()

            Button {
                orderStore.confirmToday(order: order)
                notificationManager.cancelOrderFollowUpsForToday(order: order)
            } label: {
                Text("Confirmar")
                    .font(.system(.callout, design: .rounded, weight: .semibold))
                    .foregroundStyle(.white)
                    .padding(.horizontal, 14)
                    .padding(.vertical, 8)
                    .background(Color(hex: "#10B981").gradient, in: RoundedRectangle(cornerRadius: 10))
            }
            .buttonStyle(.plain)
        }
        .padding(.vertical, 4)
    }
}

// MARK: - Order Row View

struct OrderRowView: View {
    @EnvironmentObject var orderStore: OrderStore
    @EnvironmentObject var notificationManager: NotificationManager
    let order: Order

    var supplierName: String {
        orderStore.supplier(for: order.supplierID)?.name ?? "Proveedor desconocido"
    }

    var daysText: String {
        Weekday.weekOrder
            .filter { order.recurringDays.contains($0) }
            .map { $0.name }
            .joined(separator: ", ")
    }

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                RoundedRectangle(cornerRadius: 10, style: .continuous)
                    .fill(LinearGradient(
                        colors: [Color(hex: "#34D399"), Color(hex: "#059669")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 40, height: 40)
                Image(systemName: "shippingbox.fill")
                    .font(.system(size: 17, weight: .semibold))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 4) {
                Text(supplierName)
                    .font(.system(.body, design: .rounded, weight: .semibold))
                HStack(spacing: 4) {
                    Image(systemName: "clock")
                        .font(.caption2)
                    Text(order.timeString)
                        .font(.caption)
                    if !order.recurringDays.isEmpty {
                        Text("·")
                            .font(.caption)
                        Text(daysText)
                            .font(.caption)
                    }
                }
                .foregroundStyle(.secondary)
            }

            Spacer()

            Toggle("", isOn: Binding(
                get: { order.isActive },
                set: { newVal in
                    var updated = order
                    updated.isActive = newVal
                    orderStore.update(updated)
                    if newVal {
                        notificationManager.scheduleOrderNotifications(
                            order: updated, suppliers: orderStore.suppliers)
                    } else {
                        notificationManager.cancelOrderNotifications(order: updated)
                    }
                }
            ))
            .labelsHidden()
        }
        .padding(.vertical, 4)
        .opacity(order.isActive ? 1 : 0.5)
    }
}

// MARK: - Weekday Picker

struct WeekdayPickerView: View {
    @Binding var selectedDays: Set<Weekday>

    var body: some View {
        HStack(spacing: 6) {
            ForEach(Weekday.weekOrder) { day in
                let isSelected = selectedDays.contains(day)
                Button {
                    withAnimation(.spring(response: 0.25)) {
                        if isSelected { selectedDays.remove(day) }
                        else           { selectedDays.insert(day) }
                    }
                } label: {
                    Text(day.shortName)
                        .font(.system(.footnote, design: .rounded, weight: isSelected ? .bold : .regular))
                        .foregroundStyle(isSelected ? .white : .primary)
                        .frame(width: 38, height: 38)
                        .background(
                            Circle().fill(
                                isSelected
                                ? LinearGradient(colors: [Color(hex: "#34D399"), Color(hex: "#059669")],
                                                 startPoint: .topLeading, endPoint: .bottomTrailing)
                                : LinearGradient(colors: [Color(.systemGray5), Color(.systemGray4)],
                                                 startPoint: .topLeading, endPoint: .bottomTrailing)
                            )
                        )
                }
                .buttonStyle(.plain)
            }
        }
        .frame(maxWidth: .infinity)
    }
}

// MARK: - Add / Edit Order View

struct AddEditOrderView: View {
    @EnvironmentObject var orderStore: OrderStore
    @EnvironmentObject var notificationManager: NotificationManager
    @Environment(\.dismiss) var dismiss

    let existingOrder: Order?
    private var isEditing: Bool { existingOrder != nil }

    @State private var selectedSupplierID: String? = nil
    @State private var selectedDays: Set<Weekday> = []
    @State private var time: Date = {
        Calendar.current.date(bySettingHour: 8, minute: 0, second: 0, of: Date()) ?? Date()
    }()
    @State private var isActive: Bool = true
    @State private var showValidation = false

    init(existingOrder: Order?) {
        self.existingOrder = existingOrder
        if let o = existingOrder {
            _selectedSupplierID = State(initialValue: o.supplierID)
            _selectedDays       = State(initialValue: Set(o.recurringDays))
            let comps = DateComponents(hour: o.hour, minute: o.minute)
            _time     = State(initialValue: Calendar.current.date(from: comps) ?? Date())
            _isActive = State(initialValue: o.isActive)
        }
    }

    var body: some View {
        NavigationStack {
            Form {
                // Supplier
                Section("Proveedor") {
                    if orderStore.suppliers.isEmpty {
                        Text("No hay proveedores configurados. Añádelos en Configuración.")
                            .foregroundStyle(.secondary)
                            .font(.callout)
                    } else {
                        Picker("Proveedor", selection: $selectedSupplierID) {
                            Text("Seleccionar...").tag(Optional<String>(nil))
                            ForEach(orderStore.suppliers) { s in
                                Text(s.name).tag(Optional(s.id))
                            }
                        }
                        .pickerStyle(.menu)
                    }
                    if showValidation && selectedSupplierID == nil {
                        validationLabel("Selecciona un proveedor")
                    }
                }

                // Time
                Section("Hora del pedido") {
                    DatePicker("Hora", selection: $time, displayedComponents: .hourAndMinute)
                        .datePickerStyle(.wheel)
                        .labelsHidden()
                        .frame(maxWidth: .infinity)
                }

                // Days
                Section {
                    WeekdayPickerView(selectedDays: $selectedDays)
                        .listRowInsets(EdgeInsets(top: 12, leading: 12, bottom: 12, trailing: 12))
                    if showValidation && selectedDays.isEmpty {
                        validationLabel("Selecciona al menos un día")
                    }
                } header: {
                    Text("Días recurrentes")
                } footer: {
                    Text("La alarma sonará cada semana los días elegidos. Si no confirmas la llegada, volverá a sonar cada 30 minutos automáticamente.")
                        .font(.caption)
                }

                // Active (edit only)
                if isEditing {
                    Section {
                        Toggle("Pedido activo", isOn: $isActive)
                    }
                }
            }
            .navigationTitle(isEditing ? "Editar pedido" : "Nuevo pedido")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    Button(isEditing ? "Guardar" : "Añadir", action: save)
                        .fontWeight(.semibold)
                }
            }
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
        .onAppear {
            if selectedSupplierID == nil, let first = orderStore.suppliers.first {
                selectedSupplierID = first.id
            }
        }
    }

    private func validationLabel(_ msg: String) -> some View {
        Label(msg, systemImage: "exclamationmark.circle")
            .font(.caption)
            .foregroundStyle(.red)
    }

    private func save() {
        guard selectedSupplierID != nil, !selectedDays.isEmpty else {
            showValidation = true
            return
        }
        let comps = Calendar.current.dateComponents([.hour, .minute], from: time)
        let h = comps.hour ?? 8
        let m = comps.minute ?? 0

        if isEditing, var updated = existingOrder {
            notificationManager.cancelOrderNotifications(order: updated)
            updated.supplierID    = selectedSupplierID!
            updated.recurringDays = Array(selectedDays)
            updated.hour          = h
            updated.minute        = m
            updated.isActive      = isActive
            orderStore.update(updated)
            if updated.isActive {
                notificationManager.scheduleOrderNotifications(
                    order: updated, suppliers: orderStore.suppliers)
            }
        } else {
            let nuevo = Order(
                supplierID:    selectedSupplierID!,
                recurringDays: Array(selectedDays),
                hour:          h,
                minute:        m
            )
            orderStore.add(nuevo)
            notificationManager.scheduleOrderNotifications(
                order: nuevo, suppliers: orderStore.suppliers)
        }
        dismiss()
    }
}

// MARK: - Supplier Settings View

struct SupplierSettingsView: View {
    @EnvironmentObject var orderStore: OrderStore
    @Environment(\.dismiss) var dismiss

    @State private var showingAdd    = false
    @State private var supplierToEdit: Supplier? = nil
    @State private var editingName   = ""

    var body: some View {
        NavigationStack {
            List {
                Section {
                    ForEach(orderStore.suppliers) { supplier in
                        HStack {
                            Text(supplier.name)
                                .font(.system(.body, design: .rounded, weight: .medium))
                            Spacer()
                            Button {
                                supplierToEdit = supplier
                                editingName    = supplier.name
                            } label: {
                                Image(systemName: "pencil")
                                    .foregroundStyle(.blue)
                            }
                            .buttonStyle(.plain)
                        }
                        .swipeActions(edge: .trailing) {
                            Button(role: .destructive) {
                                orderStore.deleteSupplier(supplier)
                            } label: {
                                Label("Eliminar", systemImage: "trash.fill")
                            }
                        }
                    }
                } header: {
                    Text("Proveedores")
                } footer: {
                    Text("Puedes añadir, renombrar o eliminar proveedores. Los pedidos existentes no se borran al eliminar un proveedor.")
                        .font(.caption)
                }
            }
            .listStyle(.insetGrouped)
            .navigationTitle("Configurar proveedores")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cerrar") { dismiss() }
                }
                ToolbarItem(placement: .primaryAction) {
                    Button {
                        editingName = ""
                        showingAdd  = true
                    } label: {
                        Image(systemName: "plus")
                    }
                }
            }
            .alert("Nuevo proveedor", isPresented: $showingAdd) {
                TextField("Nombre del proveedor", text: $editingName)
                Button("Añadir") {
                    let n = editingName.trimmingCharacters(in: .whitespaces)
                    if !n.isEmpty { orderStore.addSupplier(Supplier(name: n)) }
                }
                Button("Cancelar", role: .cancel) {}
            }
            .alert(
                "Editar proveedor",
                isPresented: Binding(
                    get: { supplierToEdit != nil },
                    set: { if !$0 { supplierToEdit = nil } }
                )
            ) {
                TextField("Nombre", text: $editingName)
                Button("Guardar") {
                    if var s = supplierToEdit {
                        let n = editingName.trimmingCharacters(in: .whitespaces)
                        if !n.isEmpty { s.name = n; orderStore.updateSupplier(s) }
                    }
                    supplierToEdit = nil
                }
                Button("Cancelar", role: .cancel) { supplierToEdit = nil }
            }
        }
        .presentationDetents([.medium, .large])
        .presentationDragIndicator(.visible)
    }
}

// MARK: - Empty State

struct OrdersEmptyView: View {
    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            ZStack {
                Circle()
                    .fill(LinearGradient(
                        colors: [Color(hex: "#34D399"), Color(hex: "#059669")],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 100, height: 100)
                Image(systemName: "shippingbox.fill")
                    .font(.system(size: 44))
                    .foregroundStyle(.white)
            }
            VStack(spacing: 8) {
                Text("Sin pedidos")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text("Añade tu primer pedido con el botón +")
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 40)
            }
            Spacer()
        }
    }
}
