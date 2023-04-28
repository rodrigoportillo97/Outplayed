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
    public bool moveLeft = false;
    public bool moveRight = false;
    public bool blueMov = false;
    

    // Update is called once per frame
    void Update()
    {
        if (!blueMov)
        {
            if (moveLeft)
            {
                horizontalMove = -runSpeed;
                anim.SetBool("Run", true);
            }
            else if (moveRight)
            {
                horizontalMove = runSpeed;
                anim.SetBool("Run", true);
            }
            else
            {
                horizontalMove = 0;
                anim.SetBool("Run", false);
            }
        }
        else if (blueMov)
        {
            StartCoroutine(DelayDirectionChange());
        }

        if (jump == true)
        {
            anim.SetBool("isJumping", true);
        }

    }

    IEnumerator DelayDirectionChange () 
    {
        yield return new WaitForSeconds(0.1f);
        if (moveLeft)
        {
            horizontalMove = runSpeed;
            anim.SetBool("Run", true);
        }
        else if (moveRight)
        {
            horizontalMove = -runSpeed;
            anim.SetBool("Run", true);
        }
        else
        {
            horizontalMove = 0;
            anim.SetBool("Run", false);
        }
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }
    
    public void OnPointerUp()
    {
        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownJump()
    {
        jump = true;
    }
    public void PointerUpJump()
    {
        jump = false;
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

    /*public void BlueMovRight() 
    {
        StartCoroutine(BlueMoveR());
    }

    IEnumerator BlueMoveR() 
    {
        yield return new WaitForSeconds(0.1f);
        horizontalMove = runSpeed;
        anim.SetBool("Run", true);
    }

    public void BlueMovLeft()
    {
        StartCoroutine(BlueMoveL());
    }

    IEnumerator BlueMoveL()
    {
        yield return new WaitForSeconds(0.1f);
        horizontalMove = -runSpeed;
        anim.SetBool("Run", true);
    }*/

    /*if (normal_Mov == true)
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
}*/

}
