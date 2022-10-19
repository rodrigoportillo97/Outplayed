using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{

    public float x, y;
    public int deaths;
    public float _timer;
    public Text amountDeaths;
    public PlayerManagement pmag;

    public void SavePrefs()
    {
        x = transform.position.x;
        y = transform.position.y;

        deaths = pmag.deathcount;

        //_timer = FindObjectOfType<IngameUI>().time;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        
        PlayerPrefs.SetInt("death", deaths);

        //PlayerPrefs.SetFloat("timer", _timer);
    }

    public void LoadPrefs ()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");

        Vector2 LoadPosition = new Vector2(x, y);
        transform.position = LoadPosition;

        deaths = PlayerPrefs.GetInt("death", 0);
        amountDeaths.text = deaths.ToString();
        

        //_timer = PlayerPrefs.GetFloat("timer");

    }
}
