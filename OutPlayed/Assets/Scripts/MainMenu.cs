using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public Button continueGameButton;

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
            continueGameButton.IsInteractable();
        }
        else
        {
            
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
