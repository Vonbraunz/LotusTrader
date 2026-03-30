# LotusTrader

A custom trader mod for [SPT](https://www.sp-tarkov.com/) — adds **Lotus**, a travelling businesswoman operating out of a camp on the outskirts of Tarkov. She sells a wide selection of weapons, ammunition, gear, and equipment, with additional stock unlocked through her quest line.

---

## Requirements

| Dependency | Version |
|------------|---------|
| SPT | 4.0.13 |
| [WTT Server Common Library](https://hub.sp-tarkov.com/files/file/1301-wtt-server-common-library/) | 2.0.0 |

---

## Installation

1. Download the latest release
2. Extract the `LotusTrader` folder into your SPT `user/mods/` directory

```
SPT/
└── user/
    └── mods/
        └── LotusTrader/
            ├── LotusTrader.dll
            ├── bundles.json
            ├── bundles/
            ├── data/
            └── db/
```

3. Launch the SPT server — look for `[LotusTrader] Lotus has arrived in Tarkov.` in the log

---

## Trader

| | |
|-|-|
| **Name** | Lotus |
| **Location** | Hidden camp at the outskirts of the city |
| **Currency** | Roubles |
| **PvE support** | Yes |

### Loyalty Levels

| Level | Min Level | Min Standing | Min Sales |
|-------|-----------|-------------|-----------|
| LL1 | 0 | 0.00 | ₽0 |
| LL2 | 22 | 0.50 | ₽1,150,000 |
| LL3 | 33 | 1.00 | ₽5,250,000 |
| LL4 | 44 | 1.50 | ₽7,500,000 |

### Assort

- **917 items** across all loyalty levels
- Additional items unlocked through quests
- **1 custom item** — Lotus' Modified TerraGroup Labs Access Keycard (LL4 barter, flea-blacklisted)

---

## Quests

**343 quests** across multiple quest lines. All quests support both regular and PvE game modes.

### Quest lines

**New Contacts** — Prove yourself to Lotus by clearing scavs across Customs, Shoreline, Factory, and Interchange.

**Main quest line** — Weapon collection, PMC/scav/rogue hunting, item procurement, skill challenges, and more. Unlocks the bulk of Lotus's inventory as you progress.

**Ammunition Basics** — Hand over samples of high-tier ammunition for each major calibre in exchange for standing and stock unlocks. Covers .45 ACP, 12/70, 4.6x30, 9x39mm, .300 Blackout, 5.7x28mm, 5.45x39, 5.56x45, 7.62x39, 7.62x54r, 7.62x51, 12.7x55, and .338 Lapua.

**Pokloneniye** — A three-part quest line.

**The Tarkov Cleaner** — Clear each map of targets: Factory, Reserve, Shoreline, Lighthouse, Customs, Labs, Woods, and a finale.

**Trained Warrior** — Quests tied to in-game skill progression: combat skills, first aid, scavenger, firearms expert, and sneaky bastard.

---

## Version History

### 2.1.0
- Upgraded to unreleased dev build content (343 quests, 917 assort items, 253 quest images)
- Added custom item: Lotus' Modified TerraGroup Labs Access Keycard
- Updated loyalty level thresholds
- Updated trader avatar

### 2.0.0
- Full port to SPT 4.0.13 (C# server mod)
- Replaced VCQL with WTT CommonLib for quest injection
- Added PvE support

### 1.x
- Original TypeScript mod for SPT 3.x using Virtual's Custom Quest Loader

---

## Credits

- **Lunnayaluna** — original mod and all content
- Port to SPT 4.0.13 by **Vonbraunz**
