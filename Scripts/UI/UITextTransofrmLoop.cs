using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITextTransofrmLoop : MonoBehaviour
{
    [SerializeField] RectTransform UITransform;
    [SerializeField] float moveDistance;
    [SerializeField] float duration;
    [SerializeField] bool startDuringLoad;
    [SerializeField] bool animWorksWithTimeScale;
    private bool hasRun;
    private bool startAnim= true;
    private Tween UITween;

    //Set Up -----------------------------------------
    private void Start()
    {
        AnimationSetUp();
        if (!startDuringLoad)
        {
            UITween.Pause();
        }
    }

    private void OnEnable()
    {
        GameManager.OnPauseMenuElement += UIAniamtion;
        if(!hasRun)
        {
            UITween.Play();
        }
    }
    private void OnDisable()
    {
        GameManager.OnPauseMenuElement -= UIAniamtion;
        if(hasRun)
        {
            UITween.Pause();
        }
    }


    // Animation Logic --------------------------------
    private void AnimationSetUp()
    {
        UITween = UITransform.DOLocalMoveY(moveDistance, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(animWorksWithTimeScale);
    }

    //Called from loading screen
    private void UIAniamtion()
    {
        if(startAnim)
        {
            UITween.Play();
            startAnim = false;
        }
        else
        {
            UITween.Pause();
            startAnim = true;
        }
        
    }

}