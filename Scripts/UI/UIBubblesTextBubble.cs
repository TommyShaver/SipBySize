using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIBubblesTextBubble : MonoBehaviour
{
    public CanvasGroup UIBox;
    private bool UIBoxShowing = true;
    [SerializeField] float duration;
    
    public void TextBoxFadeAnimation()
    {
        if(UIBoxShowing)
        {
            UIBox.DOFade(1f, duration);
            UIBoxShowing = false;
        }
        else
        {
            UIBox.DOFade(0f, duration);
            UIBoxShowing = true;
        }
    }
}
