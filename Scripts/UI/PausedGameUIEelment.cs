using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PausedGameUIEelment : MonoBehaviour
{
    private bool UIElementActive = false;
    private RectTransform UITransform;
    [SerializeField] private Ease moveEase;
    [SerializeField] private float moveDuration;

    //Opening Logic ------------------------------------------------------------------------
    private void Awake()
    {
        UITransform = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        GameManager.OnPauseMenuElement += GamePausedUIElementLogic;
    }
    private void OnDisable()
    {
        GameManager.OnPauseMenuElement -= GamePausedUIElementLogic;
    }

    //Game Paused Logic ------------------------------------------------------------------
    private void GamePausedUIElementLogic()
    {
        //GameManager has told the pause screen to move to postion
        //In editor this need to be its correct postion or animation wont load.
        if (!UIElementActive)
        {
            UIElementActive = true;
            UITransform.DOAnchorPosY(1f, moveDuration).SetEase(moveEase).SetUpdate(true);
        }
        else
        {
            UIElementActive = false;
            UITransform.DOAnchorPosY(-1100f, moveDuration).SetEase(moveEase).SetUpdate(true);
        }
        Debug.Log("Pause Menu UI Element: " + UIElementActive);
    }
}
