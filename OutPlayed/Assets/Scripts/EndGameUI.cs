using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public SceneFader fader;

    public void PlayAgain() 
    {
        Time.timeScale = 1;
        fader.FadeAgain();
        Debug.Log("Reloading...");
    }

    public void QuitGame() 
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
