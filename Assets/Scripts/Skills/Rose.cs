using UnityEngine;
using Zenject;

public class Rose : MonoBehaviour
{
    public float duration = 2f;
    private ITimer Timer { get; set; }
    private ICollisionHandler CollisionHandler { get; set; }

    [Inject]
    private void Construct(ITimer timer, ICollisionHandler collisionHandler)
    {
        Timer = timer;
        CollisionHandler = collisionHandler;
    }

    public class Factory : PlaceholderFactory<string, Rose>
    {
        public Rose Create()
        {
            return base.Create($"Prefabs/{nameof(Rose)}");
        }
    }

    private void Update()
    {
        Timer.RunOnceTimer(duration, () => Destroy(gameObject));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.DestroyOnCollisionWithAction(collision, "Enemy", () => Score.Instance.currentScore += 1);
    }
}

