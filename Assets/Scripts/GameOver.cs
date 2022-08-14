using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

public class GameOver : MonoBehaviour
{
    public Button Button;
    public GameObject prefab;

    private ITimer Timer;

    private bool RunOnce = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    [Inject]
    public void Construct(ITimer timer)
    {
        Timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.RunOnceTimer(1f, () => RunOnce = true);

        if(!RunOnce)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        }
    }

    private void Button_Click()
    {
        
    }
}
