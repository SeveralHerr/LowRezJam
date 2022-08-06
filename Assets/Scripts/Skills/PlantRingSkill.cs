using Zenject;

public class PlantRingSkill : Skill, ISkill
{
    public override string ShortName => "Ring";

    public PlantRingSpawner.Factory plantRingFactory;

    [Inject]
    public void Construct(PlantRingSpawner.Factory factory)
    {
        plantRingFactory = factory;
    }
    public override void LearnSkill()
    {
        var prefab = plantRingFactory.Create();
        prefab.SetParent(Player.Instance.gameObject);
    }
}