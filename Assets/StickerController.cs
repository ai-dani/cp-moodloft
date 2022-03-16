using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerController : MonoBehaviour
{
    public GameObject[] stickerPlacers;
    public GameObject stickerPlacerDemo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject GetStickerPlacerPanel(){
        return stickerPlacerDemo;
    }
}
