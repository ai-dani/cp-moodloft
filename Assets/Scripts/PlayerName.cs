using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerName : MonoBehaviour
{ 
    public TMP_Text playerName;
    public Button submitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(SubmitName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitName()
    {
        if (playerName != null)
        {
            if (!playerName.text.Equals(""))
            {
                PlayerPrefs.SetString("PlayerName", playerName.text);
            }
        }
    }
}
