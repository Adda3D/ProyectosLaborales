import SwiftUI
import Foundation

// MARK: - Maintenance Status

enum MaintenanceStatus: String, Codable, CaseIterable, Identifiable {
    case pending  = "Pendiente"
    case solved   = "Solucionado"

    var id: String { rawValue }

    var color: Color {
        switch self {
        case .pending: return Color(hex: "#EF4444")
        case .solved:  return Color(hex: "#10B981")
        }
    }

    var icon: String {
        switch self {
        case .pending: return "wrench.and.screwdriver.fill"
        case .solved:  return "checkmark.seal.fill"
        }
    }
}

// MARK: - Maintenance Item

struct MaintenanceItem: Identifiable, Codable {
    var id: String = UUID().uuidString
    var descriptionText: String
    var status: MaintenanceStatus = .pending
    var createdAt: Date = Date()
    var resolvedAt: Date? = nil
    var isArchived: Bool = false
}
