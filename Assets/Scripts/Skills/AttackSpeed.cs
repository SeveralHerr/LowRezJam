public class AttackSpeed : ISkill
{
    public void LearnSkill()
    {
        Player.Instance.ProjectileAttackSpeed *= 2f; 
    }
}
