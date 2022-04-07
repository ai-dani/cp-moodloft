using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StickerPanelController : MonoBehaviour
{
    public Animator anim;
    public Button slideDownButton;
    public Button slideUpButton;
    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        slideDownButton.onClick.AddListener(SlideDown);
        slideUpButton.onClick.AddListener(SlideUp);
        closeButton.onClick.AddListener(Close);
    }

    public void SlideDown(){
        anim.SetTrigger("slideDown");
    }

    public void SlideUp(){
        anim.SetTrigger("slideUp");
    }

    void Close(){
        anim.SetTrigger("closeDown");
        this.gameObject.SetActive(false);
    }
}
