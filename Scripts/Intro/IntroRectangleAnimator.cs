using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IntroRectangleAnimator : MonoBehaviour
{
    [SerializeField] private int idNumber;
    private Vector3 startPos;
    private Vector3 endPos = new Vector3(0, 0, 0);
    private float flipTime = 0.5f;
    private bool idSet;

    //Setup Logic ---------------------------------------
    void Start()
    {
        startPos = transform.localScale; //Get local scale so it doesn't mess with the spwan
        AnimateIn();
    }
    private void OnEnable()
    {
        IntroAnimation.OnSpawnSendID += GetID;
        IntroAnimation.OnCleanupAnimation += AnimateOut;
    }

    private void OnDisable()
    {
        IntroAnimation.OnSpawnSendID -= GetID;
        IntroAnimation.OnCleanupAnimation -= AnimateOut;
    }

    //Logic ---------------------------------------------
    private void GetID(int id)
    {
        if(!idSet)
        {
            idNumber = id; //This ID gets past to gameobject on spawn.
            Debug.Log("[IntroRectangleAnimator] I got an ID its: " + idNumber);
            idSet = true;
        }
    }
    private void AnimateIn()
    {
        transform.localScale = new Vector3(0, 0, 0); //Make scale 0 so can animate in
        transform.DOScale(startPos, flipTime).SetEase(Ease.OutBounce);
    }
    private void AnimateOut(int id)
    {
        if (id == idNumber)
        {
            transform.DOScale(endPos, flipTime).SetEase(Ease.InBounce);
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Debug.Log("[IntroRectangleAnimator] Im about to bust: " + idNumber);
        Destroy(gameObject, 1); //Gets rid of and unsubscribe action event.
    }
}
