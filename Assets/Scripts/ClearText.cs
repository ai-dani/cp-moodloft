using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ClearText : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void clearTextBox()
    {
        nameInputField.text = "";
    }
}
