using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFirstTimeUser : MonoBehaviour
{
    public Button play;
    public SceneLoader sceneLoader;
    public GameObject loadingPanel;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(CheckUser);
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void CheckUser(){
        if(PlayerPrefs.GetString("PlayerName")==null){
            Debug.Log("new player");
            //do nothing
        }
        else{
            loadingPanel.SetActive(true);
            Debug.Log("returning player");
            sceneLoader.LoadNextLvl("MainLoft");
        }
    }
}
