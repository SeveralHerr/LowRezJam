public class AttackSpeedSkill : Skill
{
    public override string ShortName => "Atk Spd";

    public override void LearnSkill()
    {
        Player.Instance.ProjectileAttackSpeed *= 2f;
    }
}
