import SwiftUI

// MARK: - All Reminders View

struct AllRemindersView: View {
    @EnvironmentObject var store: ReminderStore
    @Binding var showingAdd: Bool

    var body: some View {
        Group {
            if store.reminders.isEmpty {
                EmptyStateView(category: nil)
            } else {
                List {
                    ForEach(ReminderCategory.allCases) { category in
                        let items = store.upcoming(for: category)
                        if !items.isEmpty {
                            Section {
                                ForEach(items) { reminder in
                                    ReminderRowView(reminder: reminder)
                                }
                            } header: {
                                CategorySectionHeader(category: category)
                            }
                        }
                    }
                }
                .listStyle(.insetGrouped)
            }
        }
        .navigationTitle("Todos")
        .toolbar { addButton }
    }

    @ToolbarContentBuilder
    var addButton: some ToolbarContent {
        ToolbarItem(placement: .primaryAction) {
            Button { showingAdd = true } label: {
                Image(systemName: "plus.circle.fill")
                    .font(.title3)
            }
        }
    }
}

// MARK: - Category List View

struct ReminderListView: View {
    @EnvironmentObject var store: ReminderStore
    @EnvironmentObject var notificationManager: NotificationManager
    let category: ReminderCategory
    @Binding var showingAdd: Bool

    @State private var showCompleted = false

    var upcoming: [Reminder] { store.upcoming(for: category) }
    var past: [Reminder]     { store.past(for: category) }

    var body: some View {
        Group {
            if upcoming.isEmpty && past.isEmpty {
                EmptyStateView(category: category)
            } else {
                List {
                    if !upcoming.isEmpty {
                        Section("Próximos") {
                            ForEach(upcoming) { reminder in
                                ReminderRowView(reminder: reminder)
                                    .swipeActions(edge: .leading) {
                                        Button {
                                            store.toggleCompleted(reminder)
                                            notificationManager.cancel(notificationID: reminder.notificationID)
                                        } label: {
                                            Label("Completar", systemImage: "checkmark.circle.fill")
                                        }
                                        .tint(.green)
                                    }
                                    .swipeActions(edge: .trailing) {
                                        Button(role: .destructive) {
                                            store.delete(reminder)
                                            notificationManager.cancel(notificationID: reminder.notificationID)
                                        } label: {
                                            Label("Eliminar", systemImage: "trash.fill")
                                        }
                                    }
                            }
                        }
                    }

                    if !past.isEmpty {
                        Section {
                            if showCompleted {
                                ForEach(past) { reminder in
                                    ReminderRowView(reminder: reminder)
                                        .swipeActions(edge: .trailing) {
                                            Button(role: .destructive) {
                                                store.delete(reminder)
                                            } label: {
                                                Label("Eliminar", systemImage: "trash.fill")
                                            }
                                        }
                                }
                            }
                        } header: {
                            Button {
                                withAnimation { showCompleted.toggle() }
                            } label: {
                                HStack {
                                    Text(showCompleted ? "Ocultar anteriores" : "Mostrar anteriores (\(past.count))")
                                        .font(.footnote.weight(.semibold))
                                    Image(systemName: showCompleted ? "chevron.up" : "chevron.down")
                                        .font(.caption)
                                }
                                .foregroundStyle(category.color)
                            }
                            .textCase(nil)
                        }
                    }
                }
                .listStyle(.insetGrouped)
                .animation(.easeInOut, value: showCompleted)
            }
        }
        .navigationTitle(category.rawValue)
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showingAdd = true } label: {
                    Image(systemName: "plus.circle.fill")
                        .font(.title3)
                        .foregroundStyle(category.gradient)
                }
            }
        }
    }
}

// MARK: - Reminder Row

struct ReminderRowView: View {
    @EnvironmentObject var store: ReminderStore
    @EnvironmentObject var notificationManager: NotificationManager
    let reminder: Reminder
    @State private var showingEdit = false

    var body: some View {
        Button { showingEdit = true } label: {
            HStack(spacing: 14) {
                // Completion circle
                Button {
                    store.toggleCompleted(reminder)
                    if !reminder.isCompleted {
                        notificationManager.cancel(notificationID: reminder.notificationID)
                    } else {
                        var updated = reminder
                        updated.isCompleted = false
                        notificationManager.schedule(reminder: updated)
                    }
                } label: {
                    Image(systemName: reminder.isCompleted ? "checkmark.circle.fill" : "circle")
                        .font(.title3)
                        .foregroundStyle(reminder.isCompleted ? .green : reminder.category.color)
                }
                .buttonStyle(.plain)

                // Content
                VStack(alignment: .leading, spacing: 4) {
                    Text(reminder.title)
                        .font(.system(.body, design: .rounded, weight: .medium))
                        .strikethrough(reminder.isCompleted)
                        .foregroundStyle(reminder.isCompleted ? .secondary : .primary)
                        .lineLimit(2)

                    if !reminder.notes.isEmpty {
                        Text(reminder.notes)
                            .font(.footnote)
                            .foregroundStyle(.secondary)
                            .lineLimit(1)
                    }

                    HStack(spacing: 6) {
                        Image(systemName: "clock")
                            .font(.caption2)
                        Text(reminder.date.formatted(date: .abbreviated, time: .shortened))
                            .font(.caption)
                        
                        Spacer()

                        Image(systemName: "bell")
                            .font(.caption2)
                        Text(reminder.advanceLabel)
                            .font(.caption)
                    }
                    .foregroundStyle(reminder.isPast && !reminder.isCompleted ? .red : .secondary)
                }

                Spacer()

                // Category badge
                ZStack {
                    RoundedRectangle(cornerRadius: 7, style: .continuous)
                        .fill(reminder.category.gradient)
                        .frame(width: 28, height: 28)
                    Image(systemName: reminder.category.icon)
                        .font(.system(size: 13, weight: .semibold))
                        .foregroundStyle(.white)
                }
            }
            .padding(.vertical, 4)
        }
        .buttonStyle(.plain)
        .sheet(isPresented: $showingEdit) {
            AddEditReminderView(existingReminder: reminder)
        }
    }
}

// MARK: - Section Header

struct CategorySectionHeader: View {
    let category: ReminderCategory

    var body: some View {
        HStack(spacing: 8) {
            Image(systemName: category.icon)
                .foregroundStyle(category.color)
            Text(category.rawValue)
                .font(.headline)
                .foregroundStyle(category.color)
        }
    }
}

// MARK: - Empty State

struct EmptyStateView: View {
    let category: ReminderCategory?
    @State private var showingAdd = false

    var body: some View {
        VStack(spacing: 20) {
            Spacer()

            ZStack {
                Circle()
                    .fill((category?.gradient) ?? LinearGradient(
                        colors: [.gray.opacity(0.3), .gray.opacity(0.5)],
                        startPoint: .topLeading, endPoint: .bottomTrailing))
                    .frame(width: 100, height: 100)
                Image(systemName: category?.icon ?? "bell.slash")
                    .font(.system(size: 44))
                    .foregroundStyle(.white)
            }

            VStack(spacing: 8) {
                Text("Sin recordatorios")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text(category != nil
                     ? "Aún no tienes recordatorios en \(category!.rawValue)"
                     : "Crea tu primer recordatorio con el botón +")
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 40)
            }

            Spacer()
        }
    }
}
