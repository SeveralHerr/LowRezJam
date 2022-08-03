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
        if(Score.Instance.currentScore == 3 && scoreTenRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTenRunOnce = true;

            var obj = Instantiate(levelUpPrefab);
            SetupButton("Button1", "+Piercing", new PiercingSkill(), obj);
            SetupButton("Button2", "+Atk Spd", new AttackSpeed(), obj);
            SetupButton("Button3", "+4 leaf", Player.Instance.gameObject.AddComponent<FourWayLeafAttack>(), obj);
        }

        if(Score.Instance.currentScore == 6 && scoreTwentyRunOnce == false)
        {
            Time.timeScale = 0;
            scoreTwentyRunOnce = true;

            var obj = Instantiate(levelUpPrefab);
            SetupButton("Button1", "+Puff", Player.Instance.gameObject.AddComponent<Puffball>(), obj);
            SetupButton("Button2", "+Atk Spd", new AttackSpeed(), obj);
            SetupButton("Button3", "+Atk Spd", new AttackSpeed(), obj);
        }
    }

    private void SetupButton(string levelupButton, string text, ISkill skill, GameObject parent)
    {
        var button3 = GameObject.FindGameObjectWithTag(levelupButton);

        var button3LevelUp = button3.GetComponentInChildren<LevelUp>();
        button3LevelUp.boxText.text = text;
        button3LevelUp.skill = skill;
        button3LevelUp.ui = parent;
    }
}
