using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogManager : MonoBehaviour
{
    /* [IMPORTANT INFO!!!] Dialog box can only hold 200 Charaters!!! 
     * Please cehck here to make sure it will fit https://charactercounttool.com/
     */
    public static DialogManager IdialogManager { get; set; }

    public TextMeshProUGUI nameplate;
    public TextMeshProUGUI textBox;
    public GameObject advanceTextButton;
    public RectTransform dialogBoxGameObject;

    [SerializeField] private float textSpeed;

    private bool dialogAnimPlayed;
    private bool canAdvanceText;
    private int currentDialog;
    private int nextLineDialogArry;

    //All Charater Text ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private string[] charaterNames = { "Biscuit", "Bubbles", "Button", "Chilly", "Cinder", "Clover", "Joey", "Marlow", "Pubbles", "Stapmy" };

    private string[] bubblesDialog =
    {
        //Opening 0 - 10
        "Okay, I need to do good in getting tip money so I can save up and get that new controller. Then, I can finally beat “Almost Home”!",                                                   //0
        "The quicker and more accurate I make these drinks, the better tips I'll get!",                                                                                                         //1
        "But first, I need to make myself a coffee before customers show up.",                                                                                                                  //2
        "Let’s do this! First, I need to choose the correct drink. I can use the arrows to select which drink I want with the mouse.",                                                          //3
        "Choosing the right flavor is important! Customers tip less if they get their orders wrong or even if you don’t fill the cup correctly. So we have to be quick and accurate.",          //4
        "Nice coffee! See the meter on the right? Once it's in the green area, hit the spacebar quickly! That’s the perfect amount for the order. Let's try it.",                               //5
        "Perfect! Now let’s add some cream. I don’t want too much cream though, or else it will hurt my stomach.",                                                                              //6
        "Now for the boba. Select the boba just like the drinks and hit the spacebar at the right time and they will fly in. I want tapioca pearls today.",                                     //7
        "I must do the orders in proper order so I don't get confused. All the notes will show up on the left side, and money will be at the bottom right. 60 bucks won’t be too hard… Right?", //8
        "Ahhhh…so good. Oh! Here come the customers",                                                                                                                                           //9

        //Bubbles Respones 11-14
        "Hello, how can I help you?",           //10
        "Hi, what would you like today?",       //11
        "What would you like to order today?",  //12
        "How may I help you?",                  //13

        //Bubbles after making drinks 15-17
        "Here you go!",                         //14
        "Enjoy!",                               //15
        "Thank you for waiting."                //16
    };

    private string[] biscuitDialog =
    {
        //Order
        "Hello! Um, I would like…one coffee with regular cream and tapioca boba and um…. a Thai tea and pudding boba, please. Oh, and please take your time. No rush.",
        //Did it right
        "Oh, wow! This is perfect. Thank you!",
        //Did it wrong
        "Um…I don’t like this very much. I’m sorry....",
        //Took to much time
        "Oh, I…I actually don’t have time to wait anymore. I need to cancel my order. Sorry…"
    };

    private string[] buttonDialog =
    {
        //Order
        "Hi, can I please have 2 orders of the taro drinks? One with a lot of cream and popping boba and one with light cream, and pudding boba, please.",
        "I hate to ask but I'm in a bit of a rush. Can you make them fast?",
        //Did it right
        "Yes! This is exactly what I needed, thank you.",
        //Did it wrong
        "I wanted it fast but I also wanted it right.",
        //Took to much time
        "I'm gonna be late! I don’t have time for this.",
    };

    private string[] cinderDialog =
    {
         //Order
         "I need coffee with regular cream tapioca boba, one lychee with light cream and popping boba, and Thai tea with extra cream and matcha boba. I am not in a hurry.",
        //Did it right
        "So good! Thank you",
        //Did it wrong
        "Wow this is nowhere near what I wanted.",
        //Took to much time
        "You are taking way too much time!"
    };

    private string[] chillyDialog =
    {
         //Order
         "I have an order from work. It's kind of long. One Thai tea light cream with tapioca boba, one coffee regular cream with pudding boba, one taro no cream with crystal boba, ",
         "one green tea extra cream with matcha boba, one lychee tea no cream with lychee boba, and one butterfly pea light cream and popping boba.",
         "I need it to be done as fast as possible. We have a meeting soon.",
        //Did it right
        "Nice! Hopefully, soon they won't see me as just an intern.",
        //Did it wrong
        "Well, you tried your best and hey, it's not my money.",
        //Took to much time
        "UGH! I am gonna be late to my meeting!"
    };

    private string[] joeyDialog =
    {
         //Order
         "Hello! I have a pretty big order but I am in no rush. One Thai iced tea with pudding boba and extra cream, one coffee with light cream and tapioca boba, one taro regular cream with lychee boba,",
         "one green tea with regular cream and matcha boba, one with lychee regular cream and popping boba, and the last one is butterfly pea with extra cream and crystal boba.",
        //Did it right
        "Awesome, everyone will love these!",
        //Did it wrong
        "I gave you a lot of time and you still did it wrong?",
        //Took to much time
        "There is no way you took this long I'm outta here."
    };

    private string[] marlowDialog =
    {
         //Order
         "Yeah, hi. I need one butterfly pea tea with crystal boba and a Thai Tea with tapioca boba. I am also in a hurry.",
        //Did it right
        "Hmm…you really know how to make a good drink.",
        //Did it wrong
        "This is completely wrong. Just how do you expect me to drink this?",
        //Took to much time
        "I have more important things to do than wait for this!"
    };

    private string[] puddlesDialog =
    {
         //Order
         "My family would like one butterfly pea tea with matcha boba, one green tea with tapioca boba, and a lychee drink with popping boba all can have the same amount of regular cream. Please take your time.",
         "Actually, my kid is a little picky so can you make sure the lychee is perfect and with light cream?",
        //Did it right
        "Oh thank you! This is just what I ordered!",
        //Did it wrong
        "This is not what I ordered…",
        //Took to much time
        "Hey, we have to go. Please cancel our order."
    };

    private string[] stampyDialog =
    {
         //Order
         "Ok, I have a big order and I need it done fast! Two coffees with tapioca boba, one green tea with green tea boba, one taro with lychee boba, and one lychee with tapioca.",
         "The quicker the better. Each one has a smaller amount of cream for each drink.",
        //Did it right
        "Great gotta go, thank you!",
        //Did it wrong
        "UGH, this is horrible!",
        //Took to much time
        "This is taking too long. I have to go."
    };
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //Dialog box logic ---------------------------------------------------------
    //Set up ------------------------------------------------------------------
    private void Awake()
    {
        if (IdialogManager != null && IdialogManager != this)
        {
            Destroy(this);
        }
        else
        {
            IdialogManager = this;
        }
    }

    private void Start()
    {
        ClearDialog();
        CloseDialogBox();
    }

    //Logic -------------------------------------------------------------------
    private void OpenDialogBox()
    {
        dialogBoxGameObject.DOScale(Vector3.one, 0.1f);
        dialogAnimPlayed = true;
        
    }
    private void CloseDialogBox()
    {
        dialogBoxGameObject.DOScale(Vector3.zero, 0.1f);
        dialogAnimPlayed = false;
    }

    public void ClearDialog()
    {
        textBox.text = string.Empty;
    }

    public void SwitchNamePlate(int i)
    {
        nameplate.text = charaterNames[i];
    }

    public void ChangeTextBoxDialog(int correctArry, int dialog)
    {
        if(!dialogAnimPlayed)
        {
            OpenDialogBox();
        }
        ClearDialog();
        advanceTextButton.SetActive(false);
        switch (correctArry)
        {
            //Bubbles
            case 0:
                //turn off advance arrow
                SwitchNamePlate(1);
                StartCoroutine(TypeLine(bubblesDialog[dialog]));
                currentDialog = 1;
                break;
            //Biscuit
            case 1:
                SwitchNamePlate(0);
                StartCoroutine(TypeLine(biscuitDialog[dialog]));
                currentDialog = 2;
                break;
            //Button
            case 2:
                SwitchNamePlate(3);
                StartCoroutine(TypeLine(buttonDialog[dialog]));
                currentDialog = 3;
                break;
            //Cinder
            case 3:
                SwitchNamePlate(4);
                StartCoroutine(TypeLine(cinderDialog[dialog]));
                currentDialog = 4;
                break;
            //Chilly
            case 4:
                SwitchNamePlate(5);
                StartCoroutine(TypeLine(chillyDialog[dialog]));
                currentDialog = 5;
                break;
            //Joey
            case 5:
                SwitchNamePlate(6);
                StartCoroutine(TypeLine(joeyDialog[dialog]));
                currentDialog = 6;
                break;
            //Marlow
            case 6:
                SwitchNamePlate(7);
                StartCoroutine(TypeLine(marlowDialog[dialog]));
                currentDialog = 7;
                break;
            //Puddles
            case 7:
                SwitchNamePlate(8);
                StartCoroutine(TypeLine(puddlesDialog[dialog]));
                currentDialog = 8;
                break;
            //Stampy
            case 8:
                SwitchNamePlate(9);
                StartCoroutine(TypeLine(stampyDialog[dialog]));
                currentDialog = 9;
                break;
        }
    }

    private IEnumerator TypeLine(string s)
    {
        foreach (char c in s.ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        advanceTextButton.SetActive(true);
        canAdvanceText = true;
    }
     
    public void IncomingInfo()
    {
        if(canAdvanceText)
        {
            canAdvanceText = false;
            TextBoxUpdate();
        }
    }
    private int IncermentNumber()
    {
        nextLineDialogArry++;
        return nextLineDialogArry;
    }

    private void TextBoxUpdate()
    {
        switch(currentDialog)
        {
            case 0:
                ClearDialog();
                CloseDialogBox();
                break;
            case 1:
                //Bubbles opening 
                if(nextLineDialogArry < 2)
                {
                    ChangeTextBoxDialog(0, IncermentNumber());
                }
                else
                {
                    currentDialog = 0;
                    nextLineDialogArry = 0;
                    TextBoxUpdate();
                }
                break;
            case 2:

                break;
        }
    }
}
