using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BubblesController : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    [SerializeField] float jumpDuration;
    private Vector3 startingPostion;
    private Vector3 middlePostion = new Vector3(0.5f, 1f, 0);
    private Vector3 endPostion = new Vector3(-1, -1, 0);
    private bool backToStart;

    //Setup --------------------------------------------------------------------
    private void Start()
    {
        startingPostion = transform.position;
    }

    //Jump Logic ----------------------------------------------------------------
    public void JumpTest()
    {
        JumpLogic();
    }

    private void JumpLogic()
    {
        Sequence jumpSequence = DOTween.Sequence();
        BubblesAnimationController.Instace_BubblesAnimationController.BubblesBody(6);
        BubblesAnimationController.Instace_BubblesAnimationController.BubblesFace(9);
        jumpSequence.Append(transform.DOMove(middlePostion, jumpDuration).SetEase(Ease.OutQuad));
        if (!backToStart)
        {
            jumpSequence.Append(transform.DOMove(endPostion, fallSpeed)
            .SetEase(Ease.InQuad)
            .OnComplete(FinishedJump)
            );
            backToStart = true;
        }
        else
        {
            jumpSequence.Append(transform.DOMove(startingPostion, fallSpeed)
            .SetEase(Ease.InQuad)
            .OnComplete(FinishedJump)
            );
            backToStart = false;
        }
    }

    private void FinishedJump()
    {
        BubblesAnimationController.Instace_BubblesAnimationController.BubblesBody(1);
        BubblesAnimationController.Instace_BubblesAnimationController.BubblesFace(7);
    } 
}
