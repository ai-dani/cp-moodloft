using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;

public class ToDoListData : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "toDoListData.txt";
    public TextMeshProUGUI date;
    public TMPro.TMP_InputField eventName;
    public Button addButton;
    public Transform transformParent;
    public Transform content;
    public GameObject toDoPrefab;
    private GameObject toDoItem;


    public void Start()
    {
        eventName = transformParent.GetComponentInChildren<TMPro.TMP_InputField>();
        addButton.onClick.AddListener(SaveEvent);
        LoadEvents();
    }

    public void Update()
    {
        foreach (Transform child in content)
        {
            StreamReader reader = new StreamReader(filePath + fileName);
            ToDoItemsCollection eventCol = JsonUtility.FromJson<ToDoItemsCollection>(reader.ReadToEnd());
            reader.Close();
            List<ToDoItem> listOfEvents = new List<ToDoItem>();
            listOfEvents = eventCol.toDoItems.ToList();

            Transform temp = child;

            if (temp.GetComponentInChildren<Toggle>().isOn)
            {
                //update JSON file
                foreach (ToDoItem item in listOfEvents)
                {
                    Debug.Log(item.eventName);
                    Debug.Log(child.gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
                    if (item.date + ": " + item.eventName == child.gameObject.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        item.checkmark = true;
                    }
                }
            }
            else
            {
                //update JSON file
                foreach (ToDoItem item in listOfEvents)
                {
                    if (item.eventName == child.gameObject.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        item.checkmark = false;
                    }
                }
            }
            string json = JsonUtility.ToJson(eventCol, true);
            File.WriteAllText(filePath + fileName, json);
        }
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
                ToDoItem newEvent = new ToDoItem();
                newEvent.date = date;
                newEvent.eventName = eventName;
                newEvent.checkmark = false;

                StreamReader reader = new StreamReader(filePath + fileName);
                Debug.Log(filePath+fileName);
                // Read existing json file linked in inspector
                ToDoItemsCollection eventCol = JsonUtility.FromJson<ToDoItemsCollection>(reader.ReadToEnd());
                reader.Close();

                Debug.Log("previous: " + JsonFile.text);
                List<ToDoItem> listOfEvents = new List<ToDoItem>();
                listOfEvents = eventCol.toDoItems.ToList();
                listOfEvents.Add(newEvent);
                eventCol.toDoItems = listOfEvents.ToArray();

                //save to file
                string json = JsonUtility.ToJson(eventCol, true);
                File.WriteAllText(filePath + fileName, json);
                eventCol = JsonUtility.FromJson<ToDoItemsCollection>(JsonFile.text);
                Debug.Log("new: " + json);
            }
    }

    public void LoadEvents()
    {
        Debug.Log("In Load Events");

        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath + fileName);
        ToDoItemsCollection eventCol = JsonUtility.FromJson<ToDoItemsCollection>(reader.ReadToEnd());
        reader.Close();
        List<ToDoItem> listOfEvents = new List<ToDoItem>();
        listOfEvents = eventCol.toDoItems.ToList();

        foreach (ToDoItem item in listOfEvents)
        {
            if(item.checkmark == false)
            {
                GameObject toDoItem = Instantiate(toDoPrefab, content);
                string dueDate = item.date;
                toDoItem.name = item.eventName;
                toDoItem.GetComponentInChildren<TextMeshProUGUI>().text = dueDate + ": " + item.eventName;
            }
        }
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

public class ToDoItem
{
    public string date;
    public string eventName;
    public bool checkmark;
}

[System.Serializable]
public class ToDoItemsCollection
{
    public ToDoItem[] toDoItems;
}
