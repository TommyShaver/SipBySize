using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextAnimation : MonoBehaviour
{
    //Lets the Dialog Manager know when it is ok to advance to the next phrase.
    public static event Action OnAdvanceNextString;

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] GameObject advanceTextIndacator;
    [SerializeField] float textSpeed;

    //Setup logic-----------------------------------
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    private void Start()
    {
        ClearTextBox();
    }


    //Text Box Logic ---------------------------------- 
    private void ClearTextBox()
    {
        textComponent.text = string.Empty;
        advanceTextIndacator.SetActive(false);
    }
    private void IncomingString(string s)
    {
        ClearTextBox();
        StartCoroutine(TypeLine(s));
    }

    IEnumerator TypeLine(string linesOfSpeech)
    {
        foreach (char c in linesOfSpeech.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        advanceTextIndacator.SetActive(true);
        //OnAdvanceNextString?.Invoke();
    }
}
