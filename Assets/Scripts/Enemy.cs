using UnityEngine;

public class Enemy : UnitBase
{
    public Animator animator;
    public override void Start()
    {
        base.Start();
        animator.SetFloat("AnimationOffset", Random.Range(0f, 1f));
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
}