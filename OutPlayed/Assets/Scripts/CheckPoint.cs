using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject confettiEffect;
    public Transform checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject go = Instantiate(confettiEffect, checkpoint.position, checkpoint.rotation);
            Destroy(go, 2.5f);
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().enabled = true;
        }
    }  
}
