using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    public int spawnindex;
    public GameObject prefabsToSpwan;
    public Transform prefabTrasform;
    public Color[] spawnColors;

    public static event Action<int> OnSpawnSendID;
    public static event Action<int> OnCleanupAnimation;

    [SerializeField] float nextAnimation;
    private bool colorSwitch;

    //Public calls to loand and unload ---------------------------------------
    public void LoadAniamtion()
    {
       StartCoroutine(AnimationTimer());
    }

    public void UnloadAnimation()
    {
        StartCoroutine(AnimationCleanUp());
    }

    //Switch colors on spawn -------------------------------------------------
    private void SetColor(GameObject prefabColor, Color color)
    {
        SpriteRenderer spriteRenderer = prefabColor.GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }

        //You should do this code on the gameobject itself not point of doing it here.
    }

    //Timers for in game events -----------------------------------------------
    private IEnumerator AnimationTimer()
    {
        Vector3 spawnNextTo = prefabTrasform.position;      //Grabs prefab postion
        Vector3 prefabScale = prefabTrasform.localScale;    //This grabs how big the thing is.
        for (int i = 0; i < spawnindex; i++)
        {
            spawnNextTo = new Vector3(spawnNextTo.x + prefabScale.x, prefabTrasform.position.y, 0); //This line first since there is already a gameobject to referance
            if (!colorSwitch)
            {
                Instantiate(prefabsToSpwan, spawnNextTo, prefabTrasform.rotation);
                SetColor(prefabsToSpwan, spawnColors[0]);
                colorSwitch = true;
            }
            else
            {
                Instantiate(prefabsToSpwan, spawnNextTo, prefabTrasform.rotation);
                SetColor(prefabsToSpwan, spawnColors[1]);
                colorSwitch = false;
            }
            OnSpawnSendID?.Invoke(i); // This gives spawned objects id tags so i can control from here.
            yield return new WaitForSeconds(nextAnimation);
        }
        Debug.Log("[IntorAnimation] Spawned animation compelet");
    }

    private IEnumerator AnimationCleanUp()
    {
        for (int i = spawnindex; i >= 0; i--)
        {
            OnCleanupAnimation?.Invoke(i); //Send Command to game object to run its out aniamtion. 
            yield return new WaitForSeconds(nextAnimation);
        }
        Debug.Log("[IntorAnimation] Clean Up animation compelet");
    }
}

