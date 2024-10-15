using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectorArrows : MonoBehaviour
{
    public GameObject whichSelector;
    private new BoxCollider2D collider2D;
    [SerializeField] float objectMovement;
    [SerializeField] float duration;
    [SerializeField] bool goingLeft;
    private Tween myTween;
    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        if(goingLeft)
        {
            objectMovement *= -1;
        }
    }

    private void Start()
    {
        myTween = transform.DOLocalMoveX(transform.position.x + objectMovement, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnEnable()
    {
        myTween.Play();
    }

    private void OnDisable()
    {
        myTween.Pause();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clicked = Physics2D.Raycast(mousePos, Vector2.zero);
            if(clicked.collider == collider2D)
            {
                BobaPump.IBobaPump.TestMessage(whichSelector);
            }
        }
    }
}
