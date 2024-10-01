using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaPump : MonoBehaviour
{
    public static BobaPump IBobaPump { get; set; }
    public GameObject pumpFilling;
    public GameObject pumpPour;
    public GameObject selectorArrows;
    public SpriteRenderer[] colorsOfTeaRender;
    public Color[] colorsOfTea;

    public SpriteRenderer pumpAnimation;
    private int currentColor = 0;

    private void Awake()
    {
        if (IBobaPump != null && IBobaPump != this)
        {
            Destroy(this);
        }
        else
        {
            IBobaPump = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ColoringRendersLogic(0);
    }


    //Aniamtion void

    //Color selector Void

    public void TestMessage(GameObject whichArrow)
    {
        if (whichArrow.tag == "LeftArrow")
        {
            ColoringRendersLogic(-1);
            Debug.Log(whichArrow);
        }
        else
        {
            ColoringRendersLogic(1);
            Debug.Log(whichArrow);
        }
    }

    private void ColoringRendersLogic(int colorIndex)
    {
        currentColor += colorIndex;
        if (currentColor == 7)
        {
            currentColor = 0;
        }
        if(currentColor == -1)
        {
            currentColor = 6;
        }
        for(int i = 0; i < colorsOfTeaRender.Length; i++)
        {
            colorsOfTeaRender[i].color = colorsOfTea[currentColor];
        }

    }
}
