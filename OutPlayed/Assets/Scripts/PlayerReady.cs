using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour
{
    public GameObject ingameUI;
    public GameObject touchCanvas;
    public GameObject ingameText;


    public void Start()
    {
        if (PlayerPrefs.HasKey($"Player_x"))
        {
            touchCanvas.SetActive(true);
            gameObject.SetActive(false);
            ingameUI.SetActive(true);
            ingameText.SetActive(true);
        }
        else
        {
            touchCanvas.SetActive(false);
            gameObject.SetActive(true);
            ingameUI.SetActive(false);
            ingameText.SetActive(false);
        }
    }

    public void ReadyButton() 
    {
        ActivateUIElements();
        gameObject.SetActive(false);
    }

    public void ActivateUIElements() 
    {
        StartCoroutine(ActivarUIElementsCR());
    }

    IEnumerator ActivarUIElementsCR() 
    {
        yield return new WaitForSeconds(2f);
        touchCanvas.SetActive(true);
        ingameUI.SetActive(true);
        ingameText.SetActive(true);
    }

}
