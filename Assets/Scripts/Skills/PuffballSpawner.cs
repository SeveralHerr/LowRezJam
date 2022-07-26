using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PuffballSpawner : MonoBehaviour, IHasSkillFactory
{
    private Puffball.Factory puffFactory;
    private PuffballSkill PuffballSkill;
    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(Puffball.Factory factory, ITimer timer, PuffballSkill puffballSkill)
    {
        puffFactory = factory;
        Timer = timer;
        PuffballSkill = puffballSkill;
    }

    public class Factory : PlaceholderFactory<string, PuffballSpawner>
    {
        public PuffballSpawner Create()
        {
            return base.Create($"Prefabs/{nameof(PuffballSpawner)}");
        }
    }

    void Update()
    {
        Timer.RunTimer(3f, () => SpawnProjectiles());
    }

    public void SetParent(GameObject obj)
    {
        transform.SetParent(obj.transform);
    }

    private void SpawnProjectiles()
    {
        var random = Random.Range(0, 4);
        if (random == 0)
        {
            SpawnProjectile(new Vector2(1, 0));
        }
        else if (random == 1)
        {
            SpawnProjectile(new Vector2(-1, 0));
        }
        else if (random == 2)
        {
            SpawnProjectile(new Vector2(0, 1));
        }
        else if (random == 3)
        {
            SpawnProjectile(new Vector2(0, -1));
        }
    }

    private void SpawnProjectile(Vector2 direction)
    {
        var obj = puffFactory.Create();
        obj.Setup(direction, PuffballSkill.Speed, Player.Instance.Position);
    }
}
