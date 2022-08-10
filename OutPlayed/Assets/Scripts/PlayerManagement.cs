using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    public Text deathCount;
    public Text deathCount2;
    private int deathcount = 0;
    private Vector2 respawnPoint;
    bool hasDetectedTrigger;
    public Animator anim;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    public void DeathIncreased()
    {
        deathcount++;
        deathCount.text = deathcount.ToString();
        deathCount2.text = deathcount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "deadPoint" && hasDetectedTrigger == false)
        {
            Dead();
            DeathIncreased();
            //Debug.Log($"OnTriggerEnter2D from {gameObject.name} collided with {collision.gameObject.name}");
        }
        else if (collision.tag == "CheckPoint" && hasDetectedTrigger == false)
        {
            respawnPoint = transform.position;
        }
        hasDetectedTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasDetectedTrigger = false;
    }

    public void Dead()
    {
        StartCoroutine(DeadCR());
    }

    IEnumerator DeadCR()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1);
        anim.SetTrigger("alive");
        transform.position = respawnPoint;
        Alive();
    }

    public void Alive() 
    {
        StartCoroutine(AliveCR());
    }
    
    IEnumerator AliveCR() 
    {
        yield return new WaitForSeconds(1.5f);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
