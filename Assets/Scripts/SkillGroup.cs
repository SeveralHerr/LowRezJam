//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

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