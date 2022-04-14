using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class CalendarLoad : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "myEventsData.txt";
    public TextMeshProUGUI MonthAndYear;
    public GameObject toDoPrefab;
    private GameObject toDoItem;
    public Transform content;
    public TextMeshProUGUI time1Text;
    public TextMeshProUGUI time2Text;


    public void Start()
    {
        LoadEvents();
    }

    public void LoadEvents()
    {
        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath + fileName);
        EventCollection eventCol = JsonUtility.FromJson<EventCollection>(reader.ReadToEnd());
        reader.Close();
        List<Event> listOfEvents = new List<Event>();
        listOfEvents = eventCol.events.ToList();
        string date = string.Format("{0:MM/dd/yyyy}", DateTime.Now);

        foreach (Event item in listOfEvents)
        {
            Debug.Log(item.date);
            if (item.date == date)
            {
                GameObject toDoItem = Instantiate(toDoPrefab, content);
                toDoItem.name = item.eventName;
                string time1 = item.time1;
                string time2 = item.time2;
                toDoItem.GetComponentInChildren<TextMeshProUGUI>().text = time1 + "-" + time2 + ": " + item.eventName; ;

                if(item.checkmark == true)
                {
                    toDoItem.GetComponentInChildren<Toggle>().isOn = true;
                }
            }
        }
    }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;

}

