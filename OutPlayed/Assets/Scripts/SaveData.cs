using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public float x, y;
    public int _deaths;
    public float _timer;
    public Text amountDeaths;
    public Text currentTimer;
    public IngameUI timerUI;
    public PlayerManagement pmag;

    public void SavePrefs()
    {
        x = transform.position.x;
        y = transform.position.y;

        _deaths = pmag.deathcount;

        _timer = timerUI.time;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        
        PlayerPrefs.SetInt("death", _deaths);

        PlayerPrefs.SetFloat("timer", _timer);
    }

    public void LoadPrefs ()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");

        Vector2 LoadPosition = new Vector2(x, y);
        transform.position = LoadPosition;

        _deaths = PlayerPrefs.GetInt("death");
        amountDeaths.text = _deaths.ToString();

        _timer = PlayerPrefs.GetFloat("timer");
        currentTimer.text = _timer.ToString();
        
    }
}
