using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaterKey : MonoBehaviour
{
    public Button saveKey;
    public Button editKey;
    public TMP_InputField keyInput;
    public TMP_Text outputText;
    private string unsavedText;
    // Start is called before the first frame update
    void Start()
    {
        saveKey.onClick.AddListener(SaveKey);
        editKey.onClick.AddListener(EditKey);
        unsavedText="                        oz.";

        if(PlayerPrefs.GetFloat("WaterKeyVal") != 0){
            LoadKey();
        }
    }

    public void SaveKey(){
        if(!keyInput.text.Equals("")){
            PlayerPrefs.SetFloat("WaterKeyVal", float.Parse(keyInput.text));
            saveKey.gameObject.SetActive(false);
            editKey.gameObject.SetActive(true);
            keyInput.gameObject.SetActive(false);
            outputText.text = "" + PlayerPrefs.GetFloat("WaterKeyVal") + " oz.";
        }
    }

    public void LoadKey(){
            saveKey.gameObject.SetActive(false);
            editKey.gameObject.SetActive(true);
            keyInput.gameObject.SetActive(false);
        outputText.text ="" + PlayerPrefs.GetFloat("WaterKeyVal") + " oz.";
    }
    
    public void EditKey(){
        saveKey.gameObject.SetActive(true);
        editKey.gameObject.SetActive(false);
        keyInput.gameObject.SetActive(true);
        outputText.text = unsavedText;
    }



}
