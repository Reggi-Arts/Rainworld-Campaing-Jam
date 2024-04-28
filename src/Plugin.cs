using TheEmperor;

namespace MyMod;

[BepInPlugin(GUID: MOD_ID, Name: MOD_NAME, Version: VERSION)]
class Plugin : BaseUnityPlugin
{
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_ID = "emperor";
    public const string MOD_NAME = "The Emperor";
    public const string VERSION = "0.0.1";

    public bool IsInit;

    public static void LogWarning(object ex) => Logger.LogWarning(ex);

    public static void LogError(object ex) => Logger.LogError(ex);

    public static new ManualLogSource Logger;

    public void OnEnable()
    {
        try
        {
            Logger = base.Logger;
            
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;

            TEnums.Init();

            LogWarning($"{MOD_NAME} is loading... {VERSION}");
        }
        catch (Exception e)
        {
            LogError(e);
        }
    }

    private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsInit) return;
            IsInit = true;

            EmperorHooks.Init();
            EmperorWorld.Init();

            LoadAtlases();
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    private void LoadAtlases()
    {
        try
        {
            foreach (var file in from file in AssetManager.ListDirectory("rcj_atlases")
                                 where (Path.GetExtension(file).Equals(".png"))
                                 select file)
            {
                if (File.Exists(Path.ChangeExtension(file, ".txt")))
                {
                    Futile.atlasManager.LoadAtlas(Path.ChangeExtension(file, null));
                }
                else
                {
                    Futile.atlasManager.LoadImage(Path.ChangeExtension(file, null));
                }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
            throw new Exception($"Failed to load {MOD_NAME} atlases!");
        }
    }
}
