using DevInterface;

namespace TheEmperor;

public class RatCritob : Critob
{
    public RatCritob() : base(TEnums.CreatureType.Rat)
    {
        Icon = new SimpleIcon("Kill_Mouse", Color.gray);
        LoadedPerformanceCost = 20;
        SandboxPerformanceCost = new SandboxPerformanceCost(0.2f, 0.2f);
        ShelterDanger = ShelterDanger.Safe;
        CreatureName = nameof(TEnums.CreatureType.Rat);
        RegisterUnlock(KillScore.Configurable(5), TEnums.SandboxUnlock.Rat);
    }

    public override CreatureState CreateState(AbstractCreature acrit) => new MouseState(acrit);

    public override CreatureType ArenaFallback() => CreatureType.LanternMouse;

    public override string DevtoolsMapName(AbstractCreature acrit) => "Rat";

    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.black;

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new MouseAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new LanternMouse(acrit, acrit.world);

    public override IEnumerable<string> WorldFileAliases() => [nameof(TEnums.CreatureType.Rat)];

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => [RoomAttractivenessPanel.Category.Lizards];

    public override int ExpeditionScore() => 5;

    public override CreatureTemplate CreateTemplate()
    {
        var s = new CreatureFormula(CreatureType.LanternMouse, TEnums.CreatureType.Rat, nameof(TEnums.CreatureType.Rat))
        {
            HasAI = true,
            Pathing = PreBakedPathing.Ancestral(CreatureType.LanternMouse)
        }.IntoTemplate();
        return s;
    }

    public override void EstablishRelationships()
    {
        var result = new Relationships(Type);
        result.Ignores(Type);
    }
}
