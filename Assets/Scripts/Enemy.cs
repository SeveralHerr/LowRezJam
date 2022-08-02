public class Enemy : UnitBase
{
    public override void Start()
    {
        base.Start();
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