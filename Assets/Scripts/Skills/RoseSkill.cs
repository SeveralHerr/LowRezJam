using Zenject;

public class RoseSkill : Skill, ISkill
{
    public override string ShortName => "Rose";

    public RoseSpawner.Factory roseSpawnerFactory;

    [Inject]
    public void Construct(RoseSpawner.Factory factory)
    {
        roseSpawnerFactory = factory;
    }
    public override void LearnSkill()
    {
        var roseSpawnerPrefab = roseSpawnerFactory.Create();
        roseSpawnerPrefab.SetParent(Player.Instance.gameObject);
    }
}