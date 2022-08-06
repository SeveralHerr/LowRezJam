using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlantRingSpawner : MonoBehaviour, IHasSkillFactory
{
    private PlantRing.Factory PlantRingFactory { get; set; }
    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(PlantRing.Factory factory, ITimer timer)
    {
        PlantRingFactory = factory;
        Timer = timer;
    }

    public class Factory : PlaceholderFactory<string, PlantRingSpawner>
    {
        public PlantRingSpawner Create()
        {
            return base.Create($"Prefabs/{nameof(PlantRingSpawner)}");
        }
    }

    void Update()
    {
        Timer.RunTimer(5f, () => SpawnRing());
    }

    private void SpawnRing()
    {
        PlantRingFactory.Create();
    }

    public void SetParent(GameObject obj)
    {
        transform.SetParent(obj.transform);
    }
}