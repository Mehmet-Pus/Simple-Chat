//
//  Item.swift
//  Simple Chat
//
//  Created by Sevcan Alkan on 1.03.24.
//

import Foundation
import SwiftData

@Model
final class Item {
    var timestamp: Date
    
    init(timestamp: Date) {
        self.timestamp = timestamp
    }
}
