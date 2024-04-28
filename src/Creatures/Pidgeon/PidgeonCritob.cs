using DevInterface;

namespace TheEmperor;

public class PidgeonCritob : Critob
{
    public PidgeonCritob() : base(TEnums.CreatureType.Pidgeon)
    {
        Icon = new SimpleIcon("Kill_Vulture", Color.gray);
        LoadedPerformanceCost = 20;
        SandboxPerformanceCost = new SandboxPerformanceCost(0.2f, 0.2f);
        ShelterDanger = ShelterDanger.TooLarge;
        CreatureName = nameof(TEnums.CreatureType.Pidgeon);
        RegisterUnlock(KillScore.Configurable(5), TEnums.SandboxUnlock.Pidgeon);
    }

    public override CreatureState CreateState(AbstractCreature acrit) => new Vulture.VultureState(acrit);

    public override CreatureType ArenaFallback() => CreatureType.Vulture;

    public override string DevtoolsMapName(AbstractCreature acrit) => "Pidgeon";

    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.black;

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new VultureAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new Vulture(acrit, acrit.world);

    public override IEnumerable<string> WorldFileAliases() => [nameof(TEnums.CreatureType.Pidgeon)];

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => [RoomAttractivenessPanel.Category.Flying];

    public override int ExpeditionScore() => 5;

    public override CreatureTemplate CreateTemplate()
    {
        var s = new CreatureFormula(CreatureType.Vulture, TEnums.CreatureType.Pidgeon, nameof(TEnums.CreatureType.Pidgeon))
        {
            HasAI = true,
            Pathing = PreBakedPathing.Ancestral(CreatureType.Vulture)
        }.IntoTemplate();
        return s;
    }

    public override void EstablishRelationships()
    {
        var result = new Relationships(Type);
        result.Ignores(Type);
    }
}
