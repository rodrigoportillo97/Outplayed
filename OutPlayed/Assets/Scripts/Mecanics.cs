using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mecanics : MonoBehaviour
{
    public PlayerMovement pmov;
    public Vector2 m_NewForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
   
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public void DisableSprite() 
    {
        sr.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Yellow")
        {
            sr.enabled = false;
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
            sr.enabled = true;
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

