using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class EventsData : MonoBehaviour
{
    public string directory = "/Resource/";
    public string fileName = "EventsData.json";
    public TextMeshProUGUI date;
    public TMPro.TMP_InputField eventName;
    public Button addButton;

    public void Start()
    {
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
        Debug.Log("In Save Event");

        string filePath = "Assets/Prefabs/Data/";
        string fileName = "myEventsData.txt";

        if (!eventName.text.Equals(""))
            if (!Directory.Exists(filePath))
            {
                Debug.Log("added data");
                Directory.CreateDirectory(filePath);
            }
            else
            {
                //create page based on current page
                Debug.Log("In else portion");
                string date = GetDate();
                string eventName = GetInputField();
                Event newEvent = new Event();
                newEvent.date = date;
                newEvent.eventName = eventName;

                StreamReader reader = new StreamReader(filePath + fileName);

                // Read existing json file linked in inspector
                EventCollection eventCol = JsonUtility.FromJson<EventCollection>(reader.ReadToEnd());
                reader.Close();
                Debug.Log("previous: " + JsonFile.text);
                List<Event> listOfEvents = new List<Event>();
                listOfEvents = eventCol.events.ToList();
                listOfEvents.Add(newEvent);
                eventCol.events = listOfEvents.ToArray();

                //save to file
                string json = JsonUtility.ToJson(eventCol);
                File.WriteAllText(filePath + fileName, json);
                eventCol = JsonUtility.FromJson<EventCollection>(JsonFile.text);
                Debug.Log("new: " + json);
            }
    }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;

    //  private void SavePageToJSON(){
    //     // Read existing json file linked in inspector
    //      PageCollection pageCol = JsonUtility.FromJson<PageCollection>(JsonFile.text);
    //      Debug.Log(pageCol);
    //      List<Page> listOfPages = pageCol.pages.ToList();

    //      listOfPages.Add(new Page{ key="4/5/2022", entry="hello"});

    //      pageCol.pages = listOfPages.ToArray();

    //     string newJsonString = JsonUtility.ToJson(pageCol);
    //      Debug.Log(newJsonString);
    //  }
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
