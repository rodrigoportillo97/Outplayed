using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public SceneFader fader;
  
    public void PlayAgain() 
    {
        fader.FadeAgain();
        
    }

    public void QuitGame() 
    {
        Application.Quit();

    }
}
