namespace TheEmperor;

public class PlayerData
{
    public readonly bool IsEmperor;

    public WeakReference<Player> PlayerRef;

    public PlayerData(Player player)
    {
        PlayerRef = new WeakReference<Player>(player);

        IsEmperor = player.slugcatStats.name == TEnums.Emperor;

        if (!IsEmperor) return;
    }
}