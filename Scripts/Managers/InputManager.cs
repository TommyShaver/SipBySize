using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action LeftMouse_Clicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.IGameManager.GamePaused();
            Debug.Log("Input Manager: P Key has been pressed");
        }
        if(Input.GetMouseButton(0))
        {
            //LeftMouse_Clicked?.Invoke();
            Debug.Log("Input Manager: Left Mouse clicked");
        }
    }
}
