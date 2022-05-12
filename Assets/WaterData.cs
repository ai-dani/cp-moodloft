using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class WaterData : MonoBehaviour
{
    public string filePath = "Assets/Prefabs/Data/";
    public string fileName = "waterData.txt";
    public string key;
    public Button SaveButton;
    public TMPro.TMP_Text LastSavedText;
    public GameObject dropletParent;
    public GameObject dropletImageTemplate;

    public void Start(){
        SaveButton.onClick.AddListener(saveWater);
        loadWater();
    }

    public void Update(){
        if(dropletParent==null){
             dropletParent = transform.Find("dropletparent").gameObject; //finds parent only once when this object activates
        }
    }
    
    public void SetKey(string newKey){
        key=newKey;
    }

    public string GetKey(){
        return key;
    }

    public void saveWater(){
        //if directory exists
            if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
            }else{
                //create page based on current page
                string key = GetKey();
                water newwater = new water();
                newwater.key = key;
                newwater.time = System.DateTime.Now.ToShortTimeString();

                StreamReader reader = new StreamReader(filePath+fileName);

                // Read existing json file linked in inspector
                waterCollection waterCol = JsonUtility.FromJson<waterCollection>(reader.ReadToEnd());
                reader.Close();

                //adding a new page to existing page
                List<water> listOfwaters = new List<water>();
                listOfwaters = waterCol.waters.ToList();

                bool keyExists = false;
                 //if the key from the json file equals to this page's key
                foreach(water water in listOfwaters){
                    //if this key already exists, edit existing entry
                    if(water.key.Equals(GetKey())){ 
                        List<droplets> listofdroplets = new List<droplets>();
                        listofdroplets=water.droplets.ToList();
                        if(dropletParent.transform.childCount>0){
                            for(int i=0; i <dropletParent.transform.childCount;i++){
                                GameObject droplet = dropletParent.transform.GetChild(i).gameObject;
                                float xPos = droplet.transform.localPosition.x;
                                float yPos = droplet.transform.localPosition.y;
                                float zPos = droplet.transform.localPosition.z;
                                string dropletKey = "" + xPos + yPos + zPos;

                                droplets newDroplet=new droplets();
                                newDroplet.xPos=xPos;
                                newDroplet.yPos=yPos;
                                newDroplet.zPos=zPos;
                                newDroplet.xyz=dropletKey;

                                //verifies if this droplet already exists
                                bool dropletKeyExists = false;
                                for(int j = 0; j < listofdroplets.Count; j++){
                                    if(listofdroplets[j].xyz.Equals(newDroplet.xyz)){
                                        Debug.Log("broke");
                                        dropletKeyExists=true;
                                        break;
                                    }
                                }
                                if(!dropletKeyExists){
                                    listofdroplets.Add(newDroplet);
                                }

                            }

                            water.droplets=listofdroplets.ToArray();
                            //listOfwaters.Add(newwater);
                        }
                        water.time=System.DateTime.Now.ToShortTimeString();
                        keyExists=true;
                        break;
                    }
                }
                //normally add object, if the key doesn't already exist
                if(!keyExists){
                    List<droplets> listofdroplets = new List<droplets>();

                    //foreach new droplet instantiated under the parent
                    if(dropletParent.transform.childCount>0){
                        for(int i=0; i <dropletParent.transform.childCount;i++){
                                GameObject droplet = dropletParent.transform.GetChild(i).gameObject;
                                float xPos = droplet.transform.localPosition.x;
                                float yPos = droplet.transform.localPosition.y;
                                float zPos = droplet.transform.localPosition.z;
                                string dropletKey = "" + xPos + yPos + zPos;

                                droplets newDroplet=new droplets();
                                newDroplet.xPos=xPos;
                                newDroplet.yPos=yPos;
                                 newDroplet.zPos=zPos;
                                newDroplet.xyz=dropletKey;
                                listofdroplets.Add(newDroplet);
                         }
                    }
                    newwater.droplets=listofdroplets.ToArray();
                    listOfwaters.Add(newwater);
                }
                

                //change to array
                waterCol.waters = listOfwaters.ToArray();

                //save to file
                string json = JsonUtility.ToJson(waterCol, true);
                File.WriteAllText(filePath+fileName, json);
                waterCol = JsonUtility.FromJson<waterCollection>(JsonFile.text);

                LastSavedText.text = "Saved on " + System.DateTime.Now.Date.ToString("MM-dd-yyyy") + " at " + newwater.time;
            }  
        
    }

    //loads the water colors saved for the week
    public void loadWater(){
        // Read existing json file linked in inspector
        StreamReader reader = new StreamReader(filePath+fileName);
        waterCollection waterCol = JsonUtility.FromJson<waterCollection>(reader.ReadToEnd());
        reader.Close();
        List<water> listOfwaters = new List<water>();
        if(listOfwaters != null)
            listOfwaters = waterCol.waters.ToList();

        //if the key from the json file equals to this page's key
        foreach(water water in listOfwaters){
            if(water.key.Equals(GetKey())){
                foreach(droplets droplet in water.droplets){
                    GameObject newDroplet = Instantiate(dropletImageTemplate, dropletParent.transform);
                    newDroplet.transform.localPosition = new Vector3(droplet.xPos,droplet.yPos,droplet.zPos);
                }
                if(!water.time.Equals(""))
                    LastSavedText.text="Last saved on " + System.DateTime.Now.Date.ToString("MM-dd-yyyy") + " at " + water.time;
            }
        }
    }

    public TextAsset JsonFile;
}

[System.Serializable]

public class water{
    public string key; //thisis the date
    public string time; //this is the time

    public droplets[] droplets;
    //public float amt;
}

[System.Serializable]
public class droplets{
    public string xyz; //droplet key
    public float xPos;
    public float yPos;
    public float zPos;
}

[System.Serializable]
public class waterCollection{
    public water[] waters;
}


