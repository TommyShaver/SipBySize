using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I need state machine to check what state we are in. 

public class GameManager : MonoBehaviour
{
    public static GameManager IGameManager { get; set; }
    public static event Action OnFadeInOutUIElement;
    public static event Action OnPauseMenuElement;

    public GameObject[] cameras;
    public GameObject bubblesStatic;
    public GameObject dialogBox;
 
    private bool gameIsPaused;
    private bool canBePaused = true;

    //Starting Logic
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
        bubblesStatic.SetActive(false);
        dialogBox.SetActive(false);
    }
    

    //Pause Scene UI Scene ------------------------------------------------------
    public void GamePaused()
    {
        if(canBePaused)
        {
            if (!gameIsPaused)
            {
                gameIsPaused = true;
                Time.timeScale = 0;
                //Send Command to SFX
                //Send Command to Music
                // Add settings 
                OnPauseMenuElement?.Invoke();
            }
            else
            {
                gameIsPaused = false;
                Time.timeScale = 1f;
                //Send Command to SFX
                //Send Command to music
                // Close Settings
                OnPauseMenuElement?.Invoke();
            }
        } 
    }

    public void MainMenuSelected()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        //Send Command to SFX
        //Send Command to Music
        OnFadeInOutUIElement?.Invoke();
        OnPauseMenuElement?.Invoke();
        canBePaused = false;
        Debug.Log("[Game Manager] Main Menu Button selected");
    }

    //Which State we are in


    //Call methods ----------------------------------------------------------
    //These are in game events that happen over time.
    //This is the main controller of what happens be aware there is a statemachine so even if these are
    ///called here doesn't mean that are triggered here.
    public void OpeningOfGame()
    {
        cameras[0].SetActive(true);
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        StartCoroutine(OpeningCutScene(5));
        //Time event 1
    }

    //Switch to the gameplay Screen
    public void SwitchGameplayScenes()
    {
        SceneManager.ISceneManager.SwithcScenes();
        BubblesController.IbubblesController.BubblesJump();
    }


    //Switch to dialog Scene
    public void SwitchDialogScenes()
    {
        bubblesStatic.SetActive(true);
    }


    //Timed evetns Logic -----------------------------------------------------
    private IEnumerator OpeningCutScene(int timer)
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
                case 4:
                    //Dialog apperas
                    break;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        //Time event 1
    }

    //Debug mode --------------------------------------------------------------
    public void TimeSlow()
    {
        Time.timeScale = 0.1f;
    }
}
