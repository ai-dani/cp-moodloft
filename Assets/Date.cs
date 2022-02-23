using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour
{
    //[SerializeField] TMPro.TMP_Text dateText;
    public TMPro.TMP_Text[] dayOfWeekText; //drag and drop day of the week (7 slots for M-Sun)

    void Start()
    {
        // Debug.Log(System.DateTime.Today.AddDays(-1).Date.ToString("MMMM dd, yyyy"));
        // dateText.text = System.DateTime.UtcNow.ToLocalTime().ToString("MMMM dd, yyyy");
        PopulateDatesForDayOfWeek();
    }

//newer, prettier code...
    void PopulateDatesForDayOfWeek(){
        int diff = System.DayOfWeek.Monday - System.DateTime.UtcNow.DayOfWeek;
         for(int i = 0; i < dayOfWeekText.Length; i++){
             dayOfWeekText[i].text = System.DateTime.Today.AddDays(diff).Date.ToString("MMMM dd, yyyy");
             diff++;
         }
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
