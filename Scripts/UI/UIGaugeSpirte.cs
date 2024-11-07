using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGaugeSpirte : MonoBehaviour
{
    public static UIGaugeSpirte IUIGaugeSpirte { get; set; } //Make avablie.
    public Sprite[] sprites;
    private SpriteRenderer spirtesRenderer;

    private void Awake()
    {
        IUIGaugeSpirte = this;
        spirtesRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spirtesRenderer.sprite = sprites[0];   
    }

    public void SwitchSprites(int i)
    {
        spirtesRenderer.sprite = sprites[i];
    }
}
