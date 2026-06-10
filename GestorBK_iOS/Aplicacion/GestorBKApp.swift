import SwiftUI

@main
struct GestorBKApp: App {
    @StateObject private var store               = ReminderStore()
    @StateObject private var notificationManager = NotificationManager()
    @StateObject private var orderStore          = OrderStore()
    @StateObject private var maintenanceStore    = MaintenanceStore()
    @StateObject private var waStore             = WAStore()
    @StateObject private var inventoryStore      = InventoryStore()

    var body: some Scene {
        WindowGroup {
            ContentView()
                .environmentObject(store)
                .environmentObject(notificationManager)
                .environmentObject(orderStore)
                .environmentObject(maintenanceStore)
                .environmentObject(waStore)
                .environmentObject(inventoryStore)
                .onAppear {
                    notificationManager.requestPermission()
                }
        }
    }
}
