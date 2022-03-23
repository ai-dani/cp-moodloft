using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialougeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialougeObject test;
    [SerializeField] private GameObject box;
    private TyperWritterEffect effect;
    public Button roomButton;
    private int count;
    public TMP_InputField playerName;
    public GameObject infoArea;

private void Awake()
    {
        //texLabel.text = "Welcome to your Mood Loft" +
        //    "" +
        //    "Hello, I am your pet. \n This is your personal Loft";
        // GetComponent <TyperWritterEffect>().Run(textToType: "This is a bit of text \n hello", textLabel);

        effect = GetComponent<TyperWritterEffect>();
        Close();
        Show(test);
        roomButton.gameObject.SetActive(false);
    }

    public void Show(DialougeObject dialougeObject)
    {
        box.SetActive(true);
        StartCoroutine(routine: StepThroughD(dialougeObject));
    }

    private IEnumerator StepThroughD(DialougeObject dialougeObject)
    {
        yield return new WaitForSeconds(1.5f);
        foreach (string dialogue in dialougeObject.Dialogue)
        {
            string analyzedDialogue = "";
            analyzedDialogue = AnalyzeText(dialogue);
            yield return effect.Run(analyzedDialogue, textLabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));


            //Used to make room button avalible after set text appears
            //Checks to see how many dialogue obejcts there are and compares that to the amount of times user clicks on sceen
            if(Input.GetMouseButtonDown(0))
            {
                count++;
                //print(count); test 

                // checks to see if count is >= to the amount of objects found in the dialogue. makes button active 
                if (count >= dialougeObject.Dialogue.Length-1)
                {
                    roomButton.GetComponent<Button>();
                    roomButton.gameObject.SetActive(true);
                }
            }
        }
        Close();
    }

    public string AnalyzeText(string text)
    {      
        text = CheckAndReplaceName(text);
        //can list more methods here for the future, like "checking other names"
        return text;
    }

    //this method checks text if need player name
    public string CheckAndReplaceName(string text)
    {
        if (text.Contains("[name]"))
        {
            //Debug.Log("yup it contains a name lol");
            string new_Text = text.Replace("[name]", PlayerPrefs.GetString("PlayerName"));            
            string name = PlayerPrefs.GetString("name");
            return new_Text;
        }
        else
        {
            return text;
        }
    }

    private void Close()
    {
        box.SetActive(false);
        textLabel.text = string.Empty;

    }

}
