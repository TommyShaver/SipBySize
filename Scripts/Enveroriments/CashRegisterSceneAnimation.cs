using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CashRegisterSceneAnimation : MonoBehaviour
{
    public Transform[] enverorimentsGameObjects;
    

    private Vector3[] grabTransform = new Vector3[9];
    private float sendItemsToThisSpot;

    [SerializeField] float timeToDestinationFadeOut;
    [SerializeField] float timeToDestinationFadeIn;
    [SerializeField] float timeToNextAnimation;

    [SerializeField] Ease fadeInEase;
    [SerializeField] Ease fadeOutEase;


    private void OnEnable()
    {
        //GameManager.OutBoundEvent1 += OnFadeInRequest;
    }
    private void OnDisable()
    {
        //GameManager.OutBoundEvent1 -= OnFadeInRequest;
    }


    public void Start()
    {
        for (int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            grabTransform[i] = enverorimentsGameObjects[i].transform.position;
        }
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
        for(int i = 0; i < enverorimentsGameObjects.Length; i++)
        {
            enverorimentsGameObjects[i].DOMoveX(20f, 0, true);  
        }
        gameObject.SetActive(false);
    }
}
