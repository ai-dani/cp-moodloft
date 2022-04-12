using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordPlayer : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioClip[] audio;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;

    // Start is called before the first frame update
    void Start()
    {
        btn1.GetComponent<Button>().onClick.AddListener(changeAudio1);
        btn2.GetComponent<Button>().onClick.AddListener(changeAudio2);
        btn3.GetComponent<Button>().onClick.AddListener(changeAudio3);
        btn4.GetComponent<Button>().onClick.AddListener(changeAudio4);
        btn5.GetComponent<Button>().onClick.AddListener(changeAudio5);


    }


    void changeAudio1()
    {
        backgroundMusic.clip = audio[0];
        backgroundMusic.Play(); 
    }

    void changeAudio2()
    {
        backgroundMusic.clip = audio[1];
        backgroundMusic.Play();
    }

    void changeAudio3()
    {
        backgroundMusic.clip = audio[2];

        backgroundMusic.Play();
    }
    void changeAudio4()
    {
        backgroundMusic.clip = audio[3];
        backgroundMusic.Play();
    }

    void changeAudio5()
    {
        backgroundMusic.clip = audio[4];
        backgroundMusic.Play();
    }
}
