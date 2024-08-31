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

    //Opening Logic
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
    private void GamePausedUIElementLogic()
    {
        if (!UIElementActive)
        {
            UIElementActive = true;
            UITransform.DOAnchorPosY(1f, moveDuration).SetEase(moveEase).SetUpdate(true);
        }
        else
        {
            UIElementActive = false;
            UITransform.DOAnchorPosY(-1000f, moveDuration).SetEase(moveEase).SetUpdate(true);
        }
        Debug.Log("Pause Menu UI Element: " + UIElementActive);
    }
}
