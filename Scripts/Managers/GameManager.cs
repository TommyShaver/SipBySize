using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager IGameManager { get; set; }
    public static event Action OnFadeInOutUIElement;
    public static event Action OnPauseMenuElement;

    public GameObject[] cameras;

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
    }
    

    //Pause Scene-----------------------------------------------------------
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

    //Go Back to make screen ----------------------------------------------
    public void MainMenuSelected()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        //Send Command to SFX
        //Send Command to Music
        OnFadeInOutUIElement?.Invoke();
        OnPauseMenuElement?.Invoke();
        canBePaused = false;
        Debug.Log("Game Manager: Main Menu Button selected");
    }

    //Which State we are in


    //Call methods 
    public void OpeningOfGame()
    {
        cameras[0].SetActive(true);
        //...Turn this back on in unity editor
        OnFadeInOutUIElement?.Invoke();
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        StartCoroutine(OpeningCutScene(5));
    }

    public void SceneSwitch()
    {
        StartCoroutine(GameModeSwitchTimer());
    }

    //Timed evetns Logic
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
    }

    private IEnumerator GameModeSwitchTimer()
    {
        //OutBoundEvent1?.Invoke();
        yield return new WaitForSeconds(1);
    }

}
