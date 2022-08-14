using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class PuffballSkill : Skill, ISkill
{
    public override string ShortName => "Puff";

    public PuffballSpawner.Factory puffballSpawnerFactory;

    public bool IsPiercingEnabled = false;
    public bool IsZigZagEnabled = false;
    public float TimeInterval = 6f;
    public float Speed = 3f;

    [Inject]
    public void Construct(PuffballSpawner.Factory factory)
    {
        puffballSpawnerFactory = factory;
    }
    public override void LearnSkill()
    {
        var prefab = puffballSpawnerFactory.Create();
        prefab.SetParent(Player.Instance.gameObject);


        Player.Instance.EnableHatOne();
        //var hat = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Hat"));
        //var goobus = Player.Instance.gameObject.GetComponentInChildren<GoobusFloater>().gameObject;
        //hat.transform.SetParent(goobus.transform);
        //hat.transform.localScale = new Vector3(1.09f, 1.17f, 1);
        //hat.transform.position = new Vector2(Player.Instance.Position.x, Player.Instance.Position.y-1);
    }
}