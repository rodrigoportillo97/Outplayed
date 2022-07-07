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

    void Start()
    {
        respawnPoint = transform.position;
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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Floorlimit")
        {
            transform.position = respawnPoint;
        }
        else if (coll.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }

    }

}
