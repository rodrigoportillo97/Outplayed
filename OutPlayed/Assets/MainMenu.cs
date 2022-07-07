using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;

    public void PlayGame() 
    {
        fader.FadeTo();
    }

    public void QuitGame() 
    {
        Application.Quit();

    }


}
