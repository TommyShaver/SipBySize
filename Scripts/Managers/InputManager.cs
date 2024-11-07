using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool waitforspace;
    private bool cashRegisterSceneLoaded;
    private void Update()
    {
        if (Input.anyKey)
        {
            //This read only function for idle animaiton on bubbles.
            //Debug.Log("Any Key press check");
        }
        if(Input.GetMouseButtonDown(0))
        {
            DialogManager.IdialogManager.IncomingInfo();
            Debug.Log("[Input Manager] Left mouse was clicked");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.IGameManager.GamePaused();
            Debug.Log("[Input Manager] P Key has been pressed");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!cashRegisterSceneLoaded)
            {
                if (!waitforspace)
                {
                    StartCoroutine(SpaceBarWait());
                    BubblesAnimationController.Instace_BubblesAnimationController.BubblesBody(3);
                    BobaPump.IBobaPump.PumpAnimaiotn();
                    UITimedTriangle.ITimedTriangle.IncomingInfo();
                    Debug.Log("[InputManager] Space bar was clicked");
                    waitforspace = true;
                }
            }
        }
    }

    private IEnumerator SpaceBarWait()
    {
        yield return new WaitForSeconds(.5f);
        waitforspace = false;
    }
}
