using UnityEngine;
using Zenject;

public class RootSpikesSpawner : MonoBehaviour
{
    private RootSpikes.Factory RootSpikesFactory { get; set; }
    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(RootSpikes.Factory factory, ITimer timer)
    {
        RootSpikesFactory = factory;
        Timer = timer;
    }

    public class Factory : PlaceholderFactory<string, RootSpikesSpawner>
    {
        public RootSpikesSpawner Create()
        {
            return base.Create($"Prefabs/{nameof(RootSpikesSpawner)}");
        }
    }

    void Update()
    {
        Timer.RunTimer(8f, () => SpawnRing());
    }

    private void SpawnRing()
    {
        RootSpikesFactory.Create();
    }

    public void SetParent(GameObject obj)
    {
        transform.SetParent(obj.transform);
    }
}
