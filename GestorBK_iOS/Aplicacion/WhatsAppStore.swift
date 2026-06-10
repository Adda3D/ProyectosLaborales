import Foundation
import Combine

class WAStore: ObservableObject {

    // MARK: - Published state

    @Published var messages: [WAMessage]  = []
    @Published var contacts: [WAContact]  = []
    @Published var waStatus: WAStatus     = .disconnected
    @Published var isLoading              = false
    @Published var errorMessage: String?  = nil

    @Published var serverURL: String {
        didSet { UserDefaults.standard.set(serverURL, forKey: "wa_server_url") }
    }

    // MARK: - Private

    private let session = URLSession.shared
    private var pollingTask: Task<Void, Never>?

    // MARK: - Init

    init() {
        let stored = UserDefaults.standard.string(forKey: "wa_server_url") ?? ""
        self.serverURL = stored.isEmpty ? GBKNet.defaultBase : stored
        Task { await refresh() }
        startPolling()
    }

    // MARK: - URL helpers

    private func url(_ path: String) throws -> URL {
        guard let base = URL(string: serverURL),
              let url  = URL(string: path, relativeTo: base) else {
            throw URLError(.badURL)
        }
        return url
    }

    private func jsonRequest(_ path: String, method: String, body: Encodable? = nil) throws -> URLRequest {
        var req = URLRequest(url: try url(path))
        req.httpMethod = method
        req.timeoutInterval = 10
        if let body {
            req.setValue("application/json", forHTTPHeaderField: "Content-Type")
            req.httpBody = try JSONEncoder().encode(body)
        }
        return req
    }

    // MARK: - Refresh (status + messages + contacts)

    func refresh() async {
        isLoading = true
        defer { isLoading = false }
        async let s = fetchStatus()
        async let m = fetchMessages()
        async let c = fetchContacts()
        self.waStatus  = (try? await s) ?? .disconnected
        self.messages  = (try? await m) ?? messages
        self.contacts  = (try? await c) ?? contacts
    }

    private func fetchStatus() async throws -> WAStatus {
        let (data, _) = try await session.data(from: try url("/api/status"))
        guard let decoded = GBKNet.decode(WAStatus.self, from: data, context: "WAStore.fetchStatus") else {
            throw URLError(.cannotParseResponse)
        }
        return decoded
    }

    private func fetchMessages() async throws -> [WAMessage] {
        let (data, response) = try await session.data(from: try url("/api/messages"))
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [WAStore] GET /api/messages → HTTP \(status)")
            throw URLError(.badServerResponse)
        }
        guard let decoded = GBKNet.decode([WAMessage].self, from: data, context: "WAStore.fetchMessages") else {
            throw URLError(.cannotParseResponse)
        }
        return decoded
    }

    private func fetchContacts() async throws -> [WAContact] {
        let (data, response) = try await session.data(from: try url("/api/wa/contacts"))
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            print("⛔ [WAStore] GET /api/wa/contacts → HTTP \(status)")
            throw URLError(.badServerResponse)
        }
        guard let decoded = GBKNet.decode([WAContact].self, from: data, context: "WAStore.fetchContacts") else {
            throw URLError(.cannotParseResponse)
        }
        return decoded
    }

    // MARK: - Messages CRUD

    func addMessage(_ input: WAMessageInput) async throws {
        let req = try jsonRequest("/api/messages", method: "POST", body: input)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 201 else {
            let body = String(data: data, encoding: .utf8) ?? "sin respuesta"
            print("⛔ [WAStore] POST /api/messages → HTTP \(status): \(body)")
            throw URLError(.badServerResponse, userInfo: [NSLocalizedDescriptionKey: "Error \(status): \(body)"])
        }
        guard let created = GBKNet.decode(WAMessage.self, from: data, context: "WAStore.addMessage") else {
            throw URLError(.cannotParseResponse)
        }
        messages.append(created)
    }

    func updateMessage(_ msg: WAMessage) async throws {
        let req = try jsonRequest("/api/messages/\(msg.id)", method: "PUT", body: msg)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            let body = String(data: data, encoding: .utf8) ?? "sin respuesta"
            print("⛔ [WAStore] PUT /api/messages/\(msg.id) → HTTP \(status): \(body)")
            throw URLError(.badServerResponse, userInfo: [NSLocalizedDescriptionKey: "Error \(status): \(body)"])
        }
        guard let updated = GBKNet.decode(WAMessage.self, from: data, context: "WAStore.updateMessage") else {
            throw URLError(.cannotParseResponse)
        }
        if let i = messages.firstIndex(where: { $0.id == updated.id }) {
            messages[i] = updated
        }
    }

    func deleteMessage(_ msg: WAMessage) async throws {
        let req = try jsonRequest("/api/messages/\(msg.id)", method: "DELETE")
        _ = try await session.data(for: req)
        messages.removeAll { $0.id == msg.id }
    }

    func sendNow(_ msg: WAMessage) async throws {
        let req = try jsonRequest("/api/messages/\(msg.id)/send", method: "POST")
        _ = try await session.data(for: req)
        await refresh()
    }

    func toggleActive(_ msg: WAMessage) {
        Task {
            var updated = msg
            updated.isActive.toggle()
            try? await updateMessage(updated)
        }
    }

    // MARK: - Contacts CRUD

    func addContact(_ input: WAContactInput) async throws {
        let req = try jsonRequest("/api/wa/contacts", method: "POST", body: input)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 201 else {
            let body = String(data: data, encoding: .utf8) ?? "sin respuesta"
            print("⛔ [WAStore] POST /api/wa/contacts → HTTP \(status): \(body)")
            throw URLError(.badServerResponse, userInfo: [NSLocalizedDescriptionKey: "Error \(status): \(body)"])
        }
        guard let created = GBKNet.decode(WAContact.self, from: data, context: "WAStore.addContact") else {
            throw URLError(.cannotParseResponse)
        }
        contacts.append(created)
    }

    func updateContact(_ contact: WAContact) async throws {
        let req = try jsonRequest("/api/wa/contacts/\(contact.id)", method: "PUT", body: contact)
        let (data, response) = try await session.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == 200 else {
            let body = String(data: data, encoding: .utf8) ?? "sin respuesta"
            print("⛔ [WAStore] PUT /api/wa/contacts/\(contact.id) → HTTP \(status): \(body)")
            throw URLError(.badServerResponse, userInfo: [NSLocalizedDescriptionKey: "Error \(status): \(body)"])
        }
        guard let updated = GBKNet.decode(WAContact.self, from: data, context: "WAStore.updateContact") else {
            throw URLError(.cannotParseResponse)
        }
        if let i = contacts.firstIndex(where: { $0.id == updated.id }) {
            contacts[i] = updated
        }
    }

    func deleteContact(_ contact: WAContact) async throws {
        let req = try jsonRequest("/api/wa/contacts/\(contact.id)", method: "DELETE")
        _ = try await session.data(for: req)
        contacts.removeAll { $0.id == contact.id }
    }

    // MARK: - Polling (every 30 s)

    func startPolling() {
        pollingTask?.cancel()
        pollingTask = Task {
            while !Task.isCancelled {
                try? await Task.sleep(for: .seconds(30))
                guard !Task.isCancelled else { break }
                await refresh()
            }
        }
    }
}

// MARK: - Input type for creating messages (excludes server-generated fields)

struct WAMessageInput: Codable {
    var name: String
    var recipients: [WARecipient]
    var message: String
    var schedule: WASchedule
    var isActive: Bool
}
