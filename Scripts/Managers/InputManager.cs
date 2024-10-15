using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool waitforspace;
    private void Update()
    {
        if (Input.anyKey)
        {
            //This read only function for idle animaiton on bubbles.
            //Debug.Log("Any Key press check");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.IGameManager.GamePaused();
            Debug.Log("[Input Manager] P Key has been pressed");
        }
        if(Input.GetMouseButton(0))
        {
            //LeftMouse_Clicked?.Invoke();
            //Debug.Log("Input Manager: Left Mouse clicked");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!waitforspace)
            {
                StartCoroutine(SpaceBarWait());
                GameManager.IGameManager.SpaceBarHit();
                Debug.Log("[InputManager] Space bar was clicked");
                waitforspace = true;
            }
        }
    }

    private IEnumerator SpaceBarWait()
    {
        yield return new WaitForSeconds(.5f);
        waitforspace = false;
    }
}
