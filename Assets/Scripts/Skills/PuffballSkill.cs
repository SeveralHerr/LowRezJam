using Zenject;

public class PuffballSkill : Skill, ISkill
{
    public override string ShortName => "Puff";

    public PuffballSpawner.Factory puffballSpawnerFactory;

    [Inject]
    public void Construct(PuffballSpawner.Factory factory)
    {
        puffballSpawnerFactory = factory;
    }
    public override void LearnSkill()
    {
        var prefab = puffballSpawnerFactory.Create();
        prefab.SetParent(Player.Instance.gameObject);
    }
}