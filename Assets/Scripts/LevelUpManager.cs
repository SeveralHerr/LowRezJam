using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LevelUpManager : MonoBehaviour
{
    public GameObject levelUpPrefab;

    public bool scoreTenRunOnce = false;
    public bool scoreTwentyRunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.Instance.currentScore == 3 && scoreTenRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTenRunOnce = true;

            var obj = Instantiate(levelUpPrefab);

            var skills = Player.Instance.SkillGroup;

            var random1 = skills.GetRandomSkill();
            var random2 = skills.GetRandomSkill();
            var random3 = skills.GetRandomSkill();

            SetupButton("Button1", random1, obj);
            SetupButton("Button2", random2, obj);
            SetupButton("Button3", random3, obj);
            
            

            //SetupButton("Button1", "+Piercing", new PiercingSkill(), obj);
            //// SetupButton("Button1", "+Rose", null, obj, nameof(RoseSpawner));

            //SetupButton("Button2", "+Atk Spd", new AttackSpeed(), obj);
            //SetupButton("Button3", "+4 leaf", null, obj, nameof(FourWayLeafAttack));
        }

        //if (Score.Instance.currentScore == 3 && scoreTenRunOnce == false)
        //{
        //    Time.timeScale = 0;
        //    scoreTenRunOnce = true;

        //    var obj = Instantiate(levelUpPrefab);
        //    SetupButton("Button1", "+Piercing", new PiercingSkill(), obj);
        //    // SetupButton("Button1", "+Rose", null, obj, nameof(RoseSpawner));
   
        //    SetupButton("Button2", "+Atk Spd", new AttackSpeed(), obj);
        //    SetupButton("Button3", "+4 leaf", null, obj, nameof(FourWayLeafAttack));
        //}

        if(Score.Instance.currentScore == 6 && scoreTwentyRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTwentyRunOnce = true;

            var obj = Instantiate(levelUpPrefab);
            //SetupButton("Button1", "+Puff", null, obj, "PuffballSpawner");
            //SetupButton("Button2", "+Atk Spd", new AttackSpeed(), obj);
            //SetupButton("Button3", "+Ring", null, obj, nameof(PlantRingSpawner));

            var skills = Player.Instance.SkillGroup;

            var random1 = skills.GetRandomSkill();
            var random2 = skills.GetRandomSkill();
            var random3 = skills.GetRandomSkill();

            SetupButton("Button1", random1, obj);
            SetupButton("Button2", random2, obj);
            SetupButton("Button3", random3, obj);
        }
    }

    private void SetupButton(string levelupButton, Skill skill,  GameObject parent)
    {
        var button3 = GameObject.FindGameObjectWithTag(levelupButton);

        var button3LevelUp = button3.GetComponentInChildren<LevelUp>();
        button3LevelUp.boxText.text = skill?.shortName ?? string.Empty;
        button3LevelUp.skill = skill?.skill;
        button3LevelUp.ui = parent;

        button3LevelUp.prefabSkill = skill?.skillPrefab;
        
    }
}
