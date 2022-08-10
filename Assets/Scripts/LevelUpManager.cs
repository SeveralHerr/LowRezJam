using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Events;

[Serializable]
public class SkillOption : Component
{
    public Button Button;
    public Skill Skill { get; set; }

    public TextMeshProUGUI TextBox;
}

public class LevelUpManager : MonoBehaviour//, IInitializable
{
    public GameObject UIObject;
    public List<int> PreviousScores = new List<int> ();

    public SkillOption option1;
    public SkillOption option2;
    public SkillOption option3;

    public bool scoreTenRunOnce = false;
    public bool scoreTwentyRunOnce = false;

    public SkillList SkillList;

    void Start()
    {
        Score.Instance.LevelUpEvent.AddListener(LevelUp_Event);
        UIObject.SetActive(false);
    }

    private void OnClick(SkillOption skillOption)
    {
        Time.timeScale = 1;
        if(skillOption.Skill == null)
        {
            UIObject.SetActive(false);
            return;
        }

        SkillList.CompleteSkill(skillOption.Skill);
        skillOption.Skill.LearnSkill();
        
        var skillBtnList = GameObject.FindGameObjectsWithTag("Button1");

        UIObject.SetActive(false);

        foreach (var skillButton in skillBtnList)
        {
            Destroy(skillButton);
        }
    }

    [Inject]
    public void Construct(SkillList skillList)
    {
        SkillList = skillList;
    }

    private void LevelUp_Event()
    {
        Time.timeScale = 0;

        var skills = SkillList.GetThreeRandomSkills();

        var skillOptionList = new List<SkillOption>();
        foreach (var skill in skills)
        {
            var skillOption = new SkillOption
            {
                Skill = skill
            };

            skillOptionList.Add(skillOption);
        }

        for (int i = 0; i < skillOptionList.Count; i++)
        {
            var so = new SkillOption
            {
                Button = Instantiate((GameObject)Resources.Load($"Prefabs/SkillButton")).GetComponent<Button>(),
                Skill = skillOptionList[i].Skill,
            };

            so.Button.name = $"skillButton{i}";
            so.Button.transform.position = new Vector3 { x = 32, y = (44.6f - (15f * i)), z = 0 };
            so.Button.transform.SetParent(UIObject.transform);
            so.Button.onClick.AddListener(() => OnClick(so));

            //so.TextBox = 
            //so.TextBox.text = skillOptionList[i].Skill.ShortName;
        }

        UIObject.SetActive(true);
    }
}
