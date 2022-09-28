using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public GameObject confettiEffect;
    public Transform checkpoint;
    public TMP_Text text;

    private void Start()
    {
        text.enabled = false;
    }

    public void ActivateCheckPoint() 
    {
        GameObject go = Instantiate(confettiEffect, checkpoint.position, checkpoint.rotation);
        Destroy(go, 2.5f);
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
        text.enabled = true;
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
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
        if (collision.tag == "Player")
        {
            isTrigger = false;
            Debug.Log($"OnTriggerExit2D from {gameObject.name} collided with {collision.gameObject.name}");
        }
    }*/
}
