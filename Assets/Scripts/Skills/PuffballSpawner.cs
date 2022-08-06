using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PuffballSpawner : MonoBehaviour, IHasSkillFactory
{
    private Puffball.Factory puffFactory;
    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(Puffball.Factory factory, ITimer timer)
    {
        puffFactory = factory;
        Timer = timer;
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
        SpawnProjectile(new Vector2(1, 0));
        SpawnProjectile(new Vector2(-1, 0));
        SpawnProjectile(new Vector2(0, 1));
        SpawnProjectile(new Vector2(0, -1));
    }

    private void SpawnProjectile(Vector2 direction)
    {
        var obj = puffFactory.Create();
        obj.Setup(direction, Player.Instance.ProjectileAttackSpeed / 2, Player.Instance.Position);
    }
}
