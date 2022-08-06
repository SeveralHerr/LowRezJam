using UnityEngine;
using Zenject;

public class PlantRing : MonoBehaviour, IHasSkillFactory
{
    private ITimer Timer { get; set; }

    private ICollisionHandler CollisionHandler { get; set; }

    [Inject]
    public void Construct(ITimer timer, ICollisionHandler collisionHandler)
    {
        Timer = timer;
        CollisionHandler = collisionHandler;
    }

    public class Factory : PlaceholderFactory<string, PlantRing>
    {
        public PlantRing Create()
        {
            return base.Create($"Prefabs/{nameof(PlantRing)}");
        }
    }
    private void Update()
    {
        transform.position = Player.Instance.Position;

        Timer.RunOnceTimer(.5f, () => Destroy(gameObject));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.DestroyOnCollisionWithAction(collision, "Enemy", () => Score.Instance.currentScore += 1);
    }
}

