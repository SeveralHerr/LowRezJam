using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PuffballSpawner : MonoBehaviour
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
        var obj = puffFactory.Create();
        var positionOffset = Player.Instance.Position + new Vector2(1, 1);

        obj.Setup(new Vector2(1, 0), Player.Instance.ProjectileAttackSpeed / 2, positionOffset);
        obj.Setup(new Vector2(-1, 0), Player.Instance.ProjectileAttackSpeed / 2, positionOffset);
        obj.Setup(new Vector2(0, 1), Player.Instance.ProjectileAttackSpeed / 2, positionOffset);
        obj.Setup(new Vector2(0, -1), Player.Instance.ProjectileAttackSpeed / 2, positionOffset);
    }
}
