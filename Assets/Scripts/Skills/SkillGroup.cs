using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class SkillGroup
{
    public Skill Skill { get; set; }

    public int Order { get; set; } = 0;

    public bool IsComplete { get; set; } = false;
}
public class SkillList
{
    private RoseSkill RoseSkill;
    private PuffballSkill PuffSkill;
    private PlantRingSkill PlantRingSkill;
    private AttackSpeedSkill AttackSpeedSkill;
    private PiercingSkill PiercingSkill;
    private RootSpikesSkill RootSpikesSkill;
    private PuffZigZagSkill PuffZigZagSkill;
    private PuffPiercingSkill PuffPiercingSkill;
    private PuffballTimeSkill PuffballTimeSkill;

    private List<List<SkillGroup>> Skills;

    [Inject]
    public void Construct(RoseSkill skill, PuffballSkill puffSkill, PlantRingSkill plantRingSkill,
        AttackSpeedSkill attackSpeedSkill, PiercingSkill piercingSkill, RootSpikesSkill rootSpikesSkill,
        PuffZigZagSkill puffZigZagSkill, PuffPiercingSkill puffPiercingSkill, PuffballTimeSkill puffballTimeSkill)
    {
        RoseSkill = skill;
        PuffSkill = puffSkill;
        PlantRingSkill = plantRingSkill;
        AttackSpeedSkill = attackSpeedSkill;
        PiercingSkill = piercingSkill;
        RootSpikesSkill = rootSpikesSkill;
        PuffZigZagSkill = puffZigZagSkill;
        PuffPiercingSkill= puffPiercingSkill;
        PuffballTimeSkill = puffballTimeSkill;

        Skills = GetSkillGroups();
    }


    public List<List<SkillGroup>> GetSkillGroups()
    {
        var attackSpeedSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = AttackSpeedSkill,
                Order = 0
            },
            new SkillGroup
            {
                Skill = AttackSpeedSkill,
                Order = 1
            }
        };

        var plantRingSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = PlantRingSkill
            }
        };

        var roseSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = RoseSkill
            }
        };

        var puffballSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = PuffSkill, 
                Order = 0
            },
            new SkillGroup 
            {
                Skill = PuffZigZagSkill,
                Order = 1
            },
            new SkillGroup
            {
                Skill = PuffPiercingSkill,
                Order = 2
            },
            new SkillGroup
            {
                Skill = PuffballTimeSkill,
                Order = 3
            },
            new SkillGroup
            {
                Skill = PuffballTimeSkill,
                Order = 4
            },
        };

        var piercingSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = PiercingSkill
            }
        };

        var rootSpikesSkill = new List<SkillGroup>
        {
            new SkillGroup
            {
                Skill = RootSpikesSkill
            }
        };

        return new List<List<SkillGroup>> 
        { 
            attackSpeedSkill.OrderBy(x => x.Order).ToList(), 
            plantRingSkill.OrderBy(x => x.Order).ToList(), 
            puffballSkill.OrderBy(x => x.Order).ToList(), 
            roseSkill.OrderBy(x => x.Order).ToList(), 
            piercingSkill.OrderBy(x => x.Order).ToList(),
            rootSpikesSkill.OrderBy(x => x.Order).ToList()
        };
    }

    private List<List<SkillGroup>> GetAvailableSkills()
    {
        var skillList = new List<List<SkillGroup>>();
        foreach( var skill in Skills )
        {
            var s = skill.Where(x => !x.IsComplete).ToList();
            if (s.Count != 0)
            {
                skillList.Add(s);
            }
        }
        return skillList;
    }

    public List<Skill> GetThreeRandomSkills()
    {
        var skills = GetAvailableSkills().ToList();

        var randomSkillList = new List<SkillGroup>();

        for(var i = 0; i < 3; i++)
        {
            if(skills.Count() <= 0)
            {
                //randomSkillList.Add(null);
                continue;
            }

            var randomId = UnityEngine.Random.Range(0, skills.Count());
            var randomSkill = skills[randomId].FirstOrDefault();

            skills.RemoveAt(randomId);

            randomSkillList.Add(randomSkill);
        }

        return randomSkillList.Select(x => x.Skill ?? null).ToList();
    }

    public void CompleteSkill(Skill skill)
    {
        foreach(var item in Skills)
        {
            var skillToComplete = item.OrderBy(x => x.Order)
                .FirstOrDefault(x => !x.IsComplete 
                    && x.Skill == skill);
            if (skillToComplete != null)
            {
                skillToComplete.IsComplete = true;
                return;
            }
        }
    }
}












//public class SkillGroup
//{
//    private List<Skill> _skillPiercingList = new() { new Skill { skill = new PiercingSkill(), order = 0, shortName = "+Piercing" } };
//    private List<Skill> _attackSpeedList = new()
//    {
//        new Skill { skill = new AttackSpeed(), order = 0, shortName = "+Atk Spd" },
//        new Skill { skill = new AttackSpeed(), order = 1, shortName = "+Atk Spd" }
//    };
//    private List<Skill> _plantRingList = new() { new Skill { skillPrefab = nameof(PlantRingSpawner), order = 0, shortName = "+Ring" } };
//    private List<Skill> _puffballList = new() { new Skill { skillPrefab = nameof(PuffballSpawner), order = 0, shortName = "+Puff" } };
//    private List<Skill> _roseList = new()
//        { new Skill { skillPrefab = nameof(RoseSpawner), order = 0, shortName = "+Rose" },
//         new Skill { skillPrefab = nameof(RoseSpawner), order = 1, shortName = "+Rose" } 
//     };

//    public List<List<Skill>> skills => new() { _skillPiercingList, _plantRingList, _attackSpeedList, _puffballList, _roseList };

//    public Skill GetNextSkill(ISkill skill, string prefab)
//    {
//        foreach (var item in skills)
//        {
//            var i = item.OrderBy(o => o.order).FirstOrDefault(x => !x.isComplete);
//            if (i == null)
//            {
//                continue;
//            }
//            if ((i.skill?.GetType()?.Name == skill.GetType().Name && skill != null) || (prefab == i.skillPrefab && !string.IsNullOrEmpty(prefab)))
//            {
//                return i;
//            }
//        }

//        return null;
//    }

//    public IEnumerable<IEnumerable<Skill>> GetAvailableSkills()
//    {
//        foreach (var skill in skills)
//        {
//            yield return skill.OrderBy(o => o.order).Where(x => !x.isComplete);
//        }
//    }
//    public Skill GetRandomSkill()
//    {
//        var list = GetAvailableSkills().ToList();
//        var index = new System.Random().Next(list.Count);
//        return list[index].OrderBy(o => o.order).FirstOrDefault(x => !x.isComplete);
//    }

//}