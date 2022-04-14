using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventsManager : MonoBehaviour
{
    public GameObject toDoPrefab;
    private GameObject toDoItem;
    public Transform content;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI dueDateText;
    public TextMeshProUGUI time1Text;
    public TextMeshProUGUI time2Text;

    public void addTask()
    {
        GameObject toDoItem = Instantiate(toDoPrefab, content);
        string name = nameInputField.text;
        string dueDate = dueDateText.text;
        string time1 = time1Text.text;
        string time2 = time2Text.text;
        toDoItem.name = name;
        toDoItem.GetComponentInChildren<TextMeshProUGUI>().text = time1 + "-" + time2 + ": " + name;
    }

    public void clearNameInput()
    {
        nameInputField.text = "";
    }
}
