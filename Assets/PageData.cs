using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class PageData : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "myData.txt";
    public string key;
    public TMPro.TMP_InputField textBox;
    public Button SaveButton;
    //public Button EditButton;

    public void Start(){
        textBox=transform.GetComponentInChildren<TMPro.TMP_InputField>();
        SaveButton.onClick.AddListener(SavePage);

        LoadPage();
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
        // string filePath = "Assets/Prefabs/Data/";
        // string fileName = "myData.txt";
        //string dir = directory;
       // TextAsset jsonFile = dir;

        //if there's actual entry to be saved
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

                //adding a new page to existing page
                List<Page> listOfPages = new List<Page>();
                listOfPages = pageCol.pages.ToList();

                bool keyExists = false;
                 //if the key from the json file equals to this page's key
                foreach(Page page in listOfPages){
                    //if this key already exists, edit existing entry
                    if(page.key.Equals(GetKey())){ 
                        page.entry = input;
                        keyExists=true;
                        break;
                    }
                }
                //normally add object, if the key doesn't already exist
                if(!keyExists)
                    listOfPages.Add(newPage);

                //change to array
                pageCol.pages = listOfPages.ToArray();

                //save to file
                string json = JsonUtility.ToJson(pageCol, true);
                File.WriteAllText(filePath+fileName, json);
                pageCol = JsonUtility.FromJson<PageCollection>(JsonFile.text);
                Debug.Log("new: " + json);

                //ToggleEdit();
            }  
    }

    public void LoadPage(){
        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath+fileName);
        PageCollection pageCol = JsonUtility.FromJson<PageCollection>(reader.ReadToEnd());
        reader.Close();
        List<Page> listOfPages = new List<Page>();
        listOfPages = pageCol.pages.ToList();

        //if the key from the json file equals to this page's key
        foreach(Page page in listOfPages){
            if(page.key.Equals(GetKey())){
                if(!page.entry.Equals("")){ //if there's something in the entry
                    textBox.text=page.entry;
                    //ToggleEdit();
                }    
            }
        }
    }

    // public void ToggleEdit(){
    //     SaveButton.gameObject.SetActive(false);
    //     EditButton.gameObject.SetActive(true);
    // }

    //REF: https://answers.unity.com/questions/1580286/how-to-append-a-json-array-to-an-already-created-j.html
    public TextAsset JsonFile;
}

[System.Serializable]

public class Page{
    public string key;
    public string entry;
    public StickerData[] sticker; //stickers
}

[System.Serializable]
public class PageCollection{
    public Page[] pages;
}

[System.Serializable]
public class StickerData{
    public string fileLocation;
    public float xPos;
    public float yPos;
    public float zPos;
}


