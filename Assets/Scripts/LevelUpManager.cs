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
    public List<int> PreviousScores = new List<int>();

    public List<SkillOption> skillOptions = new List<SkillOption>();

    public SkillList SkillList;


    public bool IsActive = false;
    public bool IsButtonsActive = false;

    private ITimer Timer;

    void Start()
    {
        Score.Instance.LevelUpEvent.AddListener(LevelUp_Event);
        UIObject.SetActive(false);
    }

    private void Update()
    {
        if (!IsActive)
        {
            return;
        }

        Timer.RunTimer(1f, () =>
        {
            if (IsButtonsActive)
            {
                return;
            }
            foreach (var so in skillOptions)
            {
                so.Button.onClick.AddListener(() => OnClick(so));
            }
            IsButtonsActive = true;
        });
    }

    private void OnClick(SkillOption skillOption)
    {
        Player.Instance.IsPaused = false;

        if (skillOption.Skill == null)
        {
            UIObject.SetActive(false);
            return;
        }

        SkillList.CompleteSkill(skillOption.Skill);
        skillOption.Skill.LearnSkill();

        var skillBtnList = GameObject.FindGameObjectsWithTag("Button1");

        IsButtonsActive = false;
        IsActive = false;
        UIObject.SetActive(false);

        foreach (var skillButton in skillBtnList)
        {
            Destroy(skillButton);
        }
    }

    [Inject]
    public void Construct(SkillList skillList, ITimer timer)
    {
        SkillList = skillList;
        Timer = timer;
    }

    private void LevelUp_Event()
    {
        //Time.timeScale = 0;
        Player.Instance.IsPaused = true;

        var skills = SkillList.GetThreeRandomSkills();

        if (!skills.Any())
        {
            //Time.timeScale = 1;
            return;
        }

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
            var obj = Instantiate((GameObject)Resources.Load($"Prefabs/NewNewSkillButton"));
            var so = new SkillOption
            {

                Button = obj.GetComponentInChildren<Button>(),
                Skill = skillOptionList[i].Skill,
                TextBox = obj.GetComponentInChildren<TextMeshProUGUI>()
            };


            obj.transform.position = new Vector2(320, 240 - (i * 160));
            obj.transform.SetParent(UIObject.transform);
            so.TextBox.text = so.Skill.ShortName;

            skillOptions.Add(so);

            //so.TextBox = 
            //so.TextBox.text = skillOptionList[i].Skill.ShortName;
        }
        IsActive = true;

        UIObject.SetActive(true);
    }
}
