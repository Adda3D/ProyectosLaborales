import SwiftUI

// MARK: - Category

enum ReminderCategory: String, CaseIterable, Codable, Identifiable {
    case empleados      = "Empleados"
    case administrativos = "Administrativos"
    case gestion        = "Gestión"

    var id: String { rawValue }

    /// Fallback for unknown values coming from the backend (e.g. test data)
    init(from decoder: Decoder) throws {
        let container = try decoder.singleValueContainer()
        let raw = try container.decode(String.self)
        self = ReminderCategory(rawValue: raw) ?? .gestion
    }

    var color: Color {
        switch self {
        case .empleados:       return Color(hex: "#3B82F6") // blue
        case .administrativos: return Color(hex: "#F59E0B") // amber
        case .gestion:         return Color(hex: "#8B5CF6") // violet
        }
    }

    var icon: String {
        switch self {
        case .empleados:       return "person.2.fill"
        case .administrativos: return "doc.text.fill"
        case .gestion:         return "chart.bar.fill"
        }
    }

    var gradient: LinearGradient {
        switch self {
        case .empleados:
            return LinearGradient(colors: [Color(hex: "#60A5FA"), Color(hex: "#2563EB")],
                                  startPoint: .topLeading, endPoint: .bottomTrailing)
        case .administrativos:
            return LinearGradient(colors: [Color(hex: "#FCD34D"), Color(hex: "#D97706")],
                                  startPoint: .topLeading, endPoint: .bottomTrailing)
        case .gestion:
            return LinearGradient(colors: [Color(hex: "#A78BFA"), Color(hex: "#7C3AED")],
                                  startPoint: .topLeading, endPoint: .bottomTrailing)
        }
    }
}

// MARK: - Reminder

struct Reminder: Identifiable, Codable {
    var id: String          = UUID().uuidString
    var title: String
    var notes: String       = ""
    var date: Date
    var category: ReminderCategory
    var advanceMinutes: Int = 10
    var isCompleted: Bool   = false
    var notificationID: String = UUID().uuidString

    var isPast: Bool {
        date < Date()
    }

    var isUpcoming: Bool {
        date >= Date()
    }

    /// Human-readable advance label
    var advanceLabel: String {
        switch advanceMinutes {
        case 5:   return "5 minutos antes"
        case 10:  return "10 minutos antes"
        case 15:  return "15 minutos antes"
        case 30:  return "30 minutos antes"
        case 60:  return "1 hora antes"
        case 120: return "2 horas antes"
        case 1440:return "1 día antes"
        default:  return "\(advanceMinutes) min antes"
        }
    }
}

// MARK: - Color Hex Extension

extension Color {
    init(hex: String) {
        let hex = hex.trimmingCharacters(in: CharacterSet.alphanumerics.inverted)
        var int: UInt64 = 0
        Scanner(string: hex).scanHexInt64(&int)
        let a, r, g, b: UInt64
        switch hex.count {
        case 3:
            (a, r, g, b) = (255, (int >> 8) * 17, (int >> 4 & 0xF) * 17, (int & 0xF) * 17)
        case 6:
            (a, r, g, b) = (255, int >> 16, int >> 8 & 0xFF, int & 0xFF)
        case 8:
            (a, r, g, b) = (int >> 24, int >> 16 & 0xFF, int >> 8 & 0xFF, int & 0xFF)
        default:
            (a, r, g, b) = (255, 0, 0, 0)
        }
        self.init(
            .sRGB,
            red:   Double(r) / 255,
            green: Double(g) / 255,
            blue:  Double(b) / 255,
            opacity: Double(a) / 255
        )
    }
}
