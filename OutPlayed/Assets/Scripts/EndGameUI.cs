using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public SceneFader fader;
    public Text txtTimer2;
    private bool timerfinish = false;
    private float time;
    
    public void Start()
    {
        txtTimer2.text = "00:00";
        time = 0;
    }


    void Update()
    {
        if (!timerfinish)
        {
            TimeCalculate();
        }
    }

    public void TimeCalculate()
    {
        time += Time.deltaTime;
        int min = (int)time / 60;
        int seg = (int)time % 60;
        txtTimer2.text = min.ToString() + ":" + seg.ToString().PadLeft(2, '0');
    }

    public void PlayAgain() 
    {
        fader.FadeAgain();
        
    }

    public void QuitGame() 
    {
        Application.Quit();

    }
}
