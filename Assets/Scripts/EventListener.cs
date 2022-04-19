using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.IO;
using System.Linq;
using System;
using UnityEngine.EventSystems;

public class EventListener : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "myEventsData.txt";
    public Transform content;
    public string[] delete;

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in content)
        {
            StreamReader reader = new StreamReader(filePath + fileName);
            EventCollection eventCol = JsonUtility.FromJson<EventCollection>(reader.ReadToEnd());
            reader.Close();
            List<Event> listOfEvents = new List<Event>();
            listOfEvents = eventCol.events.ToList();

            Transform temp = child;
            if (temp.GetComponentInChildren<Toggle>().isOn)
            {
                child.gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

                //update JSON file
                foreach (Event item in listOfEvents)
                {
                    if ((item.time1 + "-" + item.time1 + ": " + item.eventName) == child.gameObject.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        item.checkmark = true;
                    }
                }
            }
            else
            {
                child.gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Normal;

                //update JSON file
                foreach (Event item in listOfEvents)
                {
                    if ((item.time1 + "-" + item.time1 + ": " + item.eventName) == child.gameObject.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        item.checkmark = false;
                    }
                }
            }
            string json = JsonUtility.ToJson(eventCol, true);
            File.WriteAllText(filePath + fileName, json);
        }
    }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;
}
