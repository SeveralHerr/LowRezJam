using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlsScreen : MonoBehaviour
{
    public Button Button;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(Button_Click);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Button_Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        prefab.SetActive(false);
    }
}
