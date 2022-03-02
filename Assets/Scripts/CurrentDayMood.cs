using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CurrentDayMood : MonoBehaviour
{

    public Button[] dayOfWeekButton;
    //public GameObject[] pieBlock; 

    public Date date;

    // Start is called before the first frame update
    void Start()
    {
        date = FindObjectOfType<Date>();
        addPieBlockers();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addPieBlockers()
    {
        for(int i = 0; i < date.futureDaysIndices.Count; i++)
        {
            int currentFutureDay = date.futureDaysIndices[i];
            dayOfWeekButton[currentFutureDay].enabled = false;
            dayOfWeekButton[currentFutureDay].GetComponent<Image>().color = new Color32(140, 140, 140, 120);
            //pieBlock[currentFutureDay].SetActive(true); 
        }
        
    }
}
