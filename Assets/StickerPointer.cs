using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class StickerPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("selected");
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true); //SPECIFIC to water
    }

    public void OnPointerExit(PointerEventData eventData){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false); //SPECIFIC to water
    }
}