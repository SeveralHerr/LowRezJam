using UnityEngine;
using Zenject;

public class Enemy : UnitBase
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

    public class Factory : PlaceholderFactory<string, Enemy>
    {
        public Enemy Create()
        {
            return base.Create($"Prefabs/SmallSlime");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        MoveTowardsPlayer();

        base.Update();
    }



    private void MoveTowardsPlayer()
    {
        if(Player.Instance == null)
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