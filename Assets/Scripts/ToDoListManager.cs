using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDoListManager : MonoBehaviour
{
    public GameObject toDoPrefab;
    private GameObject toDoItem;
    public Transform content;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI dueDateText;


    public void addTask()
    {
        GameObject toDoItem = Instantiate(toDoPrefab, content);
        string name = nameInputField.text;
        string dueDate = dueDateText.text;
        toDoItem.name = name;
        toDoItem.GetComponentInChildren<TextMeshProUGUI>().text = dueDate + ": " + name;
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
}
