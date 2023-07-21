using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReady : MonoBehaviour
{
    public GameObject ingameUI;
    public GameObject touchCanvas;
    public GameObject ingameText;
    public Button rdyButton;
   


    public void Start()
    {
        if (PlayerPrefs.HasKey($"Player_x"))
        {
            touchCanvas.SetActive(true);
            ingameUI.SetActive(true);
            ingameText.SetActive(true);
            rdyButton.gameObject.SetActive(false);
        }
        else
        {
            touchCanvas.SetActive(false);
            ingameUI.SetActive(false);
            ingameText.SetActive(false);
            rdyButton.gameObject.SetActive(true);

        }
    }

    public void ReadyButton() 
    {
        ActivateUIElements();
        rdyButton.gameObject.SetActive(false);
    }

    public void ActivateUIElements() 
    {
        StartCoroutine(ActivarUIElementsCR());
    }

    IEnumerator ActivarUIElementsCR() 
    {
        yield return new WaitForSeconds(1.8f);
        touchCanvas.SetActive(true);
        ingameUI.SetActive(true);
        ingameText.SetActive(true);
    }

}
