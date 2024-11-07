using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMeterGaugeMovement : MonoBehaviour
{
    public static UIMeterGaugeMovement IUIMeterGaugeMovement { get; set; }
    private Vector3 startPos = new Vector3(1, -2, 0);
    private Vector3 endPos = new Vector3(-5.5f, -2, 0);
    private float speed = 1;

    private void Awake()
    {
        IUIMeterGaugeMovement = this;

    }

    void Start()
    {
        transform.DOMove(startPos, speed).SetEase(Ease.InSine);
    }

    public void MoveToInGamePos()
    {
        transform.DOMove(endPos, speed).SetEase(Ease.OutSine);
    }

    public void MoveOffScreen()
    {
        transform.DOMove(startPos, speed).SetEase(Ease.InSine);
    }
}
