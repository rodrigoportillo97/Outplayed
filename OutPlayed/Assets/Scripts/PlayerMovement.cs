using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public SceneFader fader;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public float restartDelay = 1f;
    public bool normal_Mov = true;
    public bool blue_Mov = false;

    // Update is called once per frame
    void Update()
    {
        if (normal_Mov == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            anim.SetFloat("Run", Mathf.Abs(horizontalMove));
        }

        if (blue_Mov == true)
        {
            BlueMov();
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);

        }
    }

    public void BlueMov()
    {
        StartCoroutine(BlueMovCR());
    }

    IEnumerator BlueMovCR()
    {
        yield return new WaitForSeconds(0.1f);
        horizontalMove = Input.GetAxisRaw("Horizontal-1") * runSpeed;
        anim.SetFloat("Run", Mathf.Abs(horizontalMove));
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

} 
