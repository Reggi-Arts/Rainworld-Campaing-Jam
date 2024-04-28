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

    }

    public static class SandboxUnlock
    {

    }
}