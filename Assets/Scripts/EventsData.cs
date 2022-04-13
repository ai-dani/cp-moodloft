using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;

public class EventsData : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "myEventsData.txt";
    public TextMeshProUGUI date;
    public TMPro.TMP_InputField eventName;
    public Button addButton;
    public Transform transformParent;

    public void Start()
    {
        eventName = transformParent.GetComponentInChildren<TMPro.TMP_InputField>();
        addButton.onClick.AddListener(SaveEvent);
    }

    public void SetDate(TextMeshProUGUI newDate)
    {
        date = newDate;
    }

    public string GetDate()
    {
        return date.text;
    }

    public void SetInputField(string text)
    {
        eventName.text = text;
    }

    public string GetInputField()
    {
        return eventName.text;
    }

    public void SaveEvent()
    {
        if (!eventName.text.Equals(""))
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            else
            {
                //create page based on current page
                string date = GetDate();
                string eventName = GetInputField();
                Event newEvent = new Event();
                newEvent.date = date;
                newEvent.eventName = eventName;


                StreamReader reader = new StreamReader(filePath + fileName);
                Debug.Log(filePath+fileName);
                // Read existing json file linked in inspector
                EventCollection eventCol = JsonUtility.FromJson<EventCollection>(reader.ReadToEnd());
                reader.Close();

                Debug.Log("previous: " + JsonFile.text);
                List<Event> listOfEvents = new List<Event>();
                listOfEvents = eventCol.events.ToList();
                listOfEvents.Add(newEvent);
                eventCol.events = listOfEvents.ToArray();

                //save to file
                string json = JsonUtility.ToJson(eventCol, true);
                File.WriteAllText(filePath + fileName, json);
                eventCol = JsonUtility.FromJson<EventCollection>(JsonFile.text);
                Debug.Log("new: " + json);
            }
    }

    public TextMeshProUGUI MonthAndYear;

    public void LoadEvents()
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        string day = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;

        string[] MonthAndYearString = MonthAndYear.text.Split(' ');
        string month = convertMonthString(MonthAndYearString[0]);
        string year = MonthAndYearString[1];
        string date = month + "/" + day + "/" + year;


        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath + fileName);
        EventCollection eventCol = JsonUtility.FromJson<EventCollection>(reader.ReadToEnd());
        reader.Close();
        List<Event> listOfEvents = new List<Event>();
        listOfEvents = eventCol.events.ToList();

        Debug.Log(listOfEvents);
    }

    public string convertMonthString(string month)
    {
        if (month == "January")
            return "01";
        else if (month == "February")
            return "02";
        else if (month == "March")
            return "03";
        else if (month == "April")
            return "04";
        else if (month == "May")
            return "05";
        else if (month == "June")
            return "06";
        else if (month == "July")
            return "07";
        else if (month == "August")
            return "08";
        else if (month == "September")
            return "09";
        else if (month == "October")
            return "10";
        else if (month == "November")
            return "11";
        else if (month == "December")
            return "12";
        else
            return "0";
    }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;

}



[System.Serializable]

public class Event
{
    public string date;
    public string eventName;
}

[System.Serializable]
public class EventCollection
{
    public Event[] events;
}
