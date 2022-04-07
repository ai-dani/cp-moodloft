using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDoListManager : MonoBehaviour
{/*
    public Transform content;
    public GameObject addPanel;
    public Button createButton;
    public GameObject toDoListItemPrefab;

<<<<<<< HEAD
=======
    string filePath;
    private List<toDoListObjectTut> toDoListObjects = new List<toDoListObjectTut>();

    private InputField[] addInputFields;

    private void Start()
    {
        //filePath = Application.persistentDataPath = "/toDoList.txt";
        //addInputFields = addPanel.GetCompnentsInChildren<InputFields>();

        createButton.onClick.AddListener(delegate { CreateToDoListItem(addInputFields[0].text, addInputFields[1].text); });
    }

   /* void switchMode(int mode)
    {
        switch (mode)
        {
            case 0:
                addPanel.setActive(false);
                break;
            case 1:
                addPanel.SetActive(true);
                break;
        }
    }*/
>>>>>>> parent of 202e500 (IDK HOPE YOU WORK)

/*
    void CreateToDoListItem(string name, string type)
    {
<<<<<<< HEAD
        GameObject toDoItem = Instantiate(toDoPrefab, content);
        string name = nameInputField.text;
        string dueDate = dueDateText.text;
        toDoItem.GetComponentInChildren<TextMeshProUGUI>().text = dueDate + ": " + name;
        nameInputField.text = "";

    }

    public void clearNameInput()
    {
        nameInputField.text = "";
    }


    /* public Transform content;
     public GameObject addPanel;
     public Button createButton;
     public GameObject toDoListItemPrefab;

     string filePath;

     private List<toDoListObject> toDoListObjects = new List<toDoListObject>();


     private InputField[] addInputFields;

     private void Start()
     {
         filePath = Application.persistentDataPath = "/toDoList.txt";
         addInputFields = addPanel.GetComponentsInChildren<InputFields>();

         createButton.onClick.AddListener(delegate { CreateToDoListItem(addInputFields[0].text, addInputFields[1].text); });
     }

     void switchMode(int mode)
     {
         switch (mode)
         {
             case 0:
                 addPanel.SetActive(false);
                 break;
             case 1:
                 addPanel.SetActive(true);
                 break;
         }
     }


     void CreateToDoListItem(string name, string type)
     {
         GameObject item = Instantiate(toDoListItemPrefab);

         item.transform.SetParent(content);
         toDoListObject itemObject = item.GetComponent<toDoListObject>();

         int index = 0;
         if (toDoListObject.Count > 0)
             index = toDoListObject.Count - 1;
         itemObject.SetObjectInfo(name, type, index);

         toDoListObjects.Add(itemObject);
         toDoListObject temp = itemObject;
         itemObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate { toDoListItem(temp); });
     }

     void toDoListItem(toDoListObject item)
     {
         toDoListObjects.Remove(item);
         Destroy(item.gameObject);
     }*/
=======
        GameObject item = Instantiate(toDoListItemPrefab);
        
        item.transform.SetParent(content);
        toDoListObjectTut itemObject = item.GetComponents<toDoListObjectTut>();

        int index = 0;
        if(toDoListObjectTut.Count > 0)
            int index = toDoListObjectTut.Count - 1;
        itemObject.SetObjectInfo(name, type, index);

        toDoListObjects.Add(itemObject);
        toDoListObjectTut temp = itemObject;
        itemObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate { toDoListItem(temp); });
    }

    void toDoListItem(toDoListObjectTut item)
    {
        toDoListObects.Remove(item);
    }
*/
>>>>>>> parent of 202e500 (IDK HOPE YOU WORK)
}
