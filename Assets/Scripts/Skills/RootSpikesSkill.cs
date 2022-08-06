using Zenject;

public class RootSpikesSkill : Skill, ISkill
{
    public override string ShortName => "+Roots";

    public RootSpikesSpawner.Factory spikeRootsFactory;

    [Inject]
    public void Construct(RootSpikesSpawner.Factory factory)
    {
        spikeRootsFactory = factory;
    }
    public override void LearnSkill()
    {
        var prefab = spikeRootsFactory.Create();
        prefab.SetParent(Player.Instance.gameObject);
    }
}
