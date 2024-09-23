using UnityEngine;
using DG.Tweening;

public class OtherCharaterController : MonoBehaviour
{
    private Vector3 startPos;
    private float sendSpriteOffScreen = -50;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnEnable()
    {
        transform.DOMoveX(-50, 0);
        transform.DOMove(startPos, 0.4f);
    }
}
