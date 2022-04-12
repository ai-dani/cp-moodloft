using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Source: https://www.youtube.com/watch?v=CE9VOZivb3I

public class SceneLoader : MonoBehaviour
{
    //public Animator transition;
    public float transiitonTime = 3f;
    //public GameObject loadingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLvl(string name)
    {
        print("loading next level");
        StartCoroutine(LoadLvl(name));
    }

    public IEnumerator LoadLvl(string nextScene)
    {
        //loadingPanel.SetActive(true);
        //transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextScene);
    }
}
