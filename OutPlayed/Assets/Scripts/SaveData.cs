using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    
   

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Checkpoint Saved
    public void SetPosition(string key, Vector2 value)
    {
        PlayerPrefs.SetFloat($"{key}_x", value.x);
        PlayerPrefs.SetFloat($"{key}_y", value.y);
    }

    public Vector2 GetPosition(string key, Vector2 value)
    {
        Vector2 position = new Vector2();
        if (PlayerPrefs.HasKey($"{key}_x") && PlayerPrefs.HasKey($"{key}_y"))
        {
            position.x = PlayerPrefs.GetFloat($"{key}_x", value.x);
            position.y = PlayerPrefs.GetFloat($"{key}_y", value.y);
            return position;
        }
        else
        {
            return value;
        }
    }

    // Death Saved
    public void SetDeaths(string key, int value)
    {
        PlayerPrefs.SetInt($"{key}", value);
    }
    
    public int GetDeaths(string key, int value)
    {
        if (PlayerPrefs.HasKey($"{key}"))
        {
            return PlayerPrefs.GetInt($"{key}", value);
        }
        else
        {
            return value;
        }
    }

    // Timer Saved
    public void SetTimer(string key, float value) 
    {
        PlayerPrefs.SetFloat($"{key}", value);
    }

    public float GetTimer(string key, float value)
    {
        if (PlayerPrefs.HasKey($"{key}"))
        {
            return PlayerPrefs.GetFloat($"{key}", value);
        }
        else
        {
            return value;
        }
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
    public void DeleteKeysForAdmin()
    {
        if (PlayerPrefs.HasKey($"Player_x") && PlayerPrefs.HasKey($"Player_y") && PlayerPrefs.HasKey($"Death"))
        {
            PlayerPrefs.DeleteKey($"Player_x");
            PlayerPrefs.DeleteKey($"Player_y");
            PlayerPrefs.DeleteKey($"Death");

            Debug.Log("The key " + $"Death" + " exists and its been deleted");
            Debug.Log("The key " + $"Player_x" + " exists and its been deleted");
            Debug.Log("The key " + $"Player_y" + " exists and its been deleted");
        }
        else
        {
            Debug.Log("The key " + $"Player_x" + " does not exist");
            Debug.Log("The key " + $"Player_y" + " does not exist");
            Debug.Log("The key " + $"Death" + " does not exist");
        }

        if (PlayerPrefs.HasKey($"Timer"))
        {
            PlayerPrefs.DeleteKey($"Timer");
            Debug.Log("The key " + $"Timer" + " exists and its been deleted");
        }
        else
        {
            Debug.Log("The key " + $"Timer" + " does not exist");
        }
    }
} 
    /*public void SavePrefs()
    {
        x = transform.position.x;
        y = transform.position.y;

        _deaths = pmag.deathcount;

        //_min = timerUI.min;
        //_seg = timerUI.seg;
        _timer = timerUI.time;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        
        PlayerPrefs.SetInt("death", _deaths);

        PlayerPrefs.SetFloat("timer", _timer);
        PlayerPrefs.Save();
        //PlayerPrefs.SetInt("timer1", _min);
        //PlayerPrefs.SetInt("timer2", _seg);
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
        Debug.Log(currentTimer.text);

        //_min = PlayerPrefs.GetInt("timer1");
        //_seg = PlayerPrefs.GetInt("timer2");
        //currentTimer.text = _min.ToString() + ":" + _seg.ToString().PadLeft(2, '0');


    }*/

