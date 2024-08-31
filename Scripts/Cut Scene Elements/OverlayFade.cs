using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OverlayFade : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    private bool fadeOutComplete = false;
    public Image image;

    
    private void OnEnable()
    {
        GameManager.OnFadeInOutUIElement += OnFadeCall;
    }
    private void OnDisable()
    {
        GameManager.OnFadeInOutUIElement -= OnFadeCall;
    }

    private void Start()
    {

        image.DOFade(1f, 0);
        fadeOutComplete = false;
    }

    public void OnFadeCall()
    {
        if(!fadeOutComplete)
        {
            image.DOFade(0f, fadeDuration);
            fadeOutComplete = true;
        }
        else
        {
            image.DOFade(1f, fadeDuration);
            fadeOutComplete = false;
        }
    }
}
