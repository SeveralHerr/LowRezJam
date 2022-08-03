using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameObject levelUpPrefab;

    //private GameObject Button1;
    //private GameObject Button2;
    //private GameObject Button3;

    public bool scoreTenRunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.Instance.currentScore == 10 && scoreTenRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTenRunOnce = true;

            var obj = Instantiate(levelUpPrefab);
            var button1 = GameObject.FindGameObjectWithTag("Button1");

            var button1LevelUp = button1.GetComponentInChildren<LevelUp>();
            button1LevelUp.boxText.text = "+Piercing";
            button1LevelUp.skill = new PiercingSkill();
            button1LevelUp.ui = obj;

            var button2 = GameObject.FindGameObjectWithTag("Button2");

            var button2LevelUp = button2.GetComponentInChildren<LevelUp>();
            button2LevelUp.boxText.text = "+Atk Spd";
            button2LevelUp.skill = new AttackSpeed();
            button2LevelUp.ui = obj;

            //var button3 = GameObject.FindGameObjectWithTag("Button3");

            //var button3LevelUp = button3.GetComponentInChildren<LevelUp>();
            //button3LevelUp.boxText.text = "+4 leaf";
            //button3LevelUp.skill = gameObject.AddComponent<FourWayLeafAttack>();
            //button3LevelUp.ui = obj;

            var button3 = GameObject.FindGameObjectWithTag("Button3");

            var button3LevelUp = button3.GetComponentInChildren<LevelUp>();
            button3LevelUp.boxText.text = "+Puff";
            button3LevelUp.skill = gameObject.AddComponent<Puffball>();
            button3LevelUp.ui = obj;
        }
    }

    //private void SetupButton()
}