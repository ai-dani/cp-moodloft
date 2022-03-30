using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 1200;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI workTimeText;
    public TextMeshProUGUI shortBreakTimeText;
    public TextMeshProUGUI longBreakTimeText;
    public TextMeshProUGUI pomodoroText;
    public int workTime = 1200;
    public int shortBreakTime = 300;
    public int longBreakTime = 900;
    public int pomodoros = 4;
    public bool workMode = true;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
    }

    public void buttonClick()
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        string buttonText = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;
        if (buttonText == "Start")
        {
            timerIsRunning = true;
            buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
        }
        else if (buttonText == "Pause") {
            timerIsRunning = false;
            buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                changeWorkMode();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timerIsRunning == true)
        {
            timeToDisplay += 1;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void changeTime(int direction)
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        string buttonText = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;
        string settingText = "";

        if (buttonText == "work")
        {
            settingText = workTimeText.text;
        }
        else if (buttonText == "shortBreak")
        {
            settingText = shortBreakTimeText.text;
        }
        else if (buttonText == "longBreak")
        {
            settingText = longBreakTimeText.text;
        }

        string[] minAndSecs = settingText.Split(':');
        int minutes = int.Parse(minAndSecs[0]);

        if (direction > 0)
        {
            minutes++;
        }
        else if (direction < 0 && minutes > 1)
        {
            minutes--;
        }


        if (buttonText == "work")
        {
            workTimeText.text = minutes + ":" + minAndSecs[1];
        }
        else if (buttonText == "shortBreak")
        { 
            shortBreakTimeText.text = minutes + ":" + minAndSecs[1];
        }
        else if (buttonText == "longBreak")
        {
            longBreakTimeText.text = minutes + ":" + minAndSecs[1];
        }
    }

    public void changePomodoros(int direction)
    {
        string settingText = pomodoroText.text;
        int settingInt = int.Parse(settingText);

        if (direction > 0)
        {
            settingInt++;
        }
        else if (direction < 0 && settingInt >= 4)
        {
            settingInt--;
        }

        pomodoros = settingInt;
        pomodoroText.text = settingInt + "";
    }

    public void resetSettings()
    {
        workTimeText.text = "20:00";
        shortBreakTimeText.text = "5:00";
        longBreakTimeText.text = "15:00";
        pomodoroText.text = "4";
    }

    public void saveSettings()
    {
        string[] minAndSecs;

        string workTimeString = workTimeText.text;
        minAndSecs = workTimeString.Split(':');
        workTime = int.Parse(minAndSecs[0])*60+ int.Parse(minAndSecs[1]);

        string shortBreakTimeString = shortBreakTimeText.text;
        minAndSecs = shortBreakTimeString.Split(':');
        shortBreakTime = int.Parse(minAndSecs[0]) * 60 + int.Parse(minAndSecs[1]);

        string longBreakTimeString = longBreakTimeText.text;
        minAndSecs = longBreakTimeString.Split(':');
        longBreakTime = int.Parse(minAndSecs[0]) * 60 + int.Parse(minAndSecs[1]);

        string pomodoroString = pomodoroText.text;

        timeRemaining = workTime;
        DisplayTime(timeRemaining);
    }

    public void changeWorkMode()
    {
        if(workMode == true)
        {
            workMode = false;
        }
        else if(workMode == false)
        {
            workMode = true;
        }

        if (workMode == true)
        {
            Image img = GameObject.Find("Timer Background").GetComponent<Image>();
            img.color = new Color32(158, 240, 255, 255);
            img = GameObject.Find("Pomodoro Circles Background").GetComponent<Image>();
            img.color = new Color32(26, 200, 237, 255);
        }
        else if (workMode == false)
        {
            Image img = GameObject.Find("Timer Background").GetComponent<Image>();
            img.color = new Color32(132, 221, 99, 255);
            img = GameObject.Find("Pomodoro Circles Background").GetComponent<Image>();
            img.color = new Color32(107, 170, 117, 255);
        }
    }
}