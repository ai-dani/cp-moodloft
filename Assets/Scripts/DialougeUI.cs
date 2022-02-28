using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DialougeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialougeObject test;
    [SerializeField] private GameObject box;
    private TyperWritterEffect effect; 

private void Start()
    {
        //texLabel.text = "Welcome to your Mood Loft" +
        //    "" +
        //    "Hello, I am your pet. \n This is your personal Loft";

        // GetComponent <TyperWritterEffect>().Run(textToType: "This is a bit of text \n hello", textLabel);

        effect = GetComponent<TyperWritterEffect>();
        Close();
        Show(test);
        
    }

    public void Show(DialougeObject dialougeObject)
    {
        box.SetActive(true);
        StartCoroutine(routine: StepThroughD(dialougeObject));
    }

    private IEnumerator StepThroughD(DialougeObject dialougeObject)
    {
        yield return new WaitForSeconds(2);
        foreach (string dialogue in dialougeObject.Dialogue)
        {
            yield return effect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); 
        }

        Close();
    }

    private void Close()
    {
        box.SetActive(false);
        textLabel.text = string.Empty;

    }

}
