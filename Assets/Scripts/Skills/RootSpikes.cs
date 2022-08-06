using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RootSpikes : MonoBehaviour
{
    private ITimer Timer { get; set; }

    private ICollisionHandler CollisionHandler { get; set; }

    [Inject]
    public void Construct(ITimer timer, ICollisionHandler collisionHandler)
    {
        Timer = timer;
        CollisionHandler = collisionHandler;
    }

    public class Factory : PlaceholderFactory<string, RootSpikes>
    {
        public RootSpikes Create()
        {
            return base.Create($"Prefabs/{nameof(RootSpikes)}");
        }
    }
    private void Start()
    {
        transform.position = Player.Instance.Position;
    }
    private void Update()
    {
        Timer.RunOnceTimer(1f, () => Destroy(gameObject));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.DestroyOnCollisionWithAction(collision, "Enemy", () => Score.Instance.currentScore += 1);
    }
}
