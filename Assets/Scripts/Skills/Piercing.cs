public class PiercingSkill : Skill
{
    public override string ShortName => "Piercing";

    public override void LearnSkill()
    {
        Player.Instance.HasPiercing = true;
    }
}
