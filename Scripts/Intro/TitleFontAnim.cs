using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleFontAnim : MonoBehaviour
{
    private Vector3 endSclae = new Vector3(1, 1, 1);
    private float endPosY = 20f;

    [SerializeField] float scaleUpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
    private void OnEnable()
    {
        transform.DOScale(endSclae, scaleUpSpeed).SetEase(Ease.OutBounce);
        TitleScreenCutScene.OnTitleFontFadeUp += FadeUp;

    }
    private void OnDisable()
    {
        //Clean Up Code just incase This only runs once but I rather be safe then sorry.
        transform.localScale = new Vector3(0, 0, 0);
        TitleScreenCutScene.OnTitleFontFadeUp -= FadeUp;
        transform.position = new Vector3(0, 0, 0);
    }
    private void FadeUp()
    {
        transform.DOMoveY(endPosY, 1).SetEase(Ease.InOutBack);
    }
}
