using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public GameObject confettiEffect;
    public Transform checkpoint;
    public bool isTrigger;
    public TMP_Text text;

    private void Start()
    {
        text.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isTrigger == false)
        {
            GameObject go = Instantiate(confettiEffect, checkpoint.position, checkpoint.rotation);
            Destroy(go, 2.5f);
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().enabled = true;
            GetComponent<Collider2D>().enabled = false;
            isTrigger = true;
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
    }
}
