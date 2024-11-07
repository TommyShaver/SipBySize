using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.Rendering.DebugUI;

public class UITimedTriangle : MonoBehaviour
{
    public static UITimedTriangle ITimedTriangle{ get; set; }
    private float maxDisMove = 0.45f;
    private float speed = 1;
    private float floatReturn;
    private bool isStarted;

    private Sequence moveSequence;
    private Vector3 startPos;

    private void Awake()
    {
        if (ITimedTriangle != null && ITimedTriangle != this)
        {
            Destroy(this);
        }
        else
        {
            ITimedTriangle = this;
        }
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void TriangleLoopStart()
    {
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOLocalMoveY(-maxDisMove, speed).SetEase(Ease.Linear));
        moveSequence.SetLoops(-1, LoopType.Yoyo);
    }

    private float NumberReturn()
    {
        floatReturn = transform.localPosition.y;
        floatReturn = Mathf.Ceil(floatReturn * 100) / 100;

        return floatReturn;
    }

    public void SendData(float sendNumber)
    {
        Debug.Log(floatReturn + " float number returned");
    }


    // Incoming Data ---------------------------------------------------------
    public void IncomingInfo() // InputManager
    {
        SendData(NumberReturn());
        moveSequence.Pause();
    }

    public void ResetTriangle(float s) // Game manager
    {
        speed = s;
        moveSequence.Kill();
        transform.position = startPos;
        TriangleLoopStart();
    }
}
