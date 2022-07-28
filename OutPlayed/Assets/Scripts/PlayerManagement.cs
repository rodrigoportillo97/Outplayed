using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    public Text deathCount;
    public Text deathCount2;
    private int deathcount = 0;
    private Vector2 respawnPoint;
    bool hasDetectedTrigger = false;

    private void Start()
    {
        respawnPoint = transform.position;
    }

    public void DeathIncreased()
    {
        deathcount++;
        deathCount.text = deathcount.ToString();
        deathCount2.text = deathcount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floorlimit" && hasDetectedTrigger == false)
        {
            transform.position = respawnPoint;
            DeathIncreased();
            Debug.Log($"OnTriggerEnter2D from {gameObject.name} collided with {collision.gameObject.name}");
        }
        else if (collision.tag == "CheckPoint" && hasDetectedTrigger == false)
        {
            respawnPoint = transform.position;
        }
        hasDetectedTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasDetectedTrigger = false;
    }
}
