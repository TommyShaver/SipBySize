using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BobaLowerReset : MonoBehaviour
{
    public static BobaLowerReset IBobaLowerReset;
    [SerializeField]private float startPos;
    [SerializeField]private float endPos;


    //Set up ------------------------------------------------------------------
    private void Awake()
    {
        if (IBobaLowerReset != null && IBobaLowerReset != this)
        {
            Destroy(this);
        }
        else
        {
            IBobaLowerReset = this;
        }
    }

    //Incoming Data ----------------------------------------------------------
    public void ResetAndClearBoba()
    {
        //using Tweening lowre
        BubaTeaFill.IBubaTeaFill.ResetBoba();
    }
}
