using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour
{
    public Image stickerImg;
    private Button stickerButton;
    public bool grabbing;
    public bool placeable;
    GameObject currentSticker;
    public StickerController stickerController;
    public StickerPanelController stickerPanelController;

    public VirtualCursor virtualCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        grabbing=false;
        stickerImg = GetComponent<Image>();
        stickerButton = GetComponent<Button>();
        //stickerController = FindObjectOfType<StickerController>();
        stickerPanelController = FindObjectOfType<StickerPanelController>(); //must manually drag to each sticker
        stickerButton.onClick.AddListener(GrabSticker);
        virtualCursor = FindObjectOfType<VirtualCursor>();
        virtualCursor.enabled=false;
        placeable=false;
    }

    void GrabSticker(){
        grabbing=true;
        stickerPanelController.SlideDown();
        currentSticker = Instantiate(gameObject, stickerController.gameObject.transform);

        //destroys button so it is not clickable
        Button buttonToDestroy = currentSticker.transform.gameObject.GetComponent<Button>();
        Destroy(buttonToDestroy);
        currentSticker.GetComponent<Image>().raycastTarget = false;
        //buttonToDestroy.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbing){
            virtualCursor.enabled=true;
            currentSticker.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSticker.transform.position = new Vector3(currentSticker.transform.position.x, currentSticker.transform.position.y, 0f);
            
            if(virtualCursor.objectReturned!=null && virtualCursor.objectReturned.tag=="JournalStickerPanel"){
                placeable=true;
                Color newColor=new Color(255,255,255,1); //increase opacity
                currentSticker.GetComponent<Image>().color=newColor;
            }
            else if(virtualCursor.objectReturned!=null){
                placeable=false;
                Color newColor=new Color(255,255,255,0.2f); //decrease opacity
                currentSticker.GetComponent<Image>().color=newColor;
            }
        }

        //exits sticker mode deletes current sticker
        if(Input.GetKey(KeyCode.Delete) && grabbing){
            grabbing=false;
            Destroy(currentSticker);
        }

        //put down sticker
        if(Input.GetMouseButtonDown(0) && placeable &&grabbing){
            stickerPanelController.SlideUp();
            grabbing=false;
            currentSticker.GetComponent<Image>().raycastTarget = true;
        }


    }
}
