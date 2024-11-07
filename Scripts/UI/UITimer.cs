using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UITimer : MonoBehaviour
{
    public static UITimer IUITimer { get; set; }
    public RectTransform uiTransform;
    private TextMeshProUGUI timerText;
    private bool timerSet;
    private bool animPlayedOnce;
    private Vector2 sendToLocaltion = new Vector2(250, -60);
    private Vector2 sendToOutLocation = new Vector2(-250, -60);
    private Vector2 timeIsRunningOutPos = new Vector2(302, -112);

    [SerializeField] Color colorRed;
    [SerializeField] Color colorYellow;
    [SerializeField] float timer;
    [SerializeField] float uiTimeMove;


    private void Awake()
    {
        if (IUITimer != null && IUITimer != this)
        {
            Destroy(this);
        }
        else
        {
            IUITimer = this;
        }
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        timerText.text = "00:00";
        uiTransform.anchoredPosition = sendToOutLocation;
    }

    private void Update()
    {
        if(timerSet)
        {
            if(timer >= 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay(timer);
                if(timer <= 10 && !animPlayedOnce)
                {
                    animPlayedOnce = true;
                    StartCoroutine(TimerAnim());
                }
            }
            else
            {
                animPlayedOnce = false;
                timerSet = false;
                timerText.text = "00:00";
            }
        }

    }

    public void IncomingInformation(float time)
    {
        timer = time;
        timerSet = true;
    }
    public void SlidingInAnim()
    {
        uiTransform.DOAnchorPos(sendToLocaltion, uiTimeMove).SetEase(Ease.OutCubic);
    }
    public void SlidingOutAnim()
    {
        uiTransform.DOAnchorPos(sendToOutLocation, uiTimeMove).SetEase(Ease.InCubic);
    }

    private void UpdateTimerDisplay(float currentTime)
    {
        // Format the time as minutes and seconds (00:00)
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator TimerAnim()
    {
        uiTransform.DOAnchorPos(timeIsRunningOutPos, .5f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(.01f);
        timerText.fontSize = 66;
        timerText.color = colorRed;
        yield return new WaitForSeconds(.01f);
        //Play sound effect
        uiTransform.DOShakeAnchorPos(.5f, new Vector2(0, 5f), 10, 90);
        yield return new WaitForSeconds(.5f);
        timerText.fontSize = 33;
        timerText.color = colorYellow;
        uiTransform.DOAnchorPos(sendToLocaltion, .1f).SetEase(Ease.OutCubic);
    }
}
