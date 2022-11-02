using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public Button continueGameButton;
    public TextMeshProUGUI textColor;

    public void PlayGame() 
    {
        PlayerPrefs.DeleteAll();
        fader.FadeTo();
    }

    public void Update()
    {
        KeyCheck();
    }

    public void KeyCheck() 
    {
        if (PlayerPrefs.HasKey($"Player_x"))
        {
            continueGameButton.interactable = true;
        }
        else
        {
            continueGameButton.interactable = false;
            textColor.color = new Color32(155, 155, 155, 255);
        }
    }

    public void ContinueGameWhenActive() 
    {
        fader.FadeTo();
    }

    public void QuitGame() 
    {
        Application.Quit();
    }


}
