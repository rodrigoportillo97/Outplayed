using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IngameUI : MonoBehaviour
{
    
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public SceneFader fader;
    public Text txtTimer;
    private float time;
    private bool timerfinish = false;
    public PlayerManagement loadcheckpoint;


    void Start()
    {
        txtTimer.text = "00:00";
        time = 0;
        
    }

    void Update()
    {
        if (!timerfinish)
        {
            TimeCalculate();
        }

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

    public void TimeCalculate()
    {
        time += Time.deltaTime;
        int min = (int)time / 60;
        int seg = (int)time % 60;
        txtTimer.text = min.ToString() + ":" + seg.ToString().PadLeft(2, '0');
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
    
    public void ReloadwhenStuck() 
    {
        loadcheckpoint.Dead();
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
