using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchEnveroriments : MonoBehaviour
{
    public static SwitchEnveroriments IDrinkStation { get; set; }
    public Transform[] enverorimentsGameObjects;
    public GameObject leftTri;
    public GameObject rightTri;

    private float sendItemsToThisSpot;
    private Vector3[] grabTransform = new Vector3[17];

    [SerializeField] float timeToDestinationFadeOut;
    [SerializeField] float timeToDestinationFadeIn;
    [SerializeField] float timeToNextAnimation;

    [SerializeField] Ease fadeInEase;
    [SerializeField] Ease fadeOutEase;

    //Set Up ------------------------------------------------------------------
    private void Awake()
    {
        if (IDrinkStation != null && IDrinkStation != this)
        {
            Destroy(this);
        }
        else
        {
            IDrinkStation = this;
        }
    }


    public void Start()
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++) //Grab all gameobjects transform
        {
            grabTransform[i] = enverorimentsGameObjects[i].transform.position;
        }
        SetUp(); //Once the game start send these to the loading postion and turn them off.
    }



    //Call from Game Manager -------------------------------------------------
    public void OnFadeInRequest()
    {
        gameObject.SetActive(true); //Draw to screen
        for (int i = 0; i < enverorimentsGameObjects.Length; i++) //Move To postion
        {
            enverorimentsGameObjects[i].DOMoveX(grabTransform[i].x, timeToDestinationFadeIn).SetEase(fadeInEase);
        }
        leftTri.SetActive(true);
        rightTri.SetActive(true);
    }

    public void OnFadeOutRequest()
    {
        sendItemsToThisSpot = -100f; //Send to the void for 21 by 9 screen reason
        StartCoroutine(BegainAnimamtion());
        leftTri.SetActive(false);
        rightTri.SetActive(false);
    }


    //Begin Animation -------------------------------------------------------
    private IEnumerator BegainAnimamtion()
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(sendItemsToThisSpot, timeToDestinationFadeOut).SetEase(fadeOutEase);
            yield return new WaitForSeconds(timeToNextAnimation);
        }
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(20f, 0, true);
        }
        gameObject.SetActive(false);
    }



    //Once the game starts set this up
    private void SetUp() //Reason on [line 41]
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(20f, 0, true);
        }
        gameObject.SetActive(false);
        leftTri.SetActive(false);
        rightTri.SetActive(false);
    }
}
