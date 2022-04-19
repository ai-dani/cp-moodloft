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
    public GameObject pomodoroPrefab;
    public Transform parentPomodoro;
    public int pomodorosDone = 0;
    public bool longBreak = false;

    private void Start()
    {
        // Starts the timer automatically
        updateNumOfPomodoros();
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
        if (Input.GetKeyDown("t"))
        {
            timeRemaining = 0;
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                GameObject buttonPressed = GameObject.Find("Start/Stop Button");
                string buttonText = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;
                buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text = "Start";

                if(workMode == true)
                {
                    if (pomodorosDone < pomodoros)
                    {
                        pomodorosDone++;
                    }
                    updateColorOfPomodoros();
                }
                changeWorkMode();
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

        if (direction > 0 && settingInt <=5)
        {
            settingInt++;
        }
        else if (direction < 0 && settingInt >= 4)
        {
            settingInt--;
        }

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

        pomodorosDone = 0;
        string pomodoroString = pomodoroText.text;
        pomodoros = int.Parse(pomodoroString);
        updateNumOfPomodoros();

        workMode = true;
        Image img = GameObject.Find("Timer Background").GetComponent<Image>();
        img.color = new Color32(158, 240, 255, 255);
        img = GameObject.Find("Pomodoro Circles Background").GetComponent<Image>();
        img.color = new Color32(26, 200, 237, 255);

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
            timeRemaining = workTime;
            DisplayTime(timeRemaining);
            Image img = GameObject.Find("Timer Background").GetComponent<Image>();
            img.color = new Color32(158, 240, 255, 255);
            img = GameObject.Find("Pomodoro Circles Background").GetComponent<Image>();
            img.color = new Color32(26, 200, 237, 255);
            if(longBreak == true)
            {
                pomodorosDone = 0;
                longBreak = false;
                updateNumOfPomodoros();
            }
        }
        else if (workMode == false)
        {
            Image img = GameObject.Find("Timer Background").GetComponent<Image>();
            img.color = new Color32(230, 197, 156, 255);
            img = GameObject.Find("Pomodoro Circles Background").GetComponent<Image>();
            img.color = new Color32(217, 179, 132, 255);
            if(longBreak == true)
            {
                timeRemaining = longBreakTime;
                DisplayTime(timeRemaining);
            }
            else if(longBreak == false)
            {
                timeRemaining = shortBreakTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    public void updateNumOfPomodoros()
    {
        //Destroy all circles first
        for (int i = parentPomodoro.childCount - 1; i >= 0; i--){
            Object.Destroy(parentPomodoro.GetChild(i).gameObject);
        }

        //Update pomodoroCircles
        for(int i = 0; i < pomodoros; i++)
        {
            GameObject circle = Instantiate(pomodoroPrefab, parentPomodoro);
            circle.name = "pomodoroCircle_" + i;
        }
    }

    public void updateColorOfPomodoros()
    {
        for (int i = 0; i < pomodorosDone; i++)
        {
            parentPomodoro.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(43, 78, 97, 255);
        }

        checkForLongBreak();
    }

    public void checkForLongBreak()
    {
        if(pomodoros == pomodorosDone)
        {
            longBreak = true;
        }
    }
}