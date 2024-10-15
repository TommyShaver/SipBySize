using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCutScene : MonoBehaviour
{
    public static TitleScreenCutScene IOpeningCutScene { get; set; }
    public GameObject logoObject;
    public GameObject titleScreenFont;
    public GameObject backgroundObject;

    public static event Action OnTitleFontFadeUp;

    private void Awake()
    {
        if (IOpeningCutScene != null && IOpeningCutScene != this)
        {
            Destroy(this);
        }
        else
        {
            IOpeningCutScene = this;
        }
    }

    private void Start()
    {
        GameLoaded();
    }

    // Start is called before the first frame update
    public void GameLoaded()
    {
        logoObject.SetActive(true);
        StartCoroutine(OnGameLoad());
    }

    private IEnumerator OnGameLoad()
    {
        yield return new WaitForSeconds(1.5f);
        IntroAnimation.IIntroAnimation.LoadAniamtion();
        yield return new WaitForSeconds(2);
        backgroundObject.SetActive(false);
        titleScreenFont.SetActive(true);
        yield return new WaitForSeconds(2);
        IntroAnimation.IIntroAnimation.UnloadAnimation();
        logoObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        GameManager.IGameManager.OpeningOfGame();
        yield return new WaitForSeconds(.5f);
        OnTitleFontFadeUp?.Invoke();
        yield return new WaitForSeconds(1f);
        titleScreenFont.SetActive(false);
        
    }
}
