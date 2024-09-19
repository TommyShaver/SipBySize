using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CashRegisterSceneAnimation : MonoBehaviour
{
    public static CashRegisterSceneAnimation ICashRegisterScene { get; set; }
    public Transform[] enverorimentsGameObjects;
    

    private Vector3[] grabTransform = new Vector3[9];
    private float sendItemsToThisSpot;

    [SerializeField] float timeToDestinationFadeOut;
    [SerializeField] float timeToDestinationFadeIn;
    [SerializeField] float timeToNextAnimation;

    [SerializeField] Ease fadeInEase;
    [SerializeField] Ease fadeOutEase;

    //Set Up ----------------------------------------------------------------
    private void Awake()
    {
        if (ICashRegisterScene != null && ICashRegisterScene != this)
        {
            Destroy(this);
        }
        else
        {
            ICashRegisterScene = this;
        }
    }

    public void Start()
    {
        //Grab all the gameobjects in arry transforms postion. 
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            grabTransform[i] = enverorimentsGameObjects[i].transform.position;
        }
    }


    //Call from Game Manager -------------------------------------------------
    public void OnFadeInRequest()
    {
        gameObject.SetActive(true); // Draw to screen
        for (int i = 0; i < enverorimentsGameObjects.Length; i++) // Move all gameobject into place.
        {
            enverorimentsGameObjects[i].DOMoveX(grabTransform[i].x, timeToDestinationFadeIn).SetEase(fadeInEase);
        }
    }

    public void OnFadeOutRequest()
    {
        sendItemsToThisSpot = -100f; // Move gameobejcts way out there did this for people that have  21 by 9 monitors.
        StartCoroutine(BegainAnimamtion());
    }



    //Begin Animation -------------------------------------------------------
    private IEnumerator BegainAnimamtion()
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(sendItemsToThisSpot, timeToDestinationFadeOut).SetEase(fadeOutEase);
            yield return new WaitForSeconds(timeToNextAnimation);
        }
        yield return new WaitForSeconds(.5f); //Make sure DoTween finishes it job 
        for(int i = 0; i < enverorimentsGameObjects.Length; i++) // Move everything to load positons
        {
            enverorimentsGameObjects[i].DOMoveX(20f, 0, true);  
        }
        gameObject.SetActive(false); // Turn off gameobjects so you can see them.
    }
}
