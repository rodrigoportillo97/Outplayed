using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{

    public float x, y, z;
    public int deaths;
    public float _timer;

    public void SavePrefs()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        deaths = gameObject.GetComponent<PlayerManagement>().deathcount;

        _timer = FindObjectOfType<IngameUI>().time;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);

        PlayerPrefs.SetInt("death", deaths);

        PlayerPrefs.SetFloat("timer", _timer);
    }

    public void LoadPrefs()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        deaths = PlayerPrefs.GetInt("death");

        _timer = PlayerPrefs.GetFloat("timer");

        Vector3 LoadPosition = new Vector3(x, y, z);
        transform.position = LoadPosition;
    }
}
