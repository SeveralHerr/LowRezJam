public interface ISkill
{
    public void LearnSkill();
}

public class Skill
{
    public ISkill skill;
    public string skillPrefab;
    public string shortName;
    public bool isComplete = false;
    public int order;
}

