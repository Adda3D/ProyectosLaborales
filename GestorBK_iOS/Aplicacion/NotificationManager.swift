import Foundation
import Combine
import UserNotifications

class NotificationManager: ObservableObject {
    @Published var permissionGranted: Bool = false

    // MARK: - Permission

    func requestPermission() {
        UNUserNotificationCenter.current().requestAuthorization(
            options: [.alert, .sound, .badge]
        ) { granted, _ in
            DispatchQueue.main.async { self.permissionGranted = granted }
        }
    }

    // MARK: - Reminders

    func schedule(reminder: Reminder) {
        cancel(notificationID: reminder.notificationID)
        guard !reminder.isCompleted, reminder.isUpcoming else { return }

        let fireDate = reminder.date.addingTimeInterval(TimeInterval(-reminder.advanceMinutes * 60))
        guard fireDate > Date() else { return }

        let content        = UNMutableNotificationContent()
        content.title      = categoryTitle(reminder.category)
        content.body       = reminder.title
        content.sound      = .default
        content.badge      = 1
        if !reminder.notes.isEmpty { content.subtitle = reminder.notes }
        content.userInfo   = [
            "category":   reminder.category.rawValue,
            "reminderID": reminder.id
        ]

        let comps   = Calendar.current.dateComponents([.year, .month, .day, .hour, .minute], from: fireDate)
        let trigger = UNCalendarNotificationTrigger(dateMatching: comps, repeats: false)
        let request = UNNotificationRequest(identifier: reminder.notificationID, content: content, trigger: trigger)
        UNUserNotificationCenter.current().add(request)
    }

    func cancel(notificationID: String) {
        UNUserNotificationCenter.current().removePendingNotificationRequests(withIdentifiers: [notificationID])
    }

    func reschedule(old: Reminder, new: Reminder) {
        cancel(notificationID: old.notificationID)
        schedule(reminder: new)
    }

    private func categoryTitle(_ cat: ReminderCategory) -> String {
        switch cat {
        case .empleados:       return "👥 Empleados"
        case .administrativos: return "📄 Administrativos"
        case .gestion:         return "📊 Gestión"
        }
    }

    // MARK: - Orders

    /// Schedule base weekly repeating notifications + follow-ups for an order.
    func scheduleOrderNotifications(order: Order, suppliers: [Supplier]) {
        cancelOrderNotifications(order: order)
        guard order.isActive else { return }

        let supplierName = suppliers.first(where: { $0.id == order.supplierID })?.name ?? "Pedido"

        for day in order.recurringDays {
            // 1) Weekly recurring base notification
            let baseID = orderBaseID(order: order, day: day)
            scheduleWeeklyOrder(
                id: baseID,
                title: "🛒 Pedido - \(supplierName)",
                body: "Confirma la llegada del pedido de \(supplierName)",
                weekday: day.rawValue,
                hour: order.hour,
                minute: order.minute
            )

            // 2) Follow-up notifications for the next 2 occurrences of that weekday
            let nextDates = nextOccurrences(weekday: day.rawValue, count: 2)
            for baseDate in nextDates {
                var comps   = Calendar.current.dateComponents([.year, .month, .day], from: baseDate)
                comps.hour  = order.hour
                comps.minute = order.minute
                comps.second = 0
                guard let fireTime = Calendar.current.date(from: comps) else { continue }
                let dateKey = compactDateString(from: baseDate)

                for n in 1...3 {
                    let followUpDate = fireTime.addingTimeInterval(TimeInterval(n * 30 * 60))
                    guard followUpDate > Date() else { continue }

                    let fuID = orderFollowUpID(order: order, day: day, dateKey: dateKey, index: n)
                    let fuContent      = UNMutableNotificationContent()
                    fuContent.title    = "🔔 Pedido pendiente - \(supplierName)"
                    fuContent.body     = "Aún no has confirmado la llegada del pedido"
                    fuContent.sound    = .default
                    fuContent.userInfo = ["type": "order_followup"]

                    let fuComps   = Calendar.current.dateComponents(
                        [.year, .month, .day, .hour, .minute], from: followUpDate)
                    let fuTrigger = UNCalendarNotificationTrigger(dateMatching: fuComps, repeats: false)
                    let fuRequest = UNNotificationRequest(identifier: fuID, content: fuContent, trigger: fuTrigger)
                    UNUserNotificationCenter.current().add(fuRequest)
                }
            }
        }
    }

    /// Cancel all notifications (base + follow-ups) for an order.
    func cancelOrderNotifications(order: Order) {
        var ids: [String] = []
        for day in order.recurringDays {
            ids.append(orderBaseID(order: order, day: day))
            for baseDate in nextOccurrences(weekday: day.rawValue, count: 4) {
                let dateKey = compactDateString(from: baseDate)
                for n in 1...3 {
                    ids.append(orderFollowUpID(order: order, day: day, dateKey: dateKey, index: n))
                }
            }
        }
        UNUserNotificationCenter.current().removePendingNotificationRequests(withIdentifiers: ids)
    }

    /// Cancel only today's follow-up notifications (called when user confirms arrival).
    func cancelOrderFollowUpsForToday(order: Order) {
        let dateKey = compactDateString(from: Date())
        var ids: [String] = []
        for day in order.recurringDays {
            for n in 1...3 {
                ids.append(orderFollowUpID(order: order, day: day, dateKey: dateKey, index: n))
            }
        }
        UNUserNotificationCenter.current().removePendingNotificationRequests(withIdentifiers: ids)
    }

    // MARK: - Private helpers

    private func scheduleWeeklyOrder(id: String, title: String, body: String,
                                     weekday: Int, hour: Int, minute: Int) {
        let content      = UNMutableNotificationContent()
        content.title    = title
        content.body     = body
        content.sound    = .default
        content.badge    = 1
        content.userInfo = ["type": "order"]

        var comps        = DateComponents()
        comps.weekday    = weekday
        comps.hour       = hour
        comps.minute     = minute

        let trigger = UNCalendarNotificationTrigger(dateMatching: comps, repeats: true)
        let request = UNNotificationRequest(identifier: id, content: content, trigger: trigger)
        UNUserNotificationCenter.current().add(request)
    }

    /// Returns the next `count` future dates that fall on `weekday` (1=Sun…7=Sat).
    private func nextOccurrences(weekday: Int, count: Int) -> [Date] {
        var results: [Date] = []
        var current         = Date()
        while results.count < count {
            current = Calendar.current.date(byAdding: .day, value: 1, to: current) ?? current
            if Calendar.current.component(.weekday, from: current) == weekday {
                results.append(current)
            }
        }
        return results
    }

    private func compactDateString(from date: Date) -> String {
        let f = DateFormatter(); f.dateFormat = "yyyyMMdd"
        return f.string(from: date)
    }

    private func orderBaseID(order: Order, day: Weekday) -> String {
        "\(order.notificationBaseID)_\(day.rawValue)"
    }

    private func orderFollowUpID(order: Order, day: Weekday, dateKey: String, index: Int) -> String {
        "\(order.notificationBaseID)_\(day.rawValue)_\(dateKey)_fu\(index)"
    }
}
