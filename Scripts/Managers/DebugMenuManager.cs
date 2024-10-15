using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuManager : MonoBehaviour
{
    //Debug mode --------------------------------------------------------------
    [SerializeField] float slowDownTime;
    [SerializeField] int changeableNumber;

    //Slow down to watch animation.
    public void _TimeSlow()
    {
        Time.timeScale = slowDownTime;
    }

    //Load the title screen animation.
    public void _OnGameLoad()
    {
        TitleScreenCutScene.IOpeningCutScene.GameLoaded();
    }

    //Load Between different Scenes
    public void _SceneSwitchCheck()
    {
        GameManager.IGameManager.SwithcBetweenCashAndDrinkStation();
    }

    public void _SceneDialogCheck()
    {
        GameManager.IGameManager.SwitchDialogScenes();
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

    public void _DialogNameplateTest()
    {
        DialogManager.IdialogManager.SwitchNamePlate(changeableNumber);
    }
    public void _DialogTextAnim()
    {
        DialogManager.IdialogManager.ChangeTextBoxDialog(0, 0);
    }
}
