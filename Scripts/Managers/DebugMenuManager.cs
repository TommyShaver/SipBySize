using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuManager : MonoBehaviour
{
    //Debug mode --------------------------------------------------------------
    [SerializeField] float slowDownTime;
    [SerializeField] int changeableNumber;
    [SerializeField] int whichCharater;
    [SerializeField] int whichTextBox;
    [SerializeField] float moneyScore;
    [SerializeField] float timerLenght;
    [SerializeField] float speedOfTrinagle;
    [SerializeField] int switchGuageSprites;
    [SerializeField] float fill;

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
        DialogManager.IdialogManager.ChangeTextBoxDialog(whichCharater, whichTextBox);
    }

    public void _UpdateScore()
    {
        UIMoneyScore.IUIMoneyScore.ScoreUpdate(moneyScore);
    }

    public void _TimerGo()
    {
        UITimer.IUITimer.IncomingInformation(timerLenght);
    }

    public void _SlidingInMoney()
    {
        UIMoneyScore.IUIMoneyScore.SlidingInAnim();
    }
    public void _SlidingOutMoney()
    {
        UIMoneyScore.IUIMoneyScore.SlidingOutAnim();
    }

    public void _SlidingInTimer()
    {
        UITimer.IUITimer.SlidingInAnim();
    }
    public void _SlidingOutTimer()
    {
        UITimer.IUITimer.SlidingOutAnim();
    }

    public void _ResetSlider()
    {
        UITimedTriangle.ITimedTriangle.ResetTriangle(speedOfTrinagle);
    }

    public void _UIGuage()
    {
        UIGaugeSpirte.IUIGaugeSpirte.SwitchSprites(switchGuageSprites);
    }

    public void _UIGuageMovementIn()
    {
        UIMeterGaugeMovement.IUIMeterGaugeMovement.MoveToInGamePos();
    }

    public void _UIGuageMovementOut()
    {
        UIMeterGaugeMovement.IUIMeterGaugeMovement.MoveOffScreen();
    }

    public void _BobaJarSet()
    {
        BubaTeaFill.IBubaTeaFill.SetMaxFill();
    }

    public void _BobaJarFill()
    {
        BubaTeaFill.IBubaTeaFill.SetFillAmount(fill);
    }

    public void _BoboaReset()
    {
        BubaTeaFill.IBubaTeaFill.ResetBoba();
    }

}
