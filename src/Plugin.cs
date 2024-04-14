namespace MyMod;

[BepInPlugin(GUID: MOD_ID, Name: MOD_NAME, Version: VERSION)]
class Plugin : BaseUnityPlugin
{
    /// <summary>
    /// These strings are not necessary, but for a matter of preference, it can be done this way and then called anywhere in the code using plugin.MOD_ID
    /// for example, if you want to debug or to reuse the instance when needed instead of rewriting it
    /// </summary>
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_ID = "BensoneWhite.mymod";
    public const string MOD_NAME = "MyMod";
    public const string VERSION = "0.0.1";

    /// <summary>
    /// These bools will be used to ensure that the mod loads only once. 
    /// It is recommended to use them this way because there can sometimes be errors when loading the same hook twice.
    /// Especially in the case of ILHooks or sensitive methods
    /// </summary>
    public bool IsInit;
    public bool IsPreInit;
    public bool IsPostInit;

    /// <summary>
    /// In this template, the BepInEx logger will be used because starting from version 1.9.14, the game logs have changed significantly
    /// </summary>
    public static void LogWarning(object ex) => Logger.LogWarning(ex);

    public static void LogError(object ex) => Logger.LogError(ex);

    public static new ManualLogSource Logger;

    /// <summary>
    /// OnEnable is called when the mod is first loaded when loading the game, before the loading screen. 
    /// It is not recommended to place hooks directly here because Guardian will not be able to detect errors prematurely if it were to encounter them
    /// </summary>
    public void OnEnable()
    {
        try
        {
            Logger = base.Logger;
            
            On.RainWorld.PreModsInit += RainWorld_PreModsInit;
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;
            On.RainWorld.PostModsInit += RainWorld_PostModsInit;

            //This prints in the OutPutLog, your mod and actual version
            LogWarning($"{MOD_NAME} is loading... {VERSION}");
        }
        catch (Exception e)
        {
            //If for some reason this fails to load it will catch the error
            LogError(e);
        }
    }

    /// <summary>
    /// This will load before all other OnModsInit. 
    /// For compatibility, there are cases where it's necessary to load before other mods, prior to OnModsInit
    /// </summary>
    private void RainWorld_PreModsInit(On.RainWorld.orig_PreModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsPreInit) return;
            IsPreInit = true;
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    /// <summary>
    /// This is the normal loading method for most mods. 
    /// It's neither too early nor too late; it's an intermediate point to initialize hooks or apply other classes containing hooks. 
    /// It's recommended to initialize hooks and resources here
    /// </summary>
    private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsInit) return;
            IsInit = true;

            LoadAtlases();
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    /// <summary>
    /// After most mods have loaded, there's an additional method that allows you to go even further and apply hooks that you otherwise couldn't due to incompatibility with another mod. 
    /// For example, when you want to prioritize another mod to load before yours, and then apply changes to it for compatibility reasons
    /// </summary>
    private void RainWorld_PostModsInit(On.RainWorld.orig_PostModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsPostInit) return;
            IsPostInit = true;
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
            //The string called "My_Atlases" must be the folder name inside the mod folder
            foreach (var file in from file in AssetManager.ListDirectory("My_Atlases")
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
