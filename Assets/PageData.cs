using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class PageData : MonoBehaviour
{
    public string directory = "/Resource/";
    public string fileName ="journalData.json";
    public string key;
    public TMPro.TMP_InputField textBox;
    public Button SaveButton;

    public void Start(){
        textBox=transform.GetComponentInChildren<TMPro.TMP_InputField>();
        SaveButton=transform.GetComponentInChildren<Button>();
        SaveButton.onClick.AddListener(SavePage);
    }
    
    public void SetKey(string newKey){
        key=newKey;
    }

    public string GetKey(){
        return key;
    }

    public void SetInputField(string text){
        textBox.text=text;
    }

    public string GetInputField(){
        return textBox.text;
    }

    public void SavePage(){
        string filePath = "Assets/Prefabs/Data/";
        string fileName = "myData.txt";
        //string dir = directory;
       // TextAsset jsonFile = dir;

        if(!textBox.text.Equals(""))
            if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
            }else{
                //StreamReader reader = new StreamReader(dir+fileName); 
                //create page based on current page
                string key = GetKey();
                string input = GetInputField();
                Page newPage = new Page();
                newPage.key = key;
                newPage.entry = input;

                StreamReader reader = new StreamReader(filePath+fileName);

                // Read existing json file linked in inspector
                PageCollection pageCol = JsonUtility.FromJson<PageCollection>(reader.ReadToEnd());
                reader.Close();
                Debug.Log("previous: " + JsonFile.text);
                List<Page> listOfPages = new List<Page>();
                listOfPages = pageCol.pages.ToList();
                listOfPages.Add(newPage);
                pageCol.pages = listOfPages.ToArray();

                //save to file
                string json = JsonUtility.ToJson(pageCol);
                File.WriteAllText(filePath+fileName, json);
                pageCol = JsonUtility.FromJson<PageCollection>(JsonFile.text);
                Debug.Log("new: " + json);
            }  
    }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;

    //  private void SavePageToJSON(){
    //     // Read existing json file linked in inspector
    //      PageCollection pageCol = JsonUtility.FromJson<PageCollection>(JsonFile.text);
    //      Debug.Log(pageCol);
    //      List<Page> listOfPages = pageCol.pages.ToList();

    //      listOfPages.Add(new Page{ key="4/5/2022", entry="hello"});

    //      pageCol.pages = listOfPages.ToArray();

    //     string newJsonString = JsonUtility.ToJson(pageCol);
    //      Debug.Log(newJsonString);
    //  }
}

[System.Serializable]

public class Page{
    public string key;
    public string entry;
}

[System.Serializable]
public class PageCollection{
    public Page[] pages;
}


