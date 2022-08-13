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

    private void OnClick()
    {
        Debug.Log("Click");
    }
}
