using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DayNightCycle : MonoBehaviour
{
    public int timeChange = 16;

    //Images
    public Image backgroundImage;
    public Sprite dayImage;
    public Sprite nightImage;

    //pet
    public GameObject petDay;
    public GameObject petNight;

    //Buttons
    public Image calenderButton;
    public Image journalButton;
    public Image clockButton;
    public Image waterButton;
    public Image bedButton;

    //Day Buttons
    public Sprite dayCalender;
    public Sprite dayJournal;
    public Sprite dayClock;
    public Sprite dayWater;
    public Sprite dayBed;

    //Night Buttons
    public Sprite nightCalender;
    public Sprite nightJournal;
    public Sprite nightClock;
    public Sprite nightWater;
    public Sprite nightBed;

    private DateTime currentTime =  DateTime.Now.ToLocalTime();
   

    // Start is called before the first frame update
    void Start()
    {
        string time = currentTime.ToString("HH:mm:ss"); 
        print("Time:" + time);
        petDay.SetActive(true);
        petNight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //dayChange();
        MouseClicked();
    }


    void dayChange()
    {
        if (DateTime.Now.ToLocalTime().Hour < timeChange)
        {
            backgroundImage.GetComponent<Image>().sprite = dayImage;

            calenderButton.GetComponent<Image>().sprite = dayCalender;
            journalButton.GetComponent<Image>().sprite = dayJournal;
            clockButton.GetComponent<Image>().sprite = dayClock;
            waterButton.GetComponent<Image>().sprite = dayWater;
            bedButton.GetComponent<Image>().sprite = dayBed;

            petDay.SetActive(true);
            petNight.SetActive(false);
        }

        else if (DateTime.Now.ToLocalTime().Hour >= timeChange)
        {
            backgroundImage.GetComponent<Image>().sprite = nightImage;

            calenderButton.GetComponent<Image>().sprite = nightCalender;
            journalButton.GetComponent<Image>().sprite = nightJournal;
            clockButton.GetComponent<Image>().sprite = nightClock;
            waterButton.GetComponent<Image>().sprite = nightWater;
            bedButton.GetComponent<Image>().sprite = nightBed;

            petNight.SetActive(true);
            petDay.SetActive(false);
        }

    }

    void MouseClicked()
    {
        if (Input.GetKeyDown("n"))
        {
            backgroundImage.GetComponent<Image>().sprite = nightImage;

            calenderButton.GetComponent<Image>().sprite = nightCalender;
            journalButton.GetComponent<Image>().sprite = nightJournal;
            clockButton.GetComponent<Image>().sprite = nightClock;
            waterButton.GetComponent<Image>().sprite = nightWater;
            bedButton.GetComponent<Image>().sprite = nightBed;
        }
        else if (Input.GetKeyDown("d"))
        {
            backgroundImage.GetComponent<Image>().sprite = dayImage;

            calenderButton.GetComponent<Image>().sprite = dayCalender;
            journalButton.GetComponent<Image>().sprite = dayJournal;
            clockButton.GetComponent<Image>().sprite = dayClock;
            waterButton.GetComponent<Image>().sprite = dayWater;
            bedButton.GetComponent<Image>().sprite = dayBed;

            petDay.SetActive(true);
            petNight.SetActive(false);

        }

    }
}
