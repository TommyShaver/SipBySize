using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    /* [IMPORTANT INFO!!!] Dialog box can only hold 154 Charaters!!! 
     * Please cehck here to make sure it will fit https://charactercounttool.com/
     */

    public TextMeshProUGUI nameplate;
    public TextMeshProUGUI textBox;
    public GameObject advanceTextButton;

    private string[] charaterNames = { "Biscuit", "Bubbles", "Button", "Chilly", "Cinder", "Clover", "Joey", "Marlow", "Pubbles", "Stapmy" };

}
