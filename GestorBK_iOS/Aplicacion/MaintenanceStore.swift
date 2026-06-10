import Foundation
import Combine

class MaintenanceStore: ObservableObject {
    @Published var items: [MaintenanceItem] = []
    @Published var isLoading = false

    private var serverURL: String { GBKNet.serverURL() }
    private let session = URLSession.shared

    init() {
        Task { await loadAll() }
    }

    // MARK: - Filtered helpers

    var pending: [MaintenanceItem] {
        items.filter { $0.status == .pending && !$0.isArchived }
            .sorted { $0.createdAt > $1.createdAt }
    }

    var resolvedNotArchived: [MaintenanceItem] {
        items.filter { $0.status == .solved && !$0.isArchived }
            .sorted { ($0.resolvedAt ?? $0.createdAt) > ($1.resolvedAt ?? $1.createdAt) }
    }

    var archived: [MaintenanceItem] {
        items.filter { $0.isArchived }
            .sorted { ($0.resolvedAt ?? $0.createdAt) > ($1.resolvedAt ?? $1.createdAt) }
    }

    // MARK: - CRUD (optimistic local update + background API sync)

    func add(_ item: MaintenanceItem) {
        items.append(item)
        Task { try? await apiCreate(item) }
    }

    func update(_ item: MaintenanceItem) {
        if let i = items.firstIndex(where: { $0.id == item.id }) { items[i] = item }
        Task { try? await apiUpdate(item) }
    }

    func delete(_ item: MaintenanceItem) {
        items.removeAll { $0.id == item.id }
        Task { try? await apiDelete(id: item.id) }
    }

    func resolve(_ item: MaintenanceItem) {
        if let i = items.firstIndex(where: { $0.id == item.id }) {
            items[i].status = .solved
            items[i].resolvedAt = Date()
            let updated = items[i]
            Task { try? await apiUpdate(updated) }
        }
    }

    func archive(_ item: MaintenanceItem) {
        if let i = items.firstIndex(where: { $0.id == item.id }) {
            if items[i].status == .pending {
                items[i].status = .solved
                items[i].resolvedAt = Date()
            }
            items[i].isArchived = true
            let updated = items[i]
            Task { try? await apiUpdate(updated) }
        }
    }

    // MARK: - Load from API

    func loadAll() async {
        let urlStr = "\(serverURL)/api/maintenance"
        guard let url = URL(string: urlStr) else { return }
        print("ℹ️ [MaintenanceStore] GET \(urlStr)")
        isLoading = true
        defer { isLoading = false }
        guard let (data, response) = try? await session.data(from: url) else {
            print("⛔ [MaintenanceStore] Sin conexión con \(urlStr)")
            return
        }
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [MaintenanceStore] GET /api/maintenance → HTTP \(status)")
            return
        }
        let loaded = GBKNet.decodeArray(MaintenanceItem.self, from: data, context: "MaintenanceStore.loadAll")
        items = loaded
    }

    // MARK: - Private API helpers

    private func apiCreate(_ item: MaintenanceItem) async throws {
        guard let url = URL(string: "\(serverURL)/api/maintenance") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "POST"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(item)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 201 && status != 404 {
            print("⛔ [MaintenanceStore] POST /api/maintenance → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiUpdate(_ item: MaintenanceItem) async throws {
        guard let url = URL(string: "\(serverURL)/api/maintenance/\(item.id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "PUT"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(item)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 404 {
            print("⛔ [MaintenanceStore] PUT /api/maintenance/\(item.id) → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiDelete(id: String) async throws {
        guard let url = URL(string: "\(serverURL)/api/maintenance/\(id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "DELETE"
        req.timeoutInterval = 15
        let (_, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 204 && status != 404 {
            print("⛔ [MaintenanceStore] DELETE /api/maintenance/\(id) → HTTP \(status)")
        }
    }
}
