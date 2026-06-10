import SwiftUI

struct AddEditReminderView: View {
    @EnvironmentObject var store: ReminderStore
    @EnvironmentObject var notificationManager: NotificationManager
    @Environment(\.dismiss) var dismiss

    let existingReminder: Reminder?

    @State private var title: String              = ""
    @State private var notes: String              = ""
    @State private var date: Date                 = defaultDate()
    @State private var category: ReminderCategory = .empleados
    @State private var advanceMinutes: Int        = 10
    @State private var showValidationError        = false

    private var isEditing: Bool { existingReminder != nil }

    let advanceOptions: [(label: String, minutes: Int)] = [
        ("5 minutos",  5),
        ("10 minutos", 10),
        ("15 minutos", 15),
        ("30 minutos", 30),
        ("1 hora",     60),
        ("2 horas",    120),
        ("1 dia",      1440)
    ]

    init(existingReminder: Reminder?) {
        self.existingReminder = existingReminder
        if let r = existingReminder {
            _title          = State(initialValue: r.title)
            _notes          = State(initialValue: r.notes)
            _date           = State(initialValue: r.date)
            _category       = State(initialValue: r.category)
            _advanceMinutes = State(initialValue: r.advanceMinutes)
        }
    }

    var body: some View {
        NavigationStack {
            Form {
                // Titulo y notas
                Section("Informacion") {
                    TextField("Titulo del recordatorio", text: $title)
                        .font(.system(size: 17, weight: .regular, design: .rounded))

                    if showValidationError && title.trimmingCharacters(in: .whitespaces).isEmpty {
                        Label("El titulo es obligatorio", systemImage: "exclamationmark.circle")
                            .font(.system(size: 12, weight: .regular, design: .default))
                            .foregroundStyle(.red)
                    }

                    ZStack(alignment: .topLeading) {
                        if notes.isEmpty {
                            Text("Notas (opcional)...")
                                .foregroundStyle(.secondary)
                                .padding(.top, 8)
                                .padding(.leading, 4)
                                .font(.system(size: 17, weight: .regular, design: .default))
                        }
                        TextEditor(text: $notes)
                            .frame(minHeight: 80)
                            .font(.system(size: 17, weight: .regular, design: .default))
                    }
                }

                // Categoria
                Section("Categoria") {
                    HStack(spacing: 0) {
                        ForEach(ReminderCategory.allCases) { cat in
                            CategoryPillButton(cat: cat, isSelected: category == cat) {
                                withAnimation(.spring(response: 0.3)) {
                                    category = cat
                                }
                            }
                        }
                    }
                    .listRowInsets(EdgeInsets(top: 12, leading: 12, bottom: 12, trailing: 12))
                }

                // Fecha y hora
                Section("Fecha y hora") {
                    DatePicker("Cuando",
                               selection: $date,
                               in: Date()...,
                               displayedComponents: [.date, .hourAndMinute])
                        .datePickerStyle(.graphical)
                        .tint(category.color)
                }

                // Anticipacion
                Section {
                    Picker("Recordar", selection: $advanceMinutes) {
                        ForEach(advanceOptions, id: \.minutes) { option in
                            Text(option.label).tag(option.minutes)
                        }
                    }
                    .pickerStyle(.menu)
                    .tint(category.color)
                } header: {
                    Text("Notificacion anticipada")
                } footer: {
                    HStack(spacing: 6) {
                        Image(systemName: "bell.badge")
                        Text("Recibiras una notificacion \(advanceLabel) de la fecha indicada.")
                    }
                    .font(.system(size: 13, weight: .regular, design: .default))
                    .foregroundStyle(.secondary)
                }

                // Vista previa
                Section("Vista previa") {
                    ReminderPreviewRow(
                        title: title.isEmpty ? "Sin titulo" : title,
                        notes: notes,
                        date: date,
                        category: category,
                        advance: advanceLabel
                    )
                }
            }
            .navigationTitle(isEditing ? "Editar recordatorio" : "Nuevo recordatorio")
            .navigationBarTitleDisplayMode(.inline)
            .toolbar {
                ToolbarItem(placement: .cancellationAction) {
                    Button("Cancelar") { dismiss() }
                }
                ToolbarItem(placement: .confirmationAction) {
                    Button(isEditing ? "Guardar" : "Anadir") {
                        saveReminder()
                    }
                    .fontWeight(.semibold)
                    .foregroundStyle(category.color)
                }
            }
        }
        .presentationDetents([.large])
        .presentationDragIndicator(.visible)
    }

    private var advanceLabel: String {
        advanceOptions.first { $0.minutes == advanceMinutes }?.label ?? "\(advanceMinutes) min"
    }

    private func saveReminder() {
        let clean = title.trimmingCharacters(in: .whitespaces)
        guard !clean.isEmpty else {
            showValidationError = true
            return
        }

        if isEditing, let old = existingReminder {
            var updated            = old
            updated.title          = clean
            updated.notes          = notes
            updated.date           = date
            updated.category       = category
            updated.advanceMinutes = advanceMinutes
            store.update(updated)
            notificationManager.reschedule(old: old, new: updated)
        } else {
            var nuevo            = Reminder(title: clean, date: date, category: category)
            nuevo.notes          = notes
            nuevo.advanceMinutes = advanceMinutes
            store.add(nuevo)
            notificationManager.schedule(reminder: nuevo)
        }
        dismiss()
    }

    private static func defaultDate() -> Date {
        Calendar.current.date(byAdding: .hour, value: 1, to: Date()) ?? Date()
    }
}

// MARK: - Category Pill Button

struct CategoryPillButton: View {
    let cat: ReminderCategory
    let isSelected: Bool
    let action: () -> Void

    var body: some View {
        Button(action: action) {
            VStack(spacing: 8) {
                ZStack {
                    RoundedRectangle(cornerRadius: 14, style: .continuous)
                        .fill(isSelected ? cat.gradient : LinearGradient(
                            colors: [Color(.systemGray5), Color(.systemGray4)],
                            startPoint: .topLeading, endPoint: .bottomTrailing))
                        .frame(width: 56, height: 56)
                        .shadow(color: isSelected ? cat.color.opacity(0.4) : .clear,
                                radius: 8, x: 0, y: 4)

                    Image(systemName: cat.icon)
                        .font(.system(size: 22, weight: .semibold, design: .default))
                        .foregroundStyle(isSelected ? .white : .secondary)
                }

                Text(cat.rawValue)
                    .font(.system(size: 11, weight: isSelected ? .bold : .regular, design: .rounded))
                    .foregroundStyle(isSelected ? cat.color : .secondary)
                    .lineLimit(1)
                    .minimumScaleFactor(0.8)
            }
            .frame(maxWidth: .infinity)
        }
        .buttonStyle(.plain)
        .animation(.spring(response: 0.3), value: isSelected)
    }
}

// MARK: - Preview Row

struct ReminderPreviewRow: View {
    let title: String
    let notes: String
    let date: Date
    let category: ReminderCategory
    let advance: String

    var body: some View {
        HStack(spacing: 14) {
            ZStack {
                RoundedRectangle(cornerRadius: 10, style: .continuous)
                    .fill(category.gradient)
                    .frame(width: 40, height: 40)
                Image(systemName: category.icon)
                    .font(.system(size: 18, weight: .semibold, design: .default))
                    .foregroundStyle(.white)
            }

            VStack(alignment: .leading, spacing: 3) {
                Text(title)
                    .font(.system(size: 17, weight: .semibold, design: .rounded))
                    .foregroundStyle(.primary)
                if !notes.isEmpty {
                    Text(notes)
                        .font(.system(size: 13, weight: .regular, design: .default))
                        .foregroundStyle(.secondary)
                        .lineLimit(1)
                }
                HStack(spacing: 4) {
                    Image(systemName: "clock")
                        .font(.system(size: 11, weight: .regular, design: .default))
                    Text(date.formatted(date: .abbreviated, time: .shortened))
                        .font(.system(size: 12, weight: .regular, design: .default))
                    Text("-")
                        .font(.system(size: 12, weight: .regular, design: .default))
                    Image(systemName: "bell")
                        .font(.system(size: 11, weight: .regular, design: .default))
                    Text("\(advance) antes")
                        .font(.system(size: 12, weight: .regular, design: .default))
                }
                .foregroundStyle(.secondary)
            }
        }
        .padding(.vertical, 4)
    }
}
