using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
        Screen.SetResolution(640, 640, FullScreenMode.Windowed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
