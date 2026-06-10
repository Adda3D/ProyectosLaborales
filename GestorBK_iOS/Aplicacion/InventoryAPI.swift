import Foundation

// MARK: - Inventory REST API

struct InvAPI {

    private static var base: String { InvTokenManager.shared.baseURL }
    private static let session = URLSession.shared

    // MARK: - Helpers

    private static func url(_ path: String) throws -> URL {
        guard let u = URL(string: "\(base)\(path)") else { throw InvError.badURL }
        return u
    }

    private static func authedRequest(_ path: String, method: String = "GET", body: Encodable? = nil) async throws -> URLRequest {
        let token = try await InvTokenManager.shared.validToken()
        var req = URLRequest(url: try url(path))
        req.httpMethod = method
        req.setValue(token, forHTTPHeaderField: "x-auth-token")
        req.timeoutInterval = 15
        if let body {
            req.setValue("application/json", forHTTPHeaderField: "Content-Type")
            req.httpBody = try JSONEncoder().encode(body)
        }
        return req
    }

    private static func plainRequest(_ path: String, method: String = "GET", body: Encodable? = nil) throws -> URLRequest {
        var req = URLRequest(url: try url(path))
        req.httpMethod = method
        req.timeoutInterval = 15
        if let body {
            req.setValue("application/json", forHTTPHeaderField: "Content-Type")
            req.httpBody = try JSONEncoder().encode(body)
        }
        return req
    }

    private static func check(_ data: Data, _ response: URLResponse, expected: Int = 200) throws {
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1
        guard status == expected else {
            let msg = String(data: data, encoding: .utf8) ?? "sin cuerpo"
            throw InvError.requestFailed(status, msg)
        }
    }

    // MARK: - Auth

    static func login() async throws -> String {
        try await InvTokenManager.shared.login()
    }

    // MARK: - Users

    static func fetchUsers() async throws -> [InvUser] {
        let req = try await authedRequest("/users")
        let (data, res) = try await session.data(for: req)
        try check(data, res)
        return try JSONDecoder().decode([InvUser].self, from: data)
    }

    static func createUser(username: String, password: String, role: String) async throws -> InvUser {
        let body = ["username": username, "password": password, "role": role]
        let req = try plainRequest("/users", method: "POST", body: body)
        let (data, res) = try await session.data(for: req)
        try check(data, res, expected: 201)
        return try JSONDecoder().decode(InvUser.self, from: data)
    }

    static func updateUser(id: Int, fields: [String: Any]) async throws -> InvUser {
        guard let url = URL(string: "\(base)/users/\(id)") else { throw InvError.badURL }
        var req = URLRequest(url: url)
        req.httpMethod = "PUT"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        req.httpBody = try JSONSerialization.data(withJSONObject: fields)
        let (data, res) = try await session.data(for: req)
        try check(data, res)
        return try JSONDecoder().decode(InvUser.self, from: data)
    }

    static func deleteUser(id: Int) async throws {
        guard let url = URL(string: "\(base)/users/\(id)") else { throw InvError.badURL }
        var req = URLRequest(url: url)
        req.httpMethod = "DELETE"
        req.timeoutInterval = 15
        let (data, res) = try await session.data(for: req)
        try check(data, res, expected: 204)
    }

    // MARK: - Entries

    static func fetchEntries(date: String? = nil, moment: String? = nil, limit: Int = 50) async throws -> [InvEntry] {
        var params: [String] = ["limit=\(limit)"]
        if let d = date   { params.append("date=\(d)") }
        if let m = moment { params.append("moment=\(m)") }
        let query = params.joined(separator: "&")
        let req = try await authedRequest("/entries?\(query)")
        let (data, res) = try await session.data(for: req)
        try check(data, res)
        return try JSONDecoder().decode([InvEntry].self, from: data)
    }

    static func fetchEntryDetail(id: Int) async throws -> InvEntryDetail {
        let req = try await authedRequest("/entries/\(id)")
        let (data, res) = try await session.data(for: req)
        try check(data, res)
        return try JSONDecoder().decode(InvEntryDetail.self, from: data)
    }

    static func deleteEntry(id: Int) async throws {
        let req = try await authedRequest("/entries/\(id)", method: "DELETE")
        let (data, res) = try await session.data(for: req)
        try check(data, res, expected: 204)
    }

    // MARK: - Day snapshot (cierre + apertura)

    static func fetchDaySnapshot(date: String) async throws -> InvDaySnapshot {
        let entries = try await fetchEntries(date: date)
        var snapshot = InvDaySnapshot(date: date)

        async let cierreDetail: InvEntryDetail? = {
            if let e = entries.first(where: { $0.moment == "cierre" }) {
                return try? await fetchEntryDetail(id: e.id)
            }
            return nil
        }()
        async let aperturaDetail: InvEntryDetail? = {
            if let e = entries.first(where: { $0.moment == "apertura" }) {
                return try? await fetchEntryDetail(id: e.id)
            }
            return nil
        }()

        snapshot.cierre   = await cierreDetail
        snapshot.apertura = await aperturaDetail
        return snapshot
    }
}
