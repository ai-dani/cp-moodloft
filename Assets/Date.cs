using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour
{
    //[SerializeField] TMPro.TMP_Text dateText;
    public TMPro.TMP_Text[] dayOfWeekText; //drag and drop day of the week (7 slots for M-Sun)
    public TMPro.TMP_Text currentDayText;
    public MoodData[] moodButtons;
    public WaterData[] waterPanels;
    public List<TMPro.TMP_Text> futureDayText;

    
    public int currentDayIndex;
    public List<int> futureDaysIndices;

    void Awake()
    {
        //Debug.Log("system time: " + System.DateTime.Now);
        //Debug.Log("utc time: " + System.DateTime.UtcNow);
        futureDayText = new List<TMPro.TMP_Text>();
        futureDaysIndices = new List<int>();
        PopulateDatesForDayOfWeek();
    }

//newer, prettier code...
    void PopulateDatesForDayOfWeek(){
        int diff = System.DayOfWeek.Monday - System.DateTime.Now.DayOfWeek;
         for(int i = 0; i < dayOfWeekText.Length; i++){
             if(diff == 0){ //this is the current day of week
                currentDayText = dayOfWeekText[i];
                currentDayIndex = i;
             }
             if(diff > 0){ //future day
                futureDayText.Add(dayOfWeekText[i]);
                futureDaysIndices.Add(i);
             }
             dayOfWeekText[i].text = System.DateTime.Today.AddDays(diff).Date.ToString("MMMM dd, yyyy");

            string dateKey = System.DateTime.Today.AddDays(diff).Date.ToString("MM-dd-yyyy");
             //load the key data values for each page panels (hardcoded for each page)
             if(dayOfWeekText[i].gameObject.transform.parent!=null){
                 PageData lab = dayOfWeekText[i].gameObject.transform.parent.GetComponent<PageData>();
                 //Debug.Log("key: "+dateKey);
                 lab.SetKey(dateKey);
             }

             //load the key data values for each mood buttons (hard coded for each mood button)
            moodButtons[i].SetKey(dateKey);
            waterPanels[i].SetKey(dateKey);

             diff++;
         }
    }

    void Update(){

    }

    // Use for journal dates
    public TMPro.TMP_Text ReturnCurrentDayTMPText(){
        return currentDayText;
    }

    // Use for journal dates
    public List<TMPro.TMP_Text> ReturnFutureDayTMPText(){
        return futureDayText;
    }

    // Use for Mood tracker , water tracker
    public int CurrentDayIndex(){
        return currentDayIndex;
    }

    // Use for Mood tracker , water tracker
    public List<int> FutureDayIndices(){
        return futureDaysIndices;
    }


// Original code...
//THIS WAS EXTREMELY INEFFICIENTLY PAINFULLY HARDCODED AT FIRST... THank goodness for pattern recognition.. and math. :')
    // void CalculateWeekFromWednesday(){
    //     //changes monday's, tuesday's, wednesday's, etc date according to relative weekday
    //     dayOfWeekText[0].text = System.DateTime.Today.AddDays(-2).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[1].text = System.DateTime.Today.AddDays(-1).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[2].text = System.DateTime.Today.AddDays(0).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[3].text = System.DateTime.Today.AddDays(1).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[4].text = System.DateTime.Today.AddDays(2).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[5].text = System.DateTime.Today.AddDays(3).Date.ToString("MMMM dd, yyyy");
    //     dayOfWeekText[6].text = System.DateTime.Today.AddDays(4).Date.ToString("MMMM dd, yyyy");
    // }
}
