using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class P5AOpeningAnim : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Vector3 endPos;
    public Vector3 endSclae;

    [SerializeField] float waitTillAction;
    [SerializeField] float fadeInSpeed;
    [SerializeField] float moveToLocationSpeed;
    [SerializeField] Ease logoEase;
    [SerializeField] Color resetColor;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnEnable()
    {
        spriteRenderer.DOFade(1, fadeInSpeed);
        StartCoroutine(GoToHomePostion());
    }

    private void OnDisable()
    {
        spriteRenderer.color = resetColor;
        transform.position = new Vector3(0,0,0);
        transform.localScale = new Vector3(2, 2, 0); 
    }

    private IEnumerator GoToHomePostion()
    {
        yield return new WaitForSeconds(waitTillAction);
        transform.DOMove(endPos, moveToLocationSpeed).SetEase(logoEase);
        transform.DOScale(endSclae, moveToLocationSpeed).SetEase(logoEase);
    }
}
