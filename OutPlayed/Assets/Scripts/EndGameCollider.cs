using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{
    public GameObject endgameUI;
    public GameObject player;
    public AudioSource audioS;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioS.Stop();
            GetComponent<AudioSource>().Play();
            endgameUI.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
