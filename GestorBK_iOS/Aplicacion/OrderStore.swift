import Foundation
import Combine

class OrderStore: ObservableObject {
    @Published var orders: [Order] = []
    @Published var suppliers: [Supplier] = []
    @Published var isLoading = false

    private var serverURL: String { GBKNet.serverURL() }
    private let session = URLSession.shared

    private let defaultSupplierNames = [
        "Pan", "Conway Fresco", "Conway Total", "Damn", "LOOMIIS", "Carburos"
    ]

    init() {
        Task { await loadAll() }
    }

    // MARK: - Suppliers

    func supplier(for id: String) -> Supplier? {
        suppliers.first { $0.id == id }
    }

    func addSupplier(_ s: Supplier) {
        suppliers.append(s)
        Task { try? await apiCreateSupplier(s) }
    }

    func updateSupplier(_ s: Supplier) {
        if let i = suppliers.firstIndex(where: { $0.id == s.id }) { suppliers[i] = s }
        Task { try? await apiUpdateSupplier(s) }
    }

    func deleteSupplier(_ s: Supplier) {
        suppliers.removeAll { $0.id == s.id }
        Task { try? await apiDeleteSupplier(id: s.id) }
    }

    // MARK: - Orders

    func add(_ o: Order) {
        orders.append(o)
        Task { try? await apiCreateOrder(o) }
    }

    func update(_ o: Order) {
        if let i = orders.firstIndex(where: { $0.id == o.id }) { orders[i] = o }
        Task { try? await apiUpdateOrder(o) }
    }

    func delete(_ o: Order) {
        orders.removeAll { $0.id == o.id }
        Task { try? await apiDeleteOrder(id: o.id) }
    }

    func confirmToday(order: Order) {
        guard let i = orders.firstIndex(where: { $0.id == order.id }) else { return }
        let key = order.dateKey(for: Date())
        if !orders[i].confirmedDates.contains(key) {
            orders[i].confirmedDates.append(key)
            let updated = orders[i]
            Task { try? await apiUpdateOrder(updated) }
        }
    }

    var pendingConfirmationOrders: [Order] {
        orders.filter { $0.isPendingConfirmation }
    }

    // MARK: - Load from API

    func loadAll() async {
        guard !serverURL.isEmpty else { return }
        isLoading = true
        defer { isLoading = false }
        await withTaskGroup(of: Void.self) { group in
            group.addTask { await self.loadSuppliers() }
            group.addTask { await self.loadOrders() }
        }
    }

    private func loadSuppliers() async {
        let urlStr = "\(serverURL)/api/suppliers"
        guard let url = URL(string: urlStr) else { return }
        print("ℹ️ [OrderStore] GET \(urlStr)")
        guard let (data, response) = try? await session.data(from: url) else {
            print("⛔ [OrderStore] Sin conexión con \(urlStr)")
            return
        }
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [OrderStore] GET /api/suppliers → HTTP \(status)")
            return
        }
        let loaded = GBKNet.decodeArray(Supplier.self, from: data, context: "OrderStore.loadSuppliers")
        if loaded.isEmpty {
            let defaults = defaultSupplierNames.map { Supplier(name: $0) }
            suppliers = defaults
            for s in defaults { try? await apiCreateSupplier(s) }
        } else {
            suppliers = loaded
        }
    }

    private func loadOrders() async {
        let urlStr = "\(serverURL)/api/orders"
        guard let url = URL(string: urlStr) else { return }
        print("ℹ️ [OrderStore] GET \(urlStr)")
        guard let (data, response) = try? await session.data(from: url) else {
            print("⛔ [OrderStore] Sin conexión con \(urlStr)")
            return
        }
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [OrderStore] GET /api/orders → HTTP \(status)")
            return
        }
        let loaded = GBKNet.decodeArray(Order.self, from: data, context: "OrderStore.loadOrders")
        orders = loaded
    }

    // MARK: - API Suppliers

    private func apiCreateSupplier(_ s: Supplier) async throws {
        guard let url = URL(string: "\(serverURL)/api/suppliers") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "POST"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(s)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 201 && status != 404 {
            print("⛔ [OrderStore] POST /api/suppliers → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiUpdateSupplier(_ s: Supplier) async throws {
        guard let url = URL(string: "\(serverURL)/api/suppliers/\(s.id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "PUT"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(s)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 404 {
            print("⛔ [OrderStore] PUT /api/suppliers/\(s.id) → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiDeleteSupplier(id: String) async throws {
        guard let url = URL(string: "\(serverURL)/api/suppliers/\(id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "DELETE"
        req.timeoutInterval = 15
        let (_, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 204 && status != 404 {
            print("⛔ [OrderStore] DELETE /api/suppliers/\(id) → HTTP \(status)")
        }
    }

    // MARK: - API Orders

    private func apiCreateOrder(_ o: Order) async throws {
        guard let url = URL(string: "\(serverURL)/api/orders") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "POST"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(o)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 201 && status != 404 {
            print("⛔ [OrderStore] POST /api/orders → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiUpdateOrder(_ o: Order) async throws {
        guard let url = URL(string: "\(serverURL)/api/orders/\(o.id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "PUT"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try GBKNet.encoder().encode(o)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 404 {
            print("⛔ [OrderStore] PUT /api/orders/\(o.id) → HTTP \(status): \(String(data: data, encoding: .utf8) ?? "")")
        }
    }

    private func apiDeleteOrder(id: String) async throws {
        guard let url = URL(string: "\(serverURL)/api/orders/\(id)") else { return }
        var req = URLRequest(url: url)
        req.httpMethod = "DELETE"
        req.timeoutInterval = 15
        let (_, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        if status != 200 && status != 204 && status != 404 {
            print("⛔ [OrderStore] DELETE /api/orders/\(id) → HTTP \(status)")
        }
    }
}
