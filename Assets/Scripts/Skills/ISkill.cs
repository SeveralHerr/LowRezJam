using UnityEngine;
public interface ISkill
{
}

public interface IHasSkillFactory { };

public interface ISpawner { };

public interface INewSkill
{
    public void LearnSkill();

    public string GetShortName();

    public void SetParent(GameObject obj);
}

public abstract class Skill
{
    public abstract string ShortName { get; }
    public abstract void LearnSkill();
}

public class Skill2
{
    public ISkill skill;
    public string skillPrefab;
    public string shortName;
    public bool isComplete = false;
    public int order;
}

