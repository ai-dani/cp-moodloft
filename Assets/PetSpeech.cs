using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetSpeech : MonoBehaviour
{
    public Button secretButton;
    public GameObject speechObject;
    public TMP_Text speechText;
    public string[] randomTexts;
    public bool talking;

    // Start is called before the first frame update
    void Start()
    {
        talking = false;
        secretButton=GetComponent<Button>();
        secretButton.onClick.AddListener(SpeechifyWrapper);

        //start with a hello during the day :)
        string parentName = this.transform.parent.gameObject.transform.name;
        if(parentName.Equals("DayPet")){
            SpeechifyWrapper();
            setSpeechText("Hello, " + PlayerPrefs.GetString("PlayerName") + "!");
        }
    }

    
    void Update(){
        if(Input.GetMouseButtonDown(0) && talking){
            speechObject.SetActive(false);
            talking=false;
        }
    }

    void SpeechifyWrapper(){
        string parentName = this.transform.parent.gameObject.transform.name;
        if(parentName.Equals("DayPet")){
            StartCoroutine(Speechify());
        }
        else{
            StartCoroutine(Speechify());
            setSpeechText("Zzzzzz...");
        }
    }

    public IEnumerator Speechify(){
        talking=true;
        speechObject.SetActive(true);
        randomSpeechText();
        yield return new WaitForSeconds(3.0f);
        talking=false;
        speechObject.SetActive(false);
    }

    public void setSpeechText(string text){
        speechText.text = text;
    }

    public void randomSpeechText(){   
        int x = Random.Range(0,randomTexts.Length-1);
        speechText.text = "" + randomTexts[x];
    }
}
