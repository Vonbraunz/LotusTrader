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
            ├── data/
            └── db/
```

3. Launch the SPT server — look for `[LotusTrader] Lotus has arrived in Tarkov.` in the log

---

## Trader

| | |
|-|-|
| **Name** | Lotus |
| **Location** | Temporary camp at the outskirts of the city |
| **Currency** | Roubles |
| **PvE support** | Yes |

### Loyalty Levels

| Level | Min Standing | Min Sales |
|-------|-------------|-----------|
| LL1 | 0.00 | ₽0 |
| LL2 | 0.25 | ₽3,659,300 |
| LL3 | 0.45 | ₽6,545,200 |
| LL4 | 0.75 | ₽11,987,500 |

### Assort

- **209 items** available across all loyalty levels (63 / 51 / 50 / 45)
- **71 additional items** unlocked through quests

---

## Quests

**53 quests** across 6 quest lines. All quests support both regular and PvE game modes.

| Quest line | Quests | Type |
|------------|--------|------|
| Introduction | 1 | Elimination |
| Main (Lotus.json) | 24 | Mixed — eliminations, item handovers, skill challenges |
| Ammunition basics | 13 | Item handover (one per calibre) |
| Pokloneniye | 3 | Mixed |
| The Tarkov Cleaner | 7 | Elimination (one per map + finale) |
| Trained Warrior | 5 | Skill |

### Quest lines at a glance

**New Contacts** — Prove yourself to Lotus by clearing scavs across Customs, Shoreline, Factory, and Interchange.

**Main quest line** — 24 quests covering weapon collection, PMC/scav/rogue hunting, item procurement, skill challenges, and more. Unlocks the bulk of Lotus's inventory as you progress.

**Ammunition Basics** — Hand over samples of high-tier ammunition for each major calibre in exchange for standing and stock unlocks. Covers .45 ACP, 12/70, 4.6x30, 9x39mm, .300 Blackout, 5.7x28mm, 5.45x39, 5.56x45, 7.62x39, 7.62x54r, 7.62x51, 12.7x55, and .338 Lapua.

**Pokloneniye** — A three-part quest line.

**The Tarkov Cleaner** — Clear each map of targets: Factory, Reserve, Shoreline, Lighthouse, Customs, Labs, and a finale tying them together.

**Trained Warrior** — Five quests tied to in-game skill progression: combat skills, first aid, scavenger, firearms expert, and sneaky bastard.

---

## Version History

### 2.0.0
- Full port to SPT 4.0.13 (C# server mod)
- Replaced VCQL with WTT CommonLib for quest injection
- Added PvE support
- All 53 quests and 209 assort items carried over from 1.x

### 1.x
- Original TypeScript mod for SPT 3.x using Virtual's Custom Quest Loader

---

## Credits

- **Lunnayaluna** — original mod and all content
- Port to SPT 4.0.13 by **Vonbraunz**
