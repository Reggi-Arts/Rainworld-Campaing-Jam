using System.Data;

namespace TheEmperor;

public class TEnums
{
    public readonly static SlugcatStats.Name Emperor = new("Emperor");

    public static void Init()
    {
        RuntimeHelpers.RunClassConstructor(typeof(CreatureType).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(SandboxUnlock).TypeHandle);
    }

    public static void Unregister()
    {
        Utils.UnregisterEnums(typeof(CreatureType));
        Utils.UnregisterEnums(typeof(SandboxUnlock));
    }

    public static class CreatureType
    {
        public static CreatureTemplate.Type Pidgeon = new(nameof(Pidgeon), true);
        public static CreatureTemplate.Type Racoon = new(nameof(Racoon), true);
        public static CreatureTemplate.Type Rat = new(nameof(Rat), true);
    }

    public static class SandboxUnlock
    {
        public static MultiplayerUnlocks.SandboxUnlockID Pidgeon = new(nameof(Pidgeon), true);
        public static MultiplayerUnlocks.SandboxUnlockID Racoon = new(nameof(Racoon), true);
        public static MultiplayerUnlocks.SandboxUnlockID Rat = new(nameof(Rat), true);
    }
}