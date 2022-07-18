using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{
    public GameObject endgameUI;
    public GameObject player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            endgameUI.SetActive(true);
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
