using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager ISceneManager { get; set; }
    private bool openingSceneLoaded;
    

    //Set Up Function ------------------------------------------------------
    private void Awake()
    {
        if (ISceneManager != null && ISceneManager != this)
        {
            Destroy(this);
        }
        else
        {
            ISceneManager = this;
        }
    }
    private void Start()
    {
        openingSceneLoaded = true;    
    }

    //Drink Station Calls --------------------------------------------------
    private void DrinkStationFadeIn()
    {
        SwitchEnveroriments.IDrinkStation.OnFadeInRequest();
    }
    private void DrinkStationFadeOut()
    {
        SwitchEnveroriments.IDrinkStation.OnFadeOutRequest();
    }


    //Cash Reigters Calls ------------------------------------------------
    private void CashResigtersFadeIn()
    {
        CashRegisterSceneAnimation.ICashRegisterScene.OnFadeInRequest();
    }
    private void CashResigtersFadeOut()
    {
        CashRegisterSceneAnimation.ICashRegisterScene.OnFadeOutRequest();
    }

    //Logic to switch scenes ----------------------------------------------
    public void SwithcScenes()
    {
        if(openingSceneLoaded)
        {
            StartCoroutine(ToDrinkStation());
            openingSceneLoaded = false;
        }
        else
        {
            StartCoroutine(ToCashRegister());
            openingSceneLoaded = true;
        }
    }

    private IEnumerator ToDrinkStation()
    {
        CashResigtersFadeOut();
        yield return new WaitForSeconds(.3f);
        DrinkStationFadeIn();
    }

    private IEnumerator ToCashRegister()
    {
        DrinkStationFadeOut();
        yield return new WaitForSeconds(.3f);
        CashResigtersFadeIn();
    }
}
