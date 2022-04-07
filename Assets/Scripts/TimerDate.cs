using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TimerDate : MonoBehaviour
{
    public DateTime currDate = DateTime.Now;
    public TextMeshProUGUI dateText;

    private void Start()
    {
        UpdateTimerDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }

    void UpdateTimerDate(int year, int month, int day)
    {
        DateTime temp = new DateTime(year, month, day);
        currDate = temp;
        dateText.text = temp.ToString("MMMM") + " " + temp.Day.ToString() + ", " + temp.Year.ToString();

        
    }

    public void SwitchDay(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddDays(-1);
        }
        else
        {
            currDate = currDate.AddDays(1);
        }

        UpdateTimerDate(currDate.Year, currDate.Month, currDate.Day);
    }
}
