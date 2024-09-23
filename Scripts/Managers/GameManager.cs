using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//I need state machine to check what state we are in. 

public class GameManager : MonoBehaviour
{
    public static GameManager IGameManager { get; set; } //Make avablie.
    public static event Action OnPauseMenuElement;       //This delegat call the pause menu anitamtion  -> (PausedGameUIEelment [line 26]) (UITextTransofrmLoop [line 46])

    public GameObject[] cameras;                         //A list of camera in game to change for different scenes
    public GameObject bubblesStatic;                     //This is a simple spirte place holder while Bubbles is in dialog mode
    public GameObject dialogOverlay;                     //Black overlay to sperarte the layers
    public GameObject otherCharaters;                    //The Other Charaters
    public GameObject dialogBox;                         //Draw Dialog Box
 
    private bool gameIsPaused;                           //Check to see if we are paused.
    private bool canBePaused;                            //Are we in a cut scene?
    private bool cashReisgterSceneLoaded;                //Check to see what scene is loaded drink staion or cash register.
    private bool dialogSceneLoaded;                      //Check to see what scene is loaded

    public string[] madIhaveToDoItThisWay;

    //Starting Logic
    //I just want to get a everything set up no need to do this before game load not a big enough game.
    private void Awake()
    {
        if (IGameManager != null && IGameManager != this)
        {
            Destroy(this);
        }
        else
        {
            IGameManager = this;
        }
    }

    //When The Game Loads I want it to wait a second after the unity logo pops up so I have time to load everything in the background and get everything in postion.
    //Get everything loaded
    //MAIN SETUP FUNCTION
    private void Start()
    {
        dialogSceneLoaded = true;
        cameras[0].SetActive(true);
        cameras[1].SetActive(false);
        cameras[2].SetActive(false);
        bubblesStatic.SetActive(false);
        canBePaused = true;
        cashReisgterSceneLoaded = true;
        dialogSceneLoaded = true;
        SwitchDialogScenes();
        //Load Music
        //Load SFX
        StartCoroutine(Game_Loading());
    }

    //Pause Scene UI Scene ------------------------------------------------------
    public void GamePaused()
    {
        //This command is being called from InputManager [line 15]
        if(canBePaused)
        {
            if (!gameIsPaused)
            {
                gameIsPaused = true;
                Time.timeScale = 0;
                //Send Command to SFX
                //Send Command to Music
                OnPauseMenuElement?.Invoke();
                Debug.Log("[GameManager] Game was Paused");
            }
            else
            {
                gameIsPaused = false;
                Time.timeScale = 1f;
                //Send Command to SFX
                //Send Command to music
                OnPauseMenuElement?.Invoke();
                Debug.Log("[GameManager] Game was un-Paused");
            }
        }
    }

    //Call methods ----------------------------------------------------------
    public void OpeningOfGame()
    {
        //This get called from TitleScreenCutScene [Line 46]
        StartCoroutine(CutSceneAfterOpening(6));
    }

    //Switch to the gameplay Screen
    public void SwithcBetweenCashAndDrinkStation()
    {
        if (cashReisgterSceneLoaded)
        {
            StartCoroutine(ToDrinkStation());
            cashReisgterSceneLoaded = false;
            cameras[2].SetActive(true);
            cameras[1].SetActive(false);
        }
        else
        {
            StartCoroutine(ToCashRegister());
            cashReisgterSceneLoaded = true;
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
        }
        BubblesController.IbubblesController.BubblesJump(); //Bubles Aniamtion between each is set up
        Debug.Log("[GameManager] Switch Between cash and drink called");
    }

    //Switch to dialog Scene
    public void SwitchDialogScenes()
    {
        if(!dialogSceneLoaded)
        {
            bubblesStatic.SetActive(true);
            otherCharaters.SetActive(true);
            dialogOverlay.SetActive(true);
            dialogBox.SetActive(true);
            dialogSceneLoaded = true;
            BubblesController.IbubblesController.BubblesDialogPostion(true);
        }
        else
        {
            bubblesStatic.SetActive(false);
            otherCharaters.SetActive(false);
            dialogOverlay.SetActive(false);
            dialogBox.SetActive(false);
            dialogSceneLoaded = false;
            BubblesController.IbubblesController.BubblesDialogPostion(false);
        }
        Debug.Log("[GameManager] Loaded Dialog mode");
    }

    //Timed evetns Logic -----------------------------------------------------
    private IEnumerator Game_Loading()
    {
        yield return new WaitForSeconds(.5f);
        //TitleScreenCutScene.IOpeningCutScene.GameLoaded();
        //Play Music
        //Play SFX
    }

    private IEnumerator CutSceneAfterOpening(int timer)
    {
        int i = 0;
        while(i < timer)
        {
            switch (i)
            {
                case 1:
                    //Play door opening chime sound effecs
                    cameras[0].SetActive(false);
                    cameras[1].SetActive(true);
                    break;
                case 2:
                    BubblesAnimationController.Instace_BubblesAnimationController.BubblesBody(2);
                    break;
                case 5:
                    SwitchDialogScenes();
                    canBePaused = true;
                    break;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator ToDrinkStation()
    {
        CashRegisterSceneAnimation.ICashRegisterScene.OnFadeOutRequest();
        yield return new WaitForSeconds(.3f);
        SwitchEnveroriments.IDrinkStation.OnFadeInRequest();
    }

    private IEnumerator ToCashRegister()
    {
        SwitchEnveroriments.IDrinkStation.OnFadeOutRequest();
        yield return new WaitForSeconds(.3f);
        CashRegisterSceneAnimation.ICashRegisterScene.OnFadeInRequest();
    }


    //Debug mode --------------------------------------------------------------
    //Slow down to watch animation.
    public void _TimeSlow()
    {
        Time.timeScale = 0.1f;
    }

    //Load the title screen animation.
    public void _OnGameLoad()
    {
        TitleScreenCutScene.IOpeningCutScene.GameLoaded();
    }

    //Load Between different Scenes
    public void _SceneSwitchCheck()
    {
        SwithcBetweenCashAndDrinkStation();
    }

    public void _SceneDialogCheck()
    {
        SwitchDialogScenes();
    }

    //Reset Scene
    public void _SceneReset()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void _TestAnimation()
    {
        OtherCharaterAnimationController.Instace_OtherCharaterAnimationController.OtherCharaterBodyLogic(OtherCharaterAnimationController.CharaterBodySprite.button);
    }
    public void _TestFaceAnim()
    {
        OtherCharaterAnimationController.Instace_OtherCharaterAnimationController.OtherCharaterFace(OtherCharaterAnimationController.CharaterBodySprite.button, OtherCharaterAnimationController.FaceAnim.happy);
    }
}
