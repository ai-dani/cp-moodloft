using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class MoodData : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "moodData.txt";
    public string key;
    public Button SaveButton;
    public TMPro.TMP_Text LastSavedText;

    public void Start(){
        SaveButton.onClick.AddListener(SaveMood);
        LoadMood();
    }
    
    public void SetKey(string newKey){
        key=newKey;
    }

    public string GetKey(){
        return key;
    }

    public void SaveMood(){
        //if directory exists
            if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
            }else{
                //StreamReader reader = new StreamReader(dir+fileName); 
                //create page based on current page
                string key = GetKey();
                Mood newMood = new Mood();
                newMood.key = key;
                string hex = ColorUtility.ToHtmlStringRGB(GetComponent<Image>().color);
                newMood.hexValue = hex;
                newMood.time = System.DateTime.Now.ToShortTimeString();

                StreamReader reader = new StreamReader(filePath+fileName);

                // Read existing json file linked in inspector
                MoodCollection moodCol = JsonUtility.FromJson<MoodCollection>(reader.ReadToEnd());
                reader.Close();

                //adding a new page to existing page
                List<Mood> listOfMoods = new List<Mood>();
                listOfMoods = moodCol.moods.ToList();

                bool keyExists = false;
                 //if the key from the json file equals to this page's key
                foreach(Mood mood in listOfMoods){
                    //if this key already exists, edit existing entry
                    if(mood.key.Equals(GetKey())){ 
                        mood.hexValue=hex;
                        mood.time=System.DateTime.Now.ToShortTimeString();
                        keyExists=true;
                        break;
                    }
                }
                //normally add object, if the key doesn't already exist
                if(!keyExists)
                    listOfMoods.Add(newMood);

                //change to array
                moodCol.moods = listOfMoods.ToArray();

                //save to file
                string json = JsonUtility.ToJson(moodCol, true);
                File.WriteAllText(filePath+fileName, json);
                moodCol = JsonUtility.FromJson<MoodCollection>(JsonFile.text);

                LastSavedText.text = "Saved on " + System.DateTime.Now.Date.ToString("MM-dd-yyyy") + " at " + newMood.time;
            }  
    }

    //loads the mood colors saved for the week
    public void LoadMood(){
        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath+fileName);
        MoodCollection moodCol = JsonUtility.FromJson<MoodCollection>(reader.ReadToEnd());
        reader.Close();
        List<Mood> listOfMoods = new List<Mood>();
        if(listOfMoods != null)
            listOfMoods = moodCol.moods.ToList();

        //if the key from the json file equals to this page's key
        foreach(Mood mood in listOfMoods){
            if(mood.key.Equals(GetKey())){
                Color newColor = new Color();
                string hex = "#" + mood.hexValue;
                if ( ColorUtility.TryParseHtmlString(hex, out newColor)){
                    GetComponent<Image>().color = newColor;
                }
                if(!mood.time.Equals(""))
                    LastSavedText.text="Last saved on " + System.DateTime.Now.Date.ToString("MM-dd-yyyy") + " at " + mood.time;
            }
        }
    }

    public TextAsset JsonFile;
}

[System.Serializable]

public class Mood{
    public string key; //thisis the date
    public string time; //this is the time
    public string hexValue;
}

[System.Serializable]
public class MoodCollection{
    public Mood[] moods;
}


