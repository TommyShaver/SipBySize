using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubaTeaFill : MonoBehaviour
{
    public static BubaTeaFill IBubaTeaFill { get; set; }
    public Slider slider;
    public Gradient[] gradient;
    public Image fillImage;
    private float currentFillAmount;
    private bool fillStart;

    private void Awake()
    {
        if (IBubaTeaFill != null && IBubaTeaFill != this)
        {
            Destroy(this);
        }
        else
        {
            IBubaTeaFill = this;
        }
    }

    //Fill Logic --------------------------------------------------------------
    public void SetMaxFill()
    {
        float startOfRoundFill = 0;
        float maxFileAmount = 100f;
        slider.maxValue = maxFileAmount;
        slider.value = startOfRoundFill;
    }

    public void SetFillAmount(float fillAmount)
    {
        fillStart = true;
        StartCoroutine(BobaFillAnim(fillAmount));
        Debug.Log("We Clicked here");
    }

    public void ResetBoba()
    {
        currentFillAmount = 0;
        slider.value = currentFillAmount;
    }

    private IEnumerator BobaFillAnim(float fillAmount)
    {
        while(fillStart)
        {
            if(currentFillAmount <= fillAmount)
            {
                currentFillAmount++;
                Debug.Log("Current Fill Amount: " + currentFillAmount + " " + fillAmount);
                slider.value++;
            }
            else
            {
                fillStart = false;
            }
            yield return new WaitForSeconds(.01f);

        }
    }
}
