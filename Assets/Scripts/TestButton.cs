using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestButton : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(() => OnClick());
    }

    public void OnClick()
    {
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
        Score.Instance.IncrementScore();
    }
}
