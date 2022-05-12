using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterPanelController : MonoBehaviour
{
    public Button dropletButton;
    public GameObject dropletStickerTemplate;
    GameObject currentDroplet;
    public GameObject dropletPlacementPanel;
    public GameObject placerTemp;
    public bool grabbing;
    public bool placeable;
    public VirtualCursor virtualCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        virtualCursor = FindObjectOfType<VirtualCursor>();
        virtualCursor.enabled=false;
        grabbing=false;
        placeable=false;
        dropletButton.onClick.AddListener(createDropletSticker);
    }

    void createDropletSticker(){
        grabbing=true;
        currentDroplet = Instantiate(dropletStickerTemplate, dropletPlacementPanel.transform);
        currentDroplet.transform.localScale = new Vector3(1f,1f,1f);
    }
    // Update is called once per frame
    void Update()
    {
        if(grabbing){
            virtualCursor.enabled=true;
             currentDroplet.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDroplet.transform.position = new Vector3(currentDroplet.transform.position.x, currentDroplet.transform.position.y, 0f);
            if(virtualCursor.objectReturned!=null && virtualCursor.objectReturned.tag=="WaterStickerPanel"){
                GameObject currentDayPanel=virtualCursor.objectReturned;
                placeable=true;
                Color newColor=new Color(255,255,255,1); //increase opacity
                currentDroplet.GetComponent<Image>().color=newColor;
                currentDroplet.transform.parent=currentDayPanel.transform.Find("dropletparent").transform; //this is the third element child
            }
            else if(virtualCursor.objectReturned!=null){
                placeable=false;
                Color newColor=new Color(255,255,255,0.2f); //decrease opacity
                currentDroplet.GetComponent<Image>().color=newColor;
            }
        }

        //exits sticker mode deletes current sticker
        if(Input.GetKey(KeyCode.Delete) && grabbing){
            grabbing=false;
            Destroy(currentDroplet);
        }

        //put down sticker
        if(Input.GetMouseButtonDown(0) && placeable){
            grabbing=false;
            currentDroplet.GetComponent<Image>().raycastTarget = true;
        }
    }
}
