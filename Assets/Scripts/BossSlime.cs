using UnityEngine;
using Zenject;

public class BossSlime: UnitBase
{
    public Animator animator;
    public ICollisionHandler CollisionHandler { get; set; }

    [Inject]
    public void Construct(ICollisionHandler collisionHandler)
    {
        CollisionHandler = collisionHandler;

    }

    public override void Start()
    {
        base.Start();
        animator.SetFloat("AnimationOffset", Random.Range(0f, 1f));
    }

    public class Factory : PlaceholderFactory<string, BossSlime>
    {
        public BossSlime Create()
        {
            return base.Create($"Prefabs/BossSlime");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        MoveTowardsPlayer();

        base.Update();
    }

    public void Dead()
    {
        StopMovement();
        var animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<BoxCollider2D>().enabled = false;
        animator.Play("SlimeDeath");
        var length = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, length + 1);
    }

    private void MoveTowardsPlayer()
    {
        if (Player.Instance == null)
        {
            return;
        }
        MoveTowardsTarget(Position, Player.Instance.Position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.DestroyOnCollisionWithAction(collision, "Player", () => Player.Instance.Dead());
    }
}