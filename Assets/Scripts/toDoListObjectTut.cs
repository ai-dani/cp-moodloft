using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toDoListObjectTut : MonoBehaviour
{
    public string objName;
    public string dueDate;
    public int index;

    private TextMeshProUGUI itemText;

    private void Start()
    {
        itemText = GetComponentInChildren<TextMeshProUGUI>();
        itemText.text = objName;
    }

    public void SetObjectInfo(string name, string dueDate, int index)
    {
        this.objName = name;
        this.dueDate = dueDate;
        this.index = index;
    }
}
