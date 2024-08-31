using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubaTeaFill : MonoBehaviour
{
    public Slider slider;
    public Gradient[] gradient;
    public Image fillImage;
    private float currentFillAmount;

    public void SetMaxFill()
    {
        float startOfRoundFill = 0;
        float maxFileAmount = 100f;
        slider.maxValue = maxFileAmount;
        slider.value = startOfRoundFill;
        fillImage.color = gradient[3].Evaluate(0f);
    }

    public void SetFillAmount(float fillAmount)
    {
        currentFillAmount += fillAmount;
        slider.value = currentFillAmount;
        fillImage.color = gradient[3].Evaluate(slider.normalizedValue);
        Debug.Log("Boba Fill: Went up by 1.");
    }
}
