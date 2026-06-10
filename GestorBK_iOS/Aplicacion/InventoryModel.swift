import Foundation

// MARK: - User

struct InvUser: Identifiable, Codable {
    let id: Int
    let username: String
    let role: String       // "operator" | "manager"
    let active: Int        // 1 = active, 0 = inactive
    let created_at: String?

    var isActive: Bool { active == 1 }
    var roleLabel: String { role == "manager" ? "Manager" : "Operador" }
}

// MARK: - Entry (list, without items)

struct InvEntry: Identifiable, Codable {
    let id: Int
    let moment: String          // "apertura" | "cierre"
    let entry_date: String      // "YYYY-MM-DD"
    let submitted_at: String
    let submitted_by: String?
    let operator_name: String?

    var submittedBy: String { submitted_by ?? operator_name ?? "Desconocido" }
    var momentLabel: String { moment == "apertura" ? "Apertura" : "Cierre" }

    var submittedTime: String {
        // Extract HH:MM from "YYYY-MM-DD HH:MM:SS"
        let parts = submitted_at.split(separator: " ")
        guard parts.count > 1 else { return submitted_at }
        let time = parts[1].prefix(5)
        return String(time)
    }
}

// MARK: - Entry detail (with items)

struct InvEntryDetail: Identifiable, Codable {
    let id: Int
    let moment: String
    let entry_date: String
    let submitted_at: String
    let submitted_by: String?
    let operator_name: String?
    let items: [InvItem]

    var submittedBy: String { submitted_by ?? operator_name ?? "Desconocido" }
    var momentLabel: String { moment == "apertura" ? "Apertura" : "Cierre" }

    var submittedTime: String {
        let parts = submitted_at.split(separator: " ")
        guard parts.count > 1 else { return submitted_at }
        return String(parts[1].prefix(5))
    }

    func item(for key: String) -> InvItem? {
        items.first { $0.product_key == key }
    }
}

// MARK: - Item

struct InvItem: Identifiable, Codable {
    let id: Int
    let entry_id: Int
    let product_key: String
    let unit1_count: Double
    let unit2_count: Double
    let loose_count: Double
}

// MARK: - Product catalog (static)

struct InvProduct {
    let key: String
    let name: String
    let unit1Name: String
    let unit1Factor: Double
    let unit2Name: String?
    let unit2Factor: Double

    func total(unit1: Double, unit2: Double, loose: Double) -> Double {
        (unit1 * unit1Factor) + (unit2 * unit2Factor) + loose
    }

    static func find(_ key: String) -> InvProduct? {
        all.first { $0.key == key }
    }

    static let all: [InvProduct] = [
        InvProduct(key: "pan_brioche",    name: "Pan Brioche Krispper",    unit1Name: "Gaveta",  unit1Factor: 35,  unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "pan_grande_h2",  name: "Pan Grande H2",           unit1Name: "Gaveta",  unit1Factor: 28,  unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "pan_largo_h3",   name: "Pan Largo H3",            unit1Name: "Gaveta",  unit1Factor: 32,  unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "pan_pequeno_h0", name: "Pan Pequeño H0",          unit1Name: "Gaveta",  unit1Factor: 48,  unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "alitas_pollo",   name: "Alitas De Pollo",         unit1Name: "Caja",    unit1Factor: 285, unit2Name: "Paquete", unit2Factor: 57),
        InvProduct(key: "carne_burger",   name: "Carne Burger",            unit1Name: "Caja",    unit1Factor: 320, unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "carne_whopper",  name: "Carne Whopper",           unit1Name: "Caja",    unit1Factor: 148, unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "crispy_chicken", name: "Crispy Chicken",          unit1Name: "Caja",    unit1Factor: 320, unit2Name: "Bolsa",  unit2Factor: 17),
        InvProduct(key: "premium_crispy", name: "Premium Crispy Chicken",  unit1Name: "Caja",    unit1Factor: 80,  unit2Name: "Bolsa",  unit2Factor: 10),
        InvProduct(key: "patatas",        name: "Patatas",                 unit1Name: "Caja",    unit1Factor: 12.5, unit2Name: "Bolsa", unit2Factor: 2.5),
        InvProduct(key: "patatas_sup",    name: "Patatas Supreme",         unit1Name: "Caja",    unit1Factor: 10,  unit2Name: "Bolsa",  unit2Factor: 2.5),
        InvProduct(key: "mix_vainilla",   name: "Mix Vainilla",            unit1Name: "Caja",    unit1Factor: 320, unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "cebolla_5",      name: "Cebolla (Caja 5)",        unit1Name: "Caja",    unit1Factor: 5,   unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "cebolla_10",     name: "Cebolla (Caja 10)",       unit1Name: "Caja",    unit1Factor: 10,  unit2Name: nil,      unit2Factor: 0),
        InvProduct(key: "lechuga",        name: "Lechuga",                 unit1Name: "Caja",    unit1Factor: 6,   unit2Name: "Bolsa",  unit2Factor: 1),
        InvProduct(key: "tomate_natural", name: "Tomate Natural",          unit1Name: "Caja",    unit1Factor: 6,   unit2Name: nil,      unit2Factor: 0),
    ]
}

// MARK: - Day snapshot (cierre + apertura for one date)

struct InvDaySnapshot {
    let date: String               // "YYYY-MM-DD"
    var cierre: InvEntryDetail?
    var apertura: InvEntryDetail?

    var hasBoth: Bool  { cierre != nil && apertura != nil }
    var hasAny: Bool   { cierre != nil || apertura != nil }

    var displayDate: String {
        let f = DateFormatter()
        f.locale = Locale(identifier: "es_ES")
        f.dateFormat = "yyyy-MM-dd"
        guard let d = f.date(from: date) else { return date }
        f.dateStyle = .full
        f.timeStyle = .none
        return f.string(from: d).capitalized
    }
}

// MARK: - Number formatting helper

func invFmt(_ v: Double) -> String {
    v.truncatingRemainder(dividingBy: 1) == 0
        ? String(Int(v))
        : String(format: "%.1f", v)
}
