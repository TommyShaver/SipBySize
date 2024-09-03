using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchEnveroriments : MonoBehaviour
{
   public static SwitchEnveroriments IDrinkStation { get; set; }
   public Transform[] enverorimentsGameObjects;

    private float sendItemsToThisSpot;
    private Vector3[] grabTransform = new Vector3[16];

    [SerializeField] float timeToDestinationFadeOut;
    [SerializeField] float timeToDestinationFadeIn;
    [SerializeField] float timeToNextAnimation;

    [SerializeField] Ease fadeInEase;
    [SerializeField] Ease fadeOutEase;

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
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            grabTransform[i] = enverorimentsGameObjects[i].transform.position;
        }
        SetUp();
    }


    public void OnFadeInRequest()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(grabTransform[i].x, timeToDestinationFadeIn).SetEase(fadeInEase);
        }
    }

    public void OnFadeOutRequest()
    {
        sendItemsToThisSpot = -20f;
        StartCoroutine(BegainAnimamtion());
    }

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
    private void SetUp()
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(20f, 0, true);
        }
        gameObject.SetActive(false);
    }
}
