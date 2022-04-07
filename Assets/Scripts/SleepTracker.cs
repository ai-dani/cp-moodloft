using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//code from: https://forum.unity.com/threads/problems-linking-a-slider-and-an-input-field.279083/

public class SleepTracker : MonoBehaviour
{
    public Slider slider;
    public Button addHourButton;
    public Button subHourButton;

    private void Awake()
    {
        addHourButton.GetComponent<Button>().onClick.AddListener(AddHour);
        subHourButton.GetComponent<Button>().onClick.AddListener(SubHour);
    }

    void AddHour()
    {
        slider.value ++;
        print(slider.value);
    }

    void SubHour()
    {
        slider.value--;
        print(slider.value);
    }





    /*

        public Slider slider;
        public TMP_InputField inputText;

        private void Start()

        {
            slider = gameObject.GetComponent<Slider>();
            inputText = gameObject.GetComponent<TMP_InputField>();

        }

        public void UpdateValueFromInt(int NValue)
        {
            Debug.Log("Int value changed " + NValue);
            if (slider)
            {
                slider.value = NValue;
            }

            if (inputText)
            {

                inputText.text = NValue.ToString();
            }
        }

        public void UpdateValueFromString(string SValue)
        {
            Debug.Log("String value changed" + SValue);
            if (slider)
            {
                slider.value = int.Parse(SValue);
            }

            if (inputText)
            {

                inputText.text = SValue;
            }
        }

        */

}
