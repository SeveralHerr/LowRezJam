using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

[Serializable]
public class SkillOption
{
    public Button Button;
    public Skill Skill { get; set; }

    public TextMeshProUGUI TextBox;
}


public class LevelUpManager : MonoBehaviour//, IInitializable
{
    public GameObject UIObject;

    public SkillOption option1;
    public SkillOption option2;
    public SkillOption option3;

    public bool scoreTenRunOnce = false;
    public bool scoreTwentyRunOnce = false;

    public SkillList SkillList;

    void Start()
    {
        UIObject.SetActive(false);


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

    // Update is called once per frame
    void Update()
    {
        if (Score.Instance.currentScore == 3 && scoreTenRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTenRunOnce = true;

            var skills = SkillList.GetThreeRandomSkills();

            UIObject.SetActive(true);

            option1.Skill = skills[0] ?? null;
            option2.Skill = skills[1] ?? null;
            option3.Skill = skills[2] ?? null;

            option1.TextBox.text = option1.Skill?.ShortName ?? string.Empty;
            option2.TextBox.text = option2.Skill?.ShortName ?? string.Empty;
            option3.TextBox.text = option3.Skill?.ShortName ?? string.Empty;

            option1.Button.onClick.AddListener(Button_Click1);
            option2.Button.onClick.AddListener(Button_Click2);
            option3.Button.onClick.AddListener(Button_Click3);
        }
        //if (Score.Instance.currentScore == 3 && scoreTenRunOnce == false)
        //{
        //    Time.timeScale = 0;
        //    scoreTenRunOnce = true;

            //    var obj = Instantiate(levelUpPrefab);

            //    var skills = Player.Instance.SkillGroup;

            //    var random1 = skills.GetRandomSkill();
            //    var random2 = skills.GetRandomSkill();
            //    var random3 = skills.GetRandomSkill();

            //    SetupButton("Button1", random1, obj);
            //    SetupButton("Button2", random2, obj);
            //    SetupButton("Button3", random3, obj);
            //}

            //if(Score.Instance.currentScore == 6 && scoreTwentyRunOnce == false)
            //{
            //    Time.timeScale = 0;
            //    scoreTwentyRunOnce = true;

            //    var obj = Instantiate(levelUpPrefab);

            //    var skills = Player.Instance.SkillGroup;

            //    var random1 = skills.GetRandomSkill();
            //    var random2 = skills.GetRandomSkill();
            //    var random3 = skills.GetRandomSkill();

            //    SetupButton("Button1", random1, obj);
            //    SetupButton("Button2", random2, obj);
            //    SetupButton("Button3", random3, obj);
            //}
    }



    //private void SetupButton(string levelupButton, Skill skill,  GameObject parent)
    //{
    //    var button3 = GameObject.FindGameObjectWithTag(levelupButton);

    //    var button3LevelUp = button3.GetComponentInChildren<LevelUp>();
    //    button3LevelUp.boxText.text = skill?.shortName ?? string.Empty;
    //    button3LevelUp.skill = skill?.skill;
    //    button3LevelUp.ui = parent;

    //    button3LevelUp.prefabSkill = skill?.skillPrefab;

    //}

    //public void Initialize()
    //{
    //    throw new NotImplementedException();
    //}
}
