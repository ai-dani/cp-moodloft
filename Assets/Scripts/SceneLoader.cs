using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Source: https://www.youtube.com/watch?v=CE9VOZivb3I

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transiitonTime;

    public void LoadNextLvl(string name)
    {
        print("loading next level");
        StartCoroutine(LoadLvl(name));
    }

    public IEnumerator LoadLvl(string nextScene)
    {
        transition.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(nextScene);
    }
}
