using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.Events;
using TMPro;

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

    private List<SkillOption> _skillOptionList = new List<SkillOption> ();

    void Start()
    {
        //option1.Button.onClick.AddListener(Button_Click1);
        //option2.Button.onClick.AddListener(Button_Click2);
        //option3.Button.onClick.AddListener(Button_Click3);
        UIObject.SetActive(false);
    }
    private void Button_Click()
    {
        OnClick(option1);
    }

    private void Button_Click1( )
    {
        OnClick(option1);
    }
    private void Button_Click2()
    {
        OnClick(option2);
    }
    private void Button_Click3()
    {
        OnClick(option3);
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
        
        UIObject.SetActive(false);
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

        foreach (var skill in skills)
        {
            var skillOption = new SkillOption
            {
                Skill = skill
            };

            _skillOptionList.Add(skillOption);
        }

        for (int i = 0; i < _skillOptionList.Count; i++)
        {
            UIObject.SetActive(true);
            var button = Instantiate((GameObject)Resources.Load($"Prefabs/SkillButton")).GetComponent<Button>();
            button.transform.SetParent(UIObject.transform);
            button.name = $"skillButton{i}";
            button.onClick.AddListener(() => OnClick(_skillOptionList[i]));
            button.transform.position = new Vector2 { x = 0, y = 12.6f };
        }

        UIObject.SetActive(true);
    }
}
