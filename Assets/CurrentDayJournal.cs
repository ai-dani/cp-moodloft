using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDayJournal : MonoBehaviour
{
    Date date;
    public Button openButton;
    private GameObject currentDayPanel;
    private List<GameObject> futureDayPanel;
    public GameObject coverPanel;
    private bool OpenOnceAlready = false;
    // Start is called before the first frame update
    void Start()
    {
        futureDayPanel=new List<GameObject>();
        date = FindObjectOfType<Date>();
        openButton = FindObjectOfType<Button>();
        openButton.onClick.AddListener(OpenCurrentDayPanel);
        openButton.onClick.AddListener(CoverFutureDayPanel);
        currentDayPanel = date.ReturnCurrentDayTMPText().gameObject.transform.parent.gameObject;
        foreach(TMPro.TMP_Text futureWeekDay in date.ReturnFutureDayTMPText()){
            futureDayPanel.Add(futureWeekDay.gameObject.transform.parent.gameObject);
        }
    }

    void OpenCurrentDayPanel(){
        for(int childIndex = 0; childIndex < currentDayPanel.transform.parent.childCount; childIndex++){
            GameObject currentChild = currentDayPanel.transform.parent.GetChild(childIndex).gameObject;
            currentChild.SetActive(false); //Error checks - in case duplicate pages pop up at once...
        }
        currentDayPanel.SetActive(true);

    }

    //still working on this extra function - should grey out future date
    void CoverFutureDayPanel(){
        if(!OpenOnceAlready){ //avoids multiple instantiations of covers
            foreach(GameObject futDay in futureDayPanel){
                GameObject newCover = Instantiate(coverPanel, futDay.transform);
            }
            OpenOnceAlready=true;
        }
    }


    
}
