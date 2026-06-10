import Foundation
import Combine

class InventoryStore: ObservableObject {

    // MARK: - Published state

    @Published var users:          [InvUser]  = []
    @Published var recentEntries:  [InvEntry] = []
    @Published var isLoadingUsers  = false
    @Published var isLoadingHistory = false
    @Published var errorMessage:   String?    = nil
    @Published var isLoggedIn      = false

    // MARK: - Passthrough to token manager

    var baseURL: String {
        get { InvTokenManager.shared.baseURL }
        set { InvTokenManager.shared.baseURL = newValue }
    }
    var adminUsername: String {
        get { InvTokenManager.shared.adminUsername }
        set { InvTokenManager.shared.adminUsername = newValue }
    }
    var adminPassword: String {
        get { InvTokenManager.shared.adminPassword }
        set { InvTokenManager.shared.adminPassword = newValue }
    }

    // MARK: - Login

    func login() async {
        do {
            _ = try await InvAPI.login()
            isLoggedIn = true
            errorMessage = nil
        } catch {
            isLoggedIn = false
            errorMessage = error.localizedDescription
        }
    }

    // MARK: - Users

    func fetchUsers() async {
        isLoadingUsers = true
        defer { isLoadingUsers = false }
        do {
            users = try await InvAPI.fetchUsers()
        } catch {
            errorMessage = error.localizedDescription
        }
    }

    func createUser(username: String, password: String, role: String) async throws {
        let user = try await InvAPI.createUser(username: username, password: password, role: role)
        users.append(user)
    }

    func updateUser(id: Int, fields: [String: Any]) async throws {
        let updated = try await InvAPI.updateUser(id: id, fields: fields)
        if let idx = users.firstIndex(where: { $0.id == id }) {
            users[idx] = updated
        }
    }

    func deleteUser(id: Int) async throws {
        try await InvAPI.deleteUser(id: id)
        users.removeAll { $0.id == id }
    }

    // MARK: - History

    func fetchHistory() async {
        isLoadingHistory = true
        defer { isLoadingHistory = false }
        do {
            recentEntries = try await InvAPI.fetchEntries(limit: 60)
        } catch {
            errorMessage = error.localizedDescription
        }
    }

    // MARK: - Grouped history (by date)

    var historyDates: [String] {
        let dates = recentEntries.map { $0.entry_date }
        var seen = Set<String>()
        return dates.filter { seen.insert($0).inserted }.sorted(by: >)
    }

    func entries(for date: String) -> [InvEntry] {
        recentEntries.filter { $0.entry_date == date }
    }

    func hasCierre(for date: String)   -> Bool { entries(for: date).contains { $0.moment == "cierre" } }
    func hasApertura(for date: String) -> Bool { entries(for: date).contains { $0.moment == "apertura" } }
}
