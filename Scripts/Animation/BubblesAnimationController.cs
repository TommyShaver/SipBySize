using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesAnimationController : MonoBehaviour
{
    public static BubblesAnimationController Instace_BubblesAnimationController { get; set; }
    public Animator bubblesBody;
    public Animator bubblesFace;

    //Bubbles Body Animation
    private const string BUBBLES_IDLE = "Bubbles_Idle";
    private const string BUBBLES_WAVE = "Bubbles_Wave";
    private const string BUBBLES_PUMP = "Bubbles_Pump";
    private const string BUBBLES_EXCITED = "Bubbles_Excited";
    private const string BUBBLES_SHOCKED = "Bubbles_Shocked";

    //Bubbles Face Animation
    private const string BUBBLES_FACE_IDLE = "Bubbles_Face_Idle";
    private const string BUBBLES_FACE_SMILE = "Bubbles_Face_Smile";
    private const string BUBBLES_FACE_BLINKING = "Bubbles_Face_Blinking";
    private const string BUBBLES_FACE_TALKINGANIM = "Bubbles_Face_Talkinganim";
    private const string BUBBLES_FACE_CRY = "Bubbles_Face_Cry";
    private const string BUBBLES_FACE_EXICTED = "Bubbles_Face_Exicted";
    private const string BUBBLES_FACE_YAWN = "Bubbles_Face_Yawn";

    private int currentAnimationBody;
    private int currentAnimationFace;
    private string nameOfAnimationBody;
    private string nameOfAnimationFace;

    private void Awake()
    {
        if (Instace_BubblesAnimationController != null && Instace_BubblesAnimationController != this)
        {
            Destroy(this);
        }
        else
        {
            Instace_BubblesAnimationController = this;
        }
    }
    private void Start()
    {
        bubblesBody.Play(BUBBLES_IDLE);
        bubblesFace.Play(BUBBLES_FACE_IDLE);
    }

    //Bubbles body -------------------------------------------------------------------
    //Set animation not related to in game events.
    public void BubblesBody(int animation)
    {
        //I am sure there a better way to write this but seemed good at the time. -_-
        if(currentAnimationBody != animation)
        {
            switch (animation)
            {
                case 1:
                    bubblesBody.Play(BUBBLES_IDLE);
                    currentAnimationBody = animation;
                    nameOfAnimationBody = BUBBLES_IDLE;
                    break;
                case 2:
                    bubblesBody.Play(BUBBLES_WAVE);
                    currentAnimationBody = animation;
                    nameOfAnimationBody = BUBBLES_WAVE;
                    break;
                case 3:
                    bubblesBody.Play(BUBBLES_PUMP);
                    currentAnimationBody = animation;
                    nameOfAnimationBody = BUBBLES_PUMP;
                    break;
                case 4:
                    bubblesBody.Play(BUBBLES_EXCITED);
                    currentAnimationBody = animation;
                    nameOfAnimationBody = BUBBLES_EXCITED;
                    break;
                case 5:
                    bubblesBody.Play(BUBBLES_SHOCKED);
                    currentAnimationBody = animation;
                    nameOfAnimationBody = BUBBLES_SHOCKED;
                    break;
            }
            Debug.Log("Bubbles Animation Controller: <color=Yellow>Bubbles body animation played</color> " + nameOfAnimationBody);
        }
    }

    //Bubbles face ----------------------------------------------------------------------
    //These are set animation 
    public void BubblesFace(int faceAnimation)
    {
        if (currentAnimationFace != faceAnimation)
        {
            switch (faceAnimation)
            {
                case 1:
                    bubblesFace.Play(BUBBLES_FACE_BLINKING);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_BLINKING;
                    break;
                case 2:
                    bubblesFace.Play(BUBBLES_FACE_CRY);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_CRY;
                    break;
                case 3:
                    bubblesFace.Play(BUBBLES_FACE_SMILE);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_SMILE;
                    break;
                case 4:
                    bubblesFace.Play(BUBBLES_FACE_TALKINGANIM);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_TALKINGANIM;
                    break;
                case 5:
                    bubblesFace.Play(BUBBLES_FACE_YAWN);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_YAWN;
                    break;
                case 6:
                    bubblesFace.Play(BUBBLES_FACE_EXICTED);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_EXICTED;
                    break;
                case 7:
                    bubblesFace.Play(BUBBLES_FACE_IDLE);
                    currentAnimationFace = faceAnimation;
                    nameOfAnimationFace = BUBBLES_FACE_IDLE;
                    break;
            }
            Debug.Log("Bubbles Animation Controller: <color=Green>Bubbles body animation played</color> " + nameOfAnimationFace);
        }
    }
}
