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
    public Saturation sat;
    public AudioSource levelSound;
   

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
        StartCoroutine(ChangeSaturationOverTime(2.5f, -100f, 0f));
        ActivateUIElements();
        rdyButton.gameObject.SetActive(false);
    }

    IEnumerator ChangeSaturationOverTime(float duration, float startValue, float targetValue)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentSaturation = Mathf.Lerp(startValue, targetValue, t);
            sat.colorAdjustments.saturation.value = currentSaturation;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sat.colorAdjustments.saturation.value = targetValue; 
    }

    public void ActivateUIElements() 
    {
        StartCoroutine(ActivarUIElementsCR());
    }

    IEnumerator ActivarUIElementsCR() 
    {
        yield return new WaitForSeconds(2.2f);
        levelSound.Play();
        touchCanvas.SetActive(true);
        ingameUI.SetActive(true);
        ingameText.SetActive(true);

    }

}
