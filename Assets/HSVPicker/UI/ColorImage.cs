﻿using UnityEngine;
using UnityEngine.UI;

namespace HSVPicker
{
    [RequireComponent(typeof(Image))]
    public class ColorImage : MonoBehaviour
    {
        public ColorPicker picker;
        public Color currentColor;

        public Button mon;
        public Button tue;
        public Button wed;
        public Button thur;
        public Button fri;
        public Button sat;
        public Button sun;

       
        public Image monImg;
        public Image tueImg;
        public Image wedImg;
        public Image thurImg;
        public Image friImg;
        public Image satImg;
        public Image sunImg;

        private void Awake()
        {

            picker.onValueChanged.AddListener(ColorChanged);

            mon.GetComponent<Button>().onClick.AddListener(TaskOnClick1);
            tue.GetComponent<Button>().onClick.AddListener(TaskOnClick2);
            wed.GetComponent<Button>().onClick.AddListener(TaskOnClick3);
            thur.GetComponent<Button>().onClick.AddListener(TaskOnClick4);
            fri.GetComponent<Button>().onClick.AddListener(TaskOnClick5);
            sat.GetComponent<Button>().onClick.AddListener(TaskOnClick6);
            sun.GetComponent<Button>().onClick.AddListener(TaskOnClick7);
        }

        void TaskOnClick1()
        { 
            monImg.color = currentColor;
            
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick2()
        { 
            tueImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick3()
        {
            wedImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick4()
        {
            thurImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick5()
        {
            friImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick6()
        {
            satImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        void TaskOnClick7()
        {
            sunImg.color = currentColor;
            Debug.Log("You have clicked the button!");
        }

        private void OnDestroy()
        {
            picker.onValueChanged.RemoveListener(ColorChanged);
        }

        private void ColorChanged(Color newColor)
        {
            currentColor = newColor;
        }
    }

}