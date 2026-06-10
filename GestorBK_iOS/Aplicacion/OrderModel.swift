import SwiftUI
import Foundation

// MARK: - Weekday

enum Weekday: Int, Codable, CaseIterable, Identifiable {
    case sunday = 1, monday, tuesday, wednesday, thursday, friday, saturday

    var id: Int { rawValue }

    var name: String {
        switch self {
        case .sunday:    return "Domingo"
        case .monday:    return "Lunes"
        case .tuesday:   return "Martes"
        case .wednesday: return "Miércoles"
        case .thursday:  return "Jueves"
        case .friday:    return "Viernes"
        case .saturday:  return "Sábado"
        }
    }

    var shortName: String {
        switch self {
        case .sunday:    return "D"
        case .monday:    return "L"
        case .tuesday:   return "M"
        case .wednesday: return "X"
        case .thursday:  return "J"
        case .friday:    return "V"
        case .saturday:  return "S"
        }
    }

    /// Ordered Mon → Sun for display
    static var weekOrder: [Weekday] {
        [.monday, .tuesday, .wednesday, .thursday, .friday, .saturday, .sunday]
    }
}

// MARK: - Supplier

struct Supplier: Identifiable, Codable {
    var id: String = UUID().uuidString
    var name: String
}

// MARK: - Order

struct Order: Identifiable, Codable {
    var id: String = UUID().uuidString
    var supplierID: String
    var recurringDays: [Weekday]
    var hour: Int
    var minute: Int
    var isActive: Bool = true
    /// Keys in "yyyy-MM-dd" format for confirmed days
    var confirmedDates: [String] = []
    var notificationBaseID: String = UUID().uuidString

    var timeString: String {
        String(format: "%02d:%02d", hour, minute)
    }

    func isConfirmedToday() -> Bool {
        confirmedDates.contains(dateKey(for: Date()))
    }

    func dateKey(for date: Date) -> String {
        let f = DateFormatter()
        f.dateFormat = "yyyy-MM-dd"
        return f.string(from: date)
    }

    func scheduledTimeToday() -> Date? {
        var comps = Calendar.current.dateComponents([.year, .month, .day], from: Date())
        comps.hour = hour
        comps.minute = minute
        comps.second = 0
        return Calendar.current.date(from: comps)
    }

    var isDueToday: Bool {
        let weekday = Calendar.current.component(.weekday, from: Date())
        return recurringDays.contains { $0.rawValue == weekday }
    }

    var isPendingConfirmation: Bool {
        guard isDueToday, isActive, !isConfirmedToday() else { return false }
        guard let t = scheduledTimeToday() else { return false }
        return t <= Date()
    }
}
