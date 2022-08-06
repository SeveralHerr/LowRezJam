using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Puffball : MonoBehaviour, IHasSkillFactory
{
    public MovementBehavior MovementBehavior;
    private Vector2 Direction { get; set; }
    private ICollisionHandler CollisionHandler { get; set; }

    [Inject]
    private void Construct(ICollisionHandler collisionHandler)
    {
        CollisionHandler = collisionHandler;
    }

    public class Factory : PlaceholderFactory<string, Puffball>
    {
        public Puffball Create()
        {
            return base.Create($"Prefabs/{nameof(Puffball)}");
        }
    }

    void Update()
    {
        if (Direction == null)
        {
            return;
        }

        MovementBehavior.MoveTowards(Direction);

        PurgeWhenOutOfBounds();
    }

    public void PurgeWhenOutOfBounds()
    {
        if (Map.Instance.IsOutOfBounds(MovementBehavior.GetPosition()))
        {
            Destroy(gameObject);
        }
    }

    public void Setup(Vector2 direction, float speed, Vector2 initialPosition)
    {
        Direction = direction;
        MovementBehavior.MovementSpeed = speed;
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.DestroyOnCollisionWithAction(collision, "Enemy", () => Score.Instance.currentScore += 1);
    }
}
