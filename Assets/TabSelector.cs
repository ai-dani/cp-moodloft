using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSelector : MonoBehaviour
{
    public Button[] tabsButtons; //array of tabs that we will change the image of
    public Color selectedColor;
    public Color deselectedColor;


    // Start is called before the first frame update
    void Start()
    {
        //map each button click to its own instance / delegate function, and pass index of button from array
        for(int i = 0; i < tabsButtons.Length; i++){
            int x = i;
            tabsButtons[i].onClick.AddListener(delegate{ChangeTabImage(x);});
        }

        ChangeTabImage(0); //initialize first tab
    }

    // Update is called once per frame
    void ChangeTabImage(int index)
    {
        for(int i = 0; i < tabsButtons.Length; i++){
            if(i == index){
                tabsButtons[i].GetComponent<Image>().color = selectedColor;
            }else{
                tabsButtons[i].GetComponent<Image>().color = deselectedColor;
            }
        }
    }
}
