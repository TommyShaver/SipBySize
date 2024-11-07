using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIMoneyScore : MonoBehaviour
{
    public static UIMoneyScore IUIMoneyScore { get; set; }
    public RectTransform uiTransform;
    private TextMeshProUGUI scoreTExt;
    private float score = 0;
    private Vector2 sendToLocaltion = new Vector2(-100.1f, 50);
    private Vector2 sendToOutLocation = new Vector2(200, 50);
    [SerializeField] float uiTimeMove;

    private void Awake()
    {
        if (IUIMoneyScore != null && IUIMoneyScore != this)
        {
            Destroy(this);
        }
        else
        {
            IUIMoneyScore = this;
        }
        scoreTExt = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        scoreTExt.text = "0.00";
        uiTransform.anchoredPosition = sendToOutLocation;
    }


    //Money Logic ------------------------------------------------------------
    public void ScoreUpdate(float updatedScore)
    {
        StartCoroutine(ScoreAnim(updatedScore));
    }

    public void SlidingInAnim()
    {
        uiTransform.DOAnchorPos(sendToLocaltion, uiTimeMove).SetEase(Ease.OutCubic);
    }
    public void SlidingOutAnim()
    {
        uiTransform.DOAnchorPos(sendToOutLocation, uiTimeMove).SetEase(Ease.InCubic);
    }

    private IEnumerator ScoreAnim(float countUp)
    {
        float startCounting = 0;
        while (startCounting <= countUp)
        {
            startCounting += 0.01f;
            yield return new WaitForSeconds(.01f);
            uiTransform.DOShakeAnchorPos(.01f, new Vector2(0, 5f), 10, 90);
            score += 0.01f;
            scoreTExt.text = score.ToString("0.00");
            //Add Sound Effects;
        }
    }
}
