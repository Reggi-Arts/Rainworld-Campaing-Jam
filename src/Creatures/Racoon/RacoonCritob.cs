using DevInterface;

namespace TheEmperor;

public class RacoonCritob : Critob
{
    public RacoonCritob() : base(TEnums.CreatureType.Racoon)
    {
        Icon = new SimpleIcon("Kill_Yellow_Lizard", Color.black);
        LoadedPerformanceCost = 100f;
        SandboxPerformanceCost = new SandboxPerformanceCost(1f, 1f);
        ShelterDanger = ShelterDanger.Hostile;
        CreatureName = nameof(TEnums.CreatureType.Racoon);
        RegisterUnlock(KillScore.Configurable(10), TEnums.SandboxUnlock.Racoon);
    }

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new LizardAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new Racoon(acrit, acrit.world);

    public override CreatureTemplate CreateTemplate() => LizardBreeds.BreedTemplate(Type, StaticWorld.GetCreatureTemplate(CreatureType.LizardTemplate), StaticWorld.GetCreatureTemplate(CreatureType.PinkLizard), StaticWorld.GetCreatureTemplate(CreatureType.BlueLizard), StaticWorld.GetCreatureTemplate(CreatureType.GreenLizard));

    public override string DevtoolsMapName(AbstractCreature acrit) => "Racoon";

    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.black;

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => [RoomAttractivenessPanel.Category.Lizards];

    public override IEnumerable<string> WorldFileAliases() => [nameof(TEnums.CreatureType.Racoon)];

    public override CreatureType ArenaFallback() => CreatureType.GreenLizard;

    public override int ExpeditionScore() => 10;

    public override CreatureState CreateState(AbstractCreature acrit) => new LizardState(acrit);

    public override void EstablishRelationships()
    {
        var self = new Relationships(Type);

        self.Eats(CreatureType.Slugcat, 1f);
        self.Attacks(CreatureType.Scavenger, 1f);
    }
}