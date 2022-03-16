using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour
{
    public Image stickerImg;
    private Button stickerButton;
    public bool grabbing;
    GameObject currentSticker;
    public StickerController stickerController;
    
    // Start is called before the first frame update
    void Start()
    {
        grabbing=false;
        stickerImg = GetComponent<Image>();
        stickerButton = GetComponent<Button>();
        stickerController = FindObjectOfType<StickerController>();
        stickerButton.onClick.AddListener(GrabSticker);
    }

    void GrabSticker(){
        grabbing=true;
        currentSticker = Instantiate(gameObject, stickerController.gameObject.transform);

        //destroys button so it is not clickable
        Button buttonToDestroy = currentSticker.transform.gameObject.GetComponent<Button>();
        buttonToDestroy.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbing){
            currentSticker.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentSticker.transform.position = new Vector3(currentSticker.transform.position.x, currentSticker.transform.position.y, 0f);
        }

        //exits sticker mode deletes current sticker
        if(Input.GetKey(KeyCode.Delete) && grabbing){
            grabbing=false;
            Destroy(currentSticker);
        }

        //put down sticker
        if(Input.GetMouseButtonDown(0) && grabbing){
            grabbing=false;
        }


    }
}
