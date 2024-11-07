using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaColorSwitch : MonoBehaviour
{
    public static BobaColorSwitch IBobaColorSwitch { get; set; }
    public Image image;

    private void Awake()
    {
        if (IBobaColorSwitch != null && IBobaColorSwitch != this)
        {
            Destroy(this);
        }
        else
        {
            IBobaColorSwitch = this;
        }
    }

    public void ChangeColor(int i)
    {
        //switch sprites
    }
}
