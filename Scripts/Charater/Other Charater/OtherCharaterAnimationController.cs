using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class OtherCharaterAnimationController : MonoBehaviour
{
    public static OtherCharaterAnimationController Instace_OtherCharaterAnimationController;
    public Animator Anim_otherCharaterBody;
    public Animator Anim_otherCharaterFace;
    public SpriteRenderer spriteRendererBody;
    public SpriteRenderer spriteRendererFace;

    //Load in all strings. (Strings me no likie)
    private readonly string[] otherCharatersBody = { "Biscuit_Body", "Button_Body", "Chilly_Body", "Cinder_Body", "Joey_Body", "Marlow_Body", "Puddles_Body", "Stampy_Body" };
    private readonly string[] biscuitFace = { "Biscuit_Idle", "Biscuit_Angry", "Biscuit_Blink", "Biscuit_Sad", "Biscuit_Happy", "Biscuit_Talk" };
    private readonly string[] buttonFace = { "Button_Idle", "Button_Angry", "Button_Blink", "Button_Sad", "Button_Happy", "Button_Talk" };
    private readonly string[] chillyFace = { "Chilly_Idle", "Chilly_Angry", "Chilly_Blink", "Chilly_Sad", "Chilly_Happy", "Chilly_Talk" };
    private readonly string[] cinderFace = { "Cinder_Idle", "Cinder_Angry", "Cinder_Blink", "Cinder_Sad", "Cinder_Happy", "Cinder_Talk" };
    private readonly string[] joeyFace = { "Joey_Idle", "Joey_Angry", "Joey_Blink", "Joey_Sad", "Joey_Happy", "Joey_Talk" };
    private readonly string[] marlowFace = { "Marlow_Idle", "Marlow_Angry", "Marlow_Blink", "Marlow_Sad", "Marlow_Happy", "Marlow_Talk" };
    private readonly string[] puddlesFace = { "Puddles_Idle", "Puddles_Angry", "Puddles_Blink", "Puddles_Sad", "Puddles_Happy", "Puddles_Talk" };
    private readonly string[] stampyFace = { "Stampy_Idle", "Stampy_Angry", "Stampy_Blink", "Stampy_Sad", "Stampy_Happy", "Stampy_Talk" };

    private int currentAnimationBody;
    private int currentAnimaitonFace;

    //All body types
    public enum CharaterBodySprite
    {
        biscuit,
        button,
        chilly,
        cinder,
        joey,
        marlow,
        puddles,
        stampy
    }
    //All face animation
    public enum FaceAnim
    {
        idle,
        angry,
        blink,
        sad,
        happy,
        talk
    }

    //Setup ------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        if (Instace_OtherCharaterAnimationController != null && Instace_OtherCharaterAnimationController != this)
        {
            Destroy(this);
        }
        else
        {
            Instace_OtherCharaterAnimationController = this;
        }
    }

    private void Start()
    {
        Anim_otherCharaterBody.Play(otherCharatersBody[(int)CharaterBodySprite.biscuit]);
        Anim_otherCharaterFace.Play(biscuitFace[(int)FaceAnim.idle]);
    }

    //Body Logic--------------------------------------------------------------------------------------------------------
    public void OtherCharaterBodyLogic(CharaterBodySprite charater)
    {
        if (currentAnimationBody == (int)charater)
        {
            return;
        }
        Anim_otherCharaterBody.Play(otherCharatersBody[(int)charater]);
        
        Debug.Log("[OtherCharaterAnimatonController] Body selected: " + charater);
    }
    public void OtherCharaterFace(CharaterBodySprite charaterList, FaceAnim faceAnim)
    {
        if (currentAnimationBody == (int)faceAnim)
        {
            return;
        }
        switch (charaterList)
        {
            case CharaterBodySprite.biscuit:
                Anim_otherCharaterFace.Play(biscuitFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.button:
                Anim_otherCharaterFace.Play(buttonFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.chilly:
                Anim_otherCharaterFace.Play(chillyFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.cinder:
                Anim_otherCharaterFace.Play(cinderFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.joey:
                Anim_otherCharaterFace.Play(joeyFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.marlow:
                Anim_otherCharaterFace.Play(marlowFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.puddles:
                Anim_otherCharaterFace.Play(puddlesFace[(int)faceAnim]);
                break;
            case CharaterBodySprite.stampy:
                Anim_otherCharaterFace.Play(stampyFace[(int)faceAnim]);
                break;

        }
        Debug.Log("[OtherCharaterAnimatonController] Face selected: " + charaterList + " " + faceAnim);
    }
}
