using System.Reflection;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Routers;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils;
using WTTServerCommonLib;
using Path = System.IO.Path;

namespace LotusTrader;

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class LotusTraderMod(
    ISptLogger<LotusTraderMod> logger,
    ModHelper modHelper,
    ImageRouter imageRouter,
    ConfigServer configServer,
    TimeUtil timeUtil,
    LotusTraderHelper lotusTraderHelper,
    WTTServerCommonLib.WTTServerCommonLib wttCommon
) : IOnLoad
{
    private readonly RagfairConfig _ragfairConfig = configServer.GetConfig<RagfairConfig>();
    private readonly TraderConfig  _traderConfig  = configServer.GetConfig<TraderConfig>();

    public async Task OnLoad()
    {
        var pathToMod = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());

        // 1. Load trader base config
        var traderBase = modHelper.GetJsonDataFromFile<TraderBase>(pathToMod, "data/base.json");

        // 2. Register trader portrait
        var traderImagePath = Path.Combine(pathToMod, "data/lotus.jpg");
        imageRouter.AddRoute(traderBase.Avatar.Replace(".jpg", ""), traderImagePath);

        // 3. Set stock refresh time (1-2 hours)
        lotusTraderHelper.SetTraderUpdateTime(_traderConfig, traderBase,
            minSeconds: timeUtil.GetHoursAsSeconds(1),
            maxSeconds: timeUtil.GetHoursAsSeconds(2));

        // 4. Register with flea market
        _ragfairConfig.Traders.TryAdd(traderBase.Id, true);

        // 5. Add trader to server database
        lotusTraderHelper.AddTraderToDb(traderBase);

        // 6. Add trader locale strings
        lotusTraderHelper.AddTraderToLocales(
            traderBase,
            firstName:   "Lotus",
            description: "Businesswoman who travels around all of Russia."
        );

        // 7. Load assort from JSON and apply
        var assort = modHelper.GetJsonDataFromFile<TraderAssort>(pathToMod, "data/assort.json");
        lotusTraderHelper.ApplyAssort(traderBase.Id, assort);

        // 8. WTT CommonLib: inject quests (QuestAssort/assort.json is handled by CustomQuestService)
        var assembly = Assembly.GetExecutingAssembly();
        await wttCommon.CustomQuestService.CreateCustomQuests(assembly);

        logger.Success("[LotusTrader] Lotus has arrived in Tarkov.");
    }
}
