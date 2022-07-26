using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mecanics : MonoBehaviour
{
    public Vector2 respawnPoint;
    public PlayerMovement pmov;
    public Vector2 m_NewForce;
    public Rigidbody2D rb;
    public Text deathCount;
    public Text deathCount2;
    private int deathcount = 0;
    public GameObject confettiEffect;
    public AudioClip clip;

    private void Start()
    {
        respawnPoint = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void DeathIncreased() 
    {
        deathcount++;
        deathCount.text = deathcount.ToString();
        deathCount2.text = deathcount.ToString();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floorlimit")
        {
            transform.position = respawnPoint;
            DeathIncreased();
            Debug.Log($"OnTriggerEnter2D from {gameObject.name} collided with {collision.name}");
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
            GameObject go = Instantiate(confettiEffect);
            GetComponent<AudioSource>().PlayOneShot(clip);
            Destroy(go, 2.5f);
            
        }

        if (collision.tag == "Yellow")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.tag == "Blue")
        {
            pmov.normal_Mov = false;
            pmov.blue_Mov = true;
        }

        if (collision.tag == "BlueYellow")
        {
            pmov.normal_Mov = false;
            pmov.blue_Mov = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Yellow")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (collision.tag == "Blue")
        {
            pmov.normal_Mov = true;
            pmov.blue_Mov = false;
        }

        if (collision.tag == "BlueYellow")
        {
            pmov.normal_Mov = true;
            pmov.blue_Mov = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Red")
        {
            m_NewForce = new Vector2(0f, 0.4f);
            rb.AddForce(m_NewForce, ForceMode2D.Impulse);
        }

        if (coll.tag == "RedUP")
        {
            m_NewForce = new Vector2(0f, 0.5f);
            rb.AddForce(m_NewForce, ForceMode2D.Impulse);
        }

    }
}

