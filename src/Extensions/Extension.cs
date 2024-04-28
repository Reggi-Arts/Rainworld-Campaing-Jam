using SlugBase.Features;

namespace TheEmperor;

public static class Extension
{
    private static readonly ConditionalWeakTable<Player, PlayerData> _cwtte = new();

    public static PlayerData Emperor(this Player player) => _cwtte.GetValue(player, _ => new PlayerData(player));

    public static bool IsEmperor(this Player player) => player.Emperor().IsEmperor;

    public static bool IsNightWalker(this Player player, out PlayerData Emperor)
    {
        Emperor = player.Emperor();
        return Emperor.IsEmperor;
    }
}