using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Puffball : MonoBehaviour, IHasSkillFactory
{
    public MovementBehavior MovementBehavior;
    private Vector2 Direction { get; set; }
    private ICollisionHandler CollisionHandler { get; set; }
    private PuffballSkill PuffballSkill { get; set; }

    private Vector3 pos;
    public Vector3 axis;
    public float frequency = 3f;
    public float amplitude = 14f;
    public float cyclespeed = 15f;

    [Inject]
    private void Construct(ICollisionHandler collisionHandler, PuffballSkill puffballSkill)
    {
        CollisionHandler = collisionHandler;
        PuffballSkill = puffballSkill;
    }

    public class Factory : PlaceholderFactory<string, Puffball>
    {
        public Puffball Create()
        {
            return base.Create($"Prefabs/{nameof(Puffball)}");
        }
    }

    private void Start()
    {
        transform.position = Player.Instance.Position;
        pos = transform.position;
        if(Direction.x == 1 && Direction.y == 0)
        {
            axis = transform.right;
        }
        else if (Direction.x == -1 && Direction.y == 0)
        {
            axis = -transform.right;
        }
        else if (Direction.x == 0 && Direction.y == -1)
        {
            axis = -transform.up;
        }
        else
        {
            axis = transform.up;
        }
    }

    void Update()
    {
        if (Direction == null)
        {
            return;
        }

        // 3 14 15

        if (PuffballSkill.IsZigZagEnabled)
        {
            if (Direction.x == 1 && Direction.y == 0)
            {
                pos += Vector3.down * Time.deltaTime * cyclespeed;
            }
            else if (Direction.x == -1 && Direction.y == 0)
            {
                pos += Vector3.up * Time.deltaTime * cyclespeed;
            }
            else if (Direction.x == 0 && Direction.y == -1)
            {
                pos += Vector3.left * Time.deltaTime * cyclespeed;
            }
            else
            {
                pos += Vector3.right * Time.deltaTime * cyclespeed;
            }

            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * amplitude;
        }
        else
        {
            MovementBehavior.MoveTowards(Direction);
        }

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
        if (!PuffballSkill.IsPiercingEnabled)
        {
            Destroy(gameObject);
        }
    }
}
