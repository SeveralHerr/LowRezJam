using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour
{
    public Button Button;
    public GameObject prefab;
    public GameObject controlScreen;
    public Animator animator;

    public Timer timer;

    public bool firstClick = false;

    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(Button_Click);
        timer = new Timer();
    }

    // Update is called once per frame
    void Update()
    {
        timer.RunTimer(3f, () => animator.Play("StartScreen"));
    }

    private void Button_Click()
    {
        if (!firstClick)
        {
            firstClick = true;
            prefab.SetActive(false);
            controlScreen.SetActive(true);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            controlScreen.SetActive(false);
        }
    }
}
