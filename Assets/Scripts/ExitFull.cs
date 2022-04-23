using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFull : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //exists game completly
    public void ExitaGame()
    {
        Application.Quit();
    }

    //exists and enters full screen
    public void FullScreen(bool fullscreenOn)
    {
        Screen.fullScreen = fullscreenOn;
        Debug.Log("Fullscreen is" + fullscreenOn);
    }
}
