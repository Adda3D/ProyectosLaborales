import Foundation

// MARK: - Token manager for inventory API

class InvTokenManager {

    static let shared = InvTokenManager()

    // MARK: - Configurable (persisted in UserDefaults)

    var baseURL: String {
        get { UserDefaults.standard.string(forKey: "inv_base_url") ?? "http://204.48.16.192:3000/api/inv" }
        set { UserDefaults.standard.set(newValue, forKey: "inv_base_url") }
    }

    var adminUsername: String {
        get { UserDefaults.standard.string(forKey: "inv_username") ?? "admin" }
        set { UserDefaults.standard.set(newValue, forKey: "inv_username") }
    }

    var adminPassword: String {
        get { UserDefaults.standard.string(forKey: "inv_password") ?? "" }
        set { UserDefaults.standard.set(newValue, forKey: "inv_password") }
    }

    // MARK: - Token cache

    private var cachedToken: String?
    private var tokenExpiry: Date = .distantPast

    // MARK: - Public

    func validToken() async throws -> String {
        if let t = cachedToken, Date() < tokenExpiry.addingTimeInterval(-300) {
            return t
        }
        return try await login()
    }

    func clearToken() {
        cachedToken = nil
        tokenExpiry = .distantPast
    }

    // MARK: - Login

    func login() async throws -> String {
        guard let url = URL(string: "\(baseURL)/login") else {
            throw InvError.badURL
        }
        var req = URLRequest(url: url)
        req.httpMethod = "POST"
        req.setValue("application/json", forHTTPHeaderField: "Content-Type")
        req.timeoutInterval = 15
        let body = ["username": adminUsername, "password": adminPassword]
        req.httpBody = try JSONEncoder().encode(body)

        let (data, response) = try await URLSession.shared.data(for: req)
        let status = (response as? HTTPURLResponse)?.statusCode ?? -1

        guard status == 200 else {
            let msg = String(data: data, encoding: .utf8) ?? "sin respuesta"
            throw InvError.authFailed("HTTP \(status): \(msg)")
        }

        struct LoginResponse: Decodable { let token: String }
        let decoded = try JSONDecoder().decode(LoginResponse.self, from: data)
        cachedToken = decoded.token
        tokenExpiry = Date().addingTimeInterval(23 * 3600) // 23h to be safe
        return decoded.token
    }
}

// MARK: - Errors

enum InvError: LocalizedError {
    case badURL
    case authFailed(String)
    case requestFailed(Int, String)
    case decodingFailed(String)

    var errorDescription: String? {
        switch self {
        case .badURL:                 return "URL del servidor inválida."
        case .authFailed(let m):      return "Error de autenticación: \(m)"
        case .requestFailed(let c, let m): return "Error \(c): \(m)"
        case .decodingFailed(let m):  return "Error al leer datos: \(m)"
        }
    }
}
