import Foundation
import Combine

class ReminderStore: ObservableObject {
    @Published var reminders: [Reminder] = []
    @Published var isLoading = false

    private var serverURL: String { GBKNet.serverURL() }
    private let session = URLSession.shared

    init() {
        Task { await loadAll() }
    }

    // MARK: - CRUD (optimistic local update + background API sync)

    func add(_ reminder: Reminder) {
        reminders.append(reminder)
        Task { try? await apiCreate(reminder) }
    }

    func update(_ reminder: Reminder) {
        if let i = reminders.firstIndex(where: { $0.id == reminder.id }) {
            reminders[i] = reminder
        }
        Task { try? await apiUpdate(reminder) }
    }

    func delete(_ reminder: Reminder) {
        reminders.removeAll { $0.id == reminder.id }
        Task { try? await apiDelete(id: reminder.id) }
    }

    func toggleCompleted(_ reminder: Reminder) {
        if let i = reminders.firstIndex(where: { $0.id == reminder.id }) {
            reminders[i].isCompleted.toggle()
            let updated = reminders[i]
            Task { try? await apiUpdate(updated) }
        }
    }

    // MARK: - Filtered helpers

    func reminders(for category: ReminderCategory) -> [Reminder] {
        reminders.filter { $0.category == category }.sorted { $0.date < $1.date }
    }

    func upcoming(for category: ReminderCategory) -> [Reminder] {
        reminders(for: category).filter { !$0.isCompleted && $0.isUpcoming }
    }

    func past(for category: ReminderCategory) -> [Reminder] {
        reminders(for: category).filter { $0.isPast || $0.isCompleted }
    }

    var allUpcoming: [Reminder] {
        reminders.filter { !$0.isCompleted && $0.isUpcoming }.sorted { $0.date < $1.date }
    }

    // MARK: - Load from API

    func loadAll() async {
        let urlStr = "\(serverURL)/api/reminders"
        guard let url = URL(string: urlStr) else { return }
        print("ℹ️ [ReminderStore] GET \(urlStr)")
        isLoading = true
        defer { isLoading = false }
        guard let (data, response) = try? await session.data(from: url) else {
            print("⛔ [ReminderStore] Sin conexión con \(urlStr)")
            return
        }
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [ReminderStore] GET /api/reminders → HTTP \(status)")
            return
        }
        let loaded = GBKNet.decodeArray(Reminder.self, from: data, context: "ReminderStore.loadAll")
        reminders = loaded
    }

    // MARK: - Private API helpers

    private func apiCreate(_ reminder: Reminder) async throws {
        guard let url = URL(string: "\(serverURL)/api/reminders") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "POST"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(reminder)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 201 {
            if status != 404 {
                print("⛔ [ReminderStore] POST /api/reminders → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
            }
        }
    }

    private func apiUpdate(_ reminder: Reminder) async throws {
        guard let url = URL(string: "\(serverURL)/api/reminders/\(reminder.id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "PUT"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(reminder)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 404 {
            print("⛔ [ReminderStore] PUT /api/reminders/\(reminder.id) → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiDelete(id: String) async throws {
        guard let url = URL(string: "\(serverURL)/api/reminders/\(id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "DELETE"
        req.timeoutInterval = 15
        let (_, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 204 && status != 404 {
            print("⛔ [ReminderStore] DELETE /api/reminders/\(id) → HTTP \(status)")
        }
    }
}
