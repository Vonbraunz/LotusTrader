using SPTarkov.Server.Core.Models.Spt.Mod;
using Range = SemanticVersioning.Range;

namespace LotusTrader;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid    { get; init; } = "com.lunnayaluna.lotustrader";
    public override string Name       { get; init; } = "LotusTrader";
    public override string Author     { get; init; } = "Lunnayaluna";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("2.0.0");
    public override Range SptVersion  { get; init; } = new("~4.0.13");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public override string? Url       { get; init; }
    public override bool? IsBundleMod { get; init; } = true;
    public override string License    { get; init; } = "MIT";
}
