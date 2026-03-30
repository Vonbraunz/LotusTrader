using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils.Cloners;

namespace LotusTrader;

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class LotusTraderHelper(
    ISptLogger<LotusTraderHelper> logger,
    ICloner cloner,
    DatabaseService databaseService
)
{
    public void SetTraderUpdateTime(TraderConfig traderConfig, TraderBase traderBase,
        int minSeconds, int maxSeconds)
    {
        traderConfig.UpdateTime.Add(new UpdateTime
        {
            TraderId = traderBase.Id,
            Seconds  = new MinMax<int>(minSeconds, maxSeconds)
        });
    }

    public void AddTraderToDb(TraderBase traderBase)
    {
        var trader = new Trader
        {
            Base   = cloner.Clone(traderBase),
            Assort = new TraderAssort
            {
                Items           = [],
                BarterScheme    = new Dictionary<MongoId, List<List<BarterScheme>>>(),
                LoyalLevelItems = new Dictionary<MongoId, int>()
            },
            QuestAssort = new()
            {
                { "Started", new() },
                { "Success", new() },
                { "Fail",    new() }
            },
            Dialogue = []
        };

        if (!databaseService.GetTables().Traders.TryAdd(traderBase.Id, trader))
            logger.Warning($"[LotusTrader] Failed to add trader {traderBase.Id} — already exists?");
    }

    public void AddTraderToLocales(TraderBase traderBase, string firstName, string description)
    {
        var locales = databaseService.GetTables().Locales.Global;
        var id      = traderBase.Id;

        foreach (var (_, lazyLocale) in locales)
        {
            lazyLocale.AddTransformer(locale =>
            {
                locale[$"{id} FullName"]    = traderBase.Name;
                locale[$"{id} FirstName"]   = firstName;
                locale[$"{id} Nickname"]    = traderBase.Nickname;
                locale[$"{id} Location"]    = traderBase.Location;
                locale[$"{id} Description"] = description;
                return locale;
            });
        }
    }

    public void ApplyAssort(string traderId, TraderAssort assort)
    {
        if (!databaseService.GetTables().Traders.TryGetValue(traderId, out var trader))
        {
            logger.Warning($"[LotusTrader] Could not apply assort — trader {traderId} not found.");
            return;
        }
        trader.Assort = assort;
    }
}
