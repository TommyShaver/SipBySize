using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchEnveroriments : MonoBehaviour
{
    public Transform enverorimentsGameObjects;

    private float sendItemsToThisSpot;
    private Vector3 grabTransform;

    [SerializeField] float timeToDestinationFadeOut;
    [SerializeField] float timeToDestinationFadeIn;

    [SerializeField] Ease fadeInEase;
    [SerializeField] Ease fadeOutEase;

    public void Start()
    {
        grabTransform = enverorimentsGameObjects.transform.position;
    }


    public void OnFadeInRequest()
    {
        gameObject.SetActive(true);
        enverorimentsGameObjects.DOMoveX(0, timeToDestinationFadeIn).SetEase(fadeInEase);
    }

    public void OnFadeOutRequest()
    {
        sendItemsToThisSpot = -20f;
        StartCoroutine(BegainAnimamtion());
    }


    private IEnumerator BegainAnimamtion()
    {
        enverorimentsGameObjects.DOMoveX(sendItemsToThisSpot, timeToDestinationFadeOut).SetEase(fadeOutEase);
        yield return new WaitForSeconds(.5f);
        enverorimentsGameObjects.DOMoveX(20f, 0, true);
        gameObject.SetActive(false);
    }
}
