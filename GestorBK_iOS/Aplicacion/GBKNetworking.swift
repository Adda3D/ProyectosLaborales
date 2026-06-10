import Foundation

// MARK: - Shared networking utilities for GestorBK
// All stores talk to the same server. This file centralises:
//  - The default server base URL
//  - A robust JSONDecoder that handles ISO 8601 with AND without fractional seconds,
//    plus the SQLite-native "yyyy-MM-dd HH:mm:ss" format (fallback)
//  - A JSONEncoder that always sends ISO 8601 without fractional seconds
//  - A decode helper that prints the exact DecodingError to the console instead
//    of silently returning nil

enum GBKNet {

    // MARK: - Server

    static let defaultBase = "http://204.48.16.192:3000"

    static func serverURL() -> String {
        let raw = UserDefaults.standard.string(forKey: "wa_server_url") ?? ""
        var base = raw.isEmpty ? defaultBase : raw
        // Strip trailing slashes so "http://host:3000/" + "/api/x" never becomes "host:3000//api/x"
        while base.hasSuffix("/") { base = String(base.dropLast()) }
        return base
    }

    // MARK: - Encoder (ISO 8601, no fractional seconds)

    static func encoder() -> JSONEncoder {
        let e = JSONEncoder()
        e.dateEncodingStrategy = .iso8601   // "2024-05-15T10:30:00Z"
        return e
    }

    // MARK: - Decoder (robust multi-format date parsing)

    static func decoder() -> JSONDecoder {
        let d = JSONDecoder()
        d.dateDecodingStrategy = .custom { dec in
            let container = try dec.singleValueContainer()
            let str = try container.decode(String.self)

            // 1️⃣ ISO 8601 with fractional seconds: "2024-05-15T10:30:00.000Z"
            let f1 = ISO8601DateFormatter()
            f1.formatOptions = [.withInternetDateTime, .withFractionalSeconds]
            if let date = f1.date(from: str) { return date }

            // 2️⃣ ISO 8601 without fractional seconds: "2024-05-15T10:30:00Z"
            let f2 = ISO8601DateFormatter()
            f2.formatOptions = [.withInternetDateTime]
            if let date = f2.date(from: str) { return date }

            // 3️⃣ SQLite datetime fallback: "2024-05-15 10:30:00"
            let f3 = DateFormatter()
            f3.dateFormat = "yyyy-MM-dd HH:mm:ss"
            f3.timeZone = TimeZone(identifier: "UTC")
            if let date = f3.date(from: str) { return date }

            // 4️⃣ Date-only: "2024-05-15"
            let f4 = DateFormatter()
            f4.dateFormat = "yyyy-MM-dd"
            f4.timeZone = TimeZone(identifier: "UTC")
            if let date = f4.date(from: str) { return date }

            throw DecodingError.dataCorruptedError(
                in: container,
                debugDescription: "GBKNet: no date format matched '\(str)'"
            )
        }
        return d
    }

    // MARK: - Typed decode with visible error logging

    /// Use this instead of `try? JSONDecoder().decode(...)` everywhere.
    /// On failure it prints the exact field that failed instead of silently returning nil.
    @discardableResult
    static func decode<T: Decodable>(_ type: T.Type,
                                     from data: Data,
                                     context: String) -> T? {
        do {
            return try decoder().decode(type, from: data)
        } catch {
            print("⛔ [\(context)] DecodingError: \(error)")
            if let raw = String(data: data, encoding: .utf8) {
                print("   Raw JSON (first 800 chars): \(raw.prefix(800))")
            }
            return nil
        }
    }

    // MARK: - Resilient array decode (skips corrupted items instead of failing everything)

    /// Decodes a JSON array skipping any elements that fail, instead of returning nil for the whole list.
    /// Use this for GET endpoints where occasional bad/test data should not block valid records.
    static func decodeArray<T: Decodable>(_ type: T.Type,
                                          from data: Data,
                                          context: String) -> [T] {
        // First try normal decode (fast path — works when all items are valid)
        if let result = decode([T].self, from: data, context: context) {
            return result
        }

        // Slow path: decode item by item, skip the bad ones
        guard let jsonArray = try? JSONSerialization.jsonObject(with: data) as? [[String: Any]] else {
            print("⛔ [\(context)] Could not parse JSON as array for item-by-item fallback")
            return []
        }

        var valid: [T] = []
        let dec = decoder()
        for (index, item) in jsonArray.enumerated() {
            do {
                let itemData = try JSONSerialization.data(withJSONObject: item)
                let decoded  = try dec.decode(T.self, from: itemData)
                valid.append(decoded)
            } catch {
                print("⚠️ [\(context)] Skipping item[\(index)] — \(error)")
            }
        }
        print("ℹ️ [\(context)] Loaded \(valid.count)/\(jsonArray.count) items (skipped \(jsonArray.count - valid.count) invalid)")
        return valid
    }
}
