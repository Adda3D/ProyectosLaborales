import Foundation

// MARK: - Recipient

enum WARecipientType: String, Codable, CaseIterable {
    case contact = "contact"
    case group   = "group"

    var label: String {
        switch self {
        case .contact: return "Contacto"
        case .group:   return "Grupo"
        }
    }

    var icon: String {
        switch self {
        case .contact: return "person.fill"
        case .group:   return "person.3.fill"
        }
    }
}

struct WARecipient: Identifiable, Codable, Equatable, Hashable {
    /// WhatsApp ID: "521XXXXXXXXXX@c.us" (contact) or "XXXX-XXXX@g.us" (group)
    var id: String
    var name: String
    var type: WARecipientType
}

// MARK: - Schedule

struct WASchedule: Codable, Equatable {
    /// JS weekday integers: 0=Sunday, 1=Monday … 6=Saturday
    var days: [Int]
    /// 24h format "HH:MM"
    var time: String

    var displayString: String {
        let dayNames = days
            .compactMap { Weekday.from(jsWeekday: $0)?.name }
            .joined(separator: ", ")
        return "\(dayNames) · \(time)"
    }
}

// MARK: - Message

struct WAMessage: Identifiable, Codable {
    var id: String
    var name: String
    var recipients: [WARecipient]
    var message: String
    var schedule: WASchedule
    var isActive: Bool
    var lastSentAt: String?
    var createdAt: String
}

// MARK: - Saved Contact / Group

struct WAContact: Identifiable, Codable, Equatable, Hashable {
    /// Server-generated UUID (safe for URL paths, no special characters)
    var id: String
    /// Actual WhatsApp ID: "521XXXXXXXXXX@c.us" (contact) or "XXXX@g.us" (group)
    var waId: String
    var name: String
    var type: WARecipientType

    var asRecipient: WARecipient {
        WARecipient(id: waId, name: name, type: type)
    }
}

struct WAContactInput: Codable {
    var waId: String
    var name: String
    var type: WARecipientType
}

// MARK: - Status response

struct WAStatus: Codable {
    var status: String   // DISCONNECTED | QR_READY | AUTHENTICATED | READY
    var qr: String?      // base64 PNG data URL when status == QR_READY

    static let disconnected = WAStatus(status: "DISCONNECTED", qr: nil)
}

// MARK: - Weekday ↔ JS weekday bridge

extension Weekday {
    /// iOS Calendar weekday (1=Sun…7=Sat) → JS getDay() (0=Sun…6=Sat)
    var jsWeekday: Int { rawValue - 1 }

    static func from(jsWeekday: Int) -> Weekday? {
        Weekday(rawValue: jsWeekday + 1)
    }
}
