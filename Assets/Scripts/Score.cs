using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class LevelUpEvent : UnityEvent
{

}

public class Score : SingletonMonobehavior<Score>
{
    public TextMeshProUGUI score;

    [SerializeField]
    private int currentScore = 0;

    public LevelUpEvent LevelUpEvent;

    // Start is called before the first frame update
    void Start()
    {
        LevelUpEvent = new LevelUpEvent();
    }

    public void IncrementScore()
    {
        currentScore += 1;
        score.text = $"{currentScore}";

        if(currentScore % 50 == 0)
        {
            LevelUpEvent.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
