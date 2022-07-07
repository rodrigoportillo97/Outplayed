using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public SceneFader fader;

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        fader.FadeBack();
    }

    public void Retry() 
    {
        fader.FadeAgain();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

}
