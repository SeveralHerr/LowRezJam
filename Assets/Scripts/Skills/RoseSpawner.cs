using UnityEngine;
using Zenject;

public class RoseSpawner : MonoBehaviour, IHasSkillFactory
{
    private Rose.Factory roseFactory;

    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(Rose.Factory factory, ITimer timer)
    {
        roseFactory = factory;
        Timer = timer;
    }

    public class Factory : PlaceholderFactory<string, RoseSpawner>
    {
        public RoseSpawner Create()
        {
            return base.Create($"Prefabs/{nameof(RoseSpawner)}");
        }
    }

    void Update()
    {
        Timer.RunTimer(3f, () => SpawnRose());
    }

    private void SpawnRose()
    {
        var spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        var spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        var spawnPosition = new Vector2(spawnX, spawnY);

        var rosePrefab = roseFactory.Create();
        rosePrefab.transform.position = spawnPosition;
    }

    public void SetParent(GameObject obj)
    {
        transform.SetParent(obj.transform);
    }
}