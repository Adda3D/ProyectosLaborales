import SwiftUI

// MARK: - Content View (TabView)

struct ContentView: View {
    @EnvironmentObject var store: ReminderStore
    @EnvironmentObject var notificationManager: NotificationManager
    @EnvironmentObject var orderStore: OrderStore
    @EnvironmentObject var maintenanceStore: MaintenanceStore
    @EnvironmentObject var waStore: WAStore
    @EnvironmentObject var inventoryStore: InventoryStore

    var pendingOrders: Int       { orderStore.pendingConfirmationOrders.count }
    var pendingMaint: Int        { maintenanceStore.pending.count }

    var body: some View {
        TabView {
            // MARK: Tab 1 — Recordatorios
            NavigationStack {
                RemindersHomeView()
            }
            .tabItem {
                Label("Recordatorios", systemImage: "bell.fill")
            }

            // MARK: Tab 2 — Pedidos
            NavigationStack {
                OrdersView()
            }
            .badge(pendingOrders)
            .tabItem {
                Label("Pedidos", systemImage: "shippingbox.fill")
            }

            // MARK: Tab 3 — Mantenimiento
            NavigationStack {
                MaintenanceView()
            }
            .badge(pendingMaint)
            .tabItem {
                Label("Mantenimiento", systemImage: "wrench.and.screwdriver.fill")
            }

            // MARK: Tab 4 — WhatsApp
            NavigationStack {
                WAView()
            }
            .tabItem {
                Label("WhatsApp", systemImage: "message.fill")
            }

            // MARK: Tab 5 — Inventario
            NavigationStack {
                InventarioView()
            }
            .tabItem {
                Label("Inventario", systemImage: "tablecells.fill")
            }
        }
    }
}

// MARK: - Reminders Home

struct RemindersHomeView: View {
    @EnvironmentObject var store: ReminderStore
    @State private var showingAdd = false

    var body: some View {
        List {
            Section {
                NavigationLink {
                    AllRemindersView(showingAdd: $showingAdd)
                } label: {
                    Label {
                        HStack {
                            Text("Todos")
                                .font(.system(.body, design: .rounded, weight: .medium))
                            Spacer()
                            if store.allUpcoming.count > 0 {
                                Text("\(store.allUpcoming.count)")
                                    .font(.caption.bold())
                                    .foregroundStyle(.white)
                                    .padding(.horizontal, 8)
                                    .padding(.vertical, 3)
                                    .background(Color.gray.gradient, in: Capsule())
                            }
                        }
                    } icon: {
                        Image(systemName: "bell.fill")
                            .foregroundStyle(.gray)
                    }
                }
            }

            Section("Categorías") {
                ForEach(ReminderCategory.allCases) { category in
                    NavigationLink {
                        ReminderListView(category: category, showingAdd: $showingAdd)
                    } label: {
                        CategoryRowView(
                            category: category,
                            count: store.upcoming(for: category).count
                        )
                    }
                }
            }
        }
        .listStyle(.insetGrouped)
        .navigationTitle("Recordatorios")
        .navigationBarTitleDisplayMode(.large)
        .toolbar {
            ToolbarItem(placement: .primaryAction) {
                Button { showingAdd = true } label: {
                    Image(systemName: "plus.circle.fill")
                        .font(.title3)
                }
            }
        }
        .sheet(isPresented: $showingAdd) {
            AddEditReminderView(existingReminder: nil)
        }
    }
}

// MARK: - Category Row

struct CategoryRowView: View {
    let category: ReminderCategory
    let count: Int

    var body: some View {
        HStack(spacing: 12) {
            ZStack {
                RoundedRectangle(cornerRadius: 8, style: .continuous)
                    .fill(category.gradient)
                    .frame(width: 32, height: 32)
                Image(systemName: category.icon)
                    .font(.system(size: 15, weight: .semibold))
                    .foregroundStyle(.white)
            }
            Text(category.rawValue)
                .font(.system(.body, design: .rounded, weight: .medium))
            Spacer()
            if count > 0 {
                Text("\(count)")
                    .font(.caption.bold())
                    .foregroundStyle(.white)
                    .padding(.horizontal, 8)
                    .padding(.vertical, 3)
                    .background(category.gradient, in: Capsule())
            }
        }
    }
}
