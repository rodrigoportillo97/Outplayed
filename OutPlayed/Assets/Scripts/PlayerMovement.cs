using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public SceneFader fader;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public float restartDelay = 1f;
    public Vector3 respawnPoint;
    public Rigidbody2D rb;
    public Vector2 m_NewForce;

    void Start()
    {
        respawnPoint = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        m_NewForce = new Vector2(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("Run", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }
    }

    public void OnLanding() 
    {
        anim.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floorlimit")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }

        if (collision.tag == "Yellow")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.tag == "Blue")
        {
            
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
