using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    //map the tabs EXACTLY in the same order as the pages panel
    public GameObject[] pages;
    public Button[] tabsButtons;
    public int indexClicked;

    void Start()
    {   //map each button click to its own instance / delegate function, and pass index of button from array
        for(int i = 0; i < tabsButtons.Length; i++){
            int x = i;
            tabsButtons[i].onClick.AddListener(delegate{TogglePages(x);});
        }
    }

    // checks which button has been clicked
    void TogglePages(int index){
        //Debug.Log(index);
        for(int i = 0; i < pages.Length; i++){
            if(i == index){
                pages[i].SetActive(true);
            }else{
                pages[i].SetActive(false);
            }
        }
    }
}
