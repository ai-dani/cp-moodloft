using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskListener : MonoBehaviour
{
    public Transform content;
    public string[] delete;

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in content)
        {
            Transform temp = child;
            if (temp.GetComponentInChildren<Toggle>().isOn)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
