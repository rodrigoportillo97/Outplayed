using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private PlayerMovement pmov;
    public Text deathCount;
    public Text deathCount2;
    private int deathcount = 0;
    private Vector2 respawnPoint;
    bool hasDetectedTrigger;
    public Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private CircleCollider2D cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();
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
            pmov.enabled = false;
            Dead();
            DeathIncreased();
            Debug.Log($"OnTriggerEnter2D from {gameObject.name} collided with {collision.gameObject.name}");
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
        bc.enabled = false;
        cc.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(1.5f);
        transform.position = respawnPoint;
        anim.SetTrigger("alive");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Alive();
    }

    public void Alive() 
    {
        StartCoroutine(AliveCR());
    }
    
    IEnumerator AliveCR() 
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("isAlive");
        bc.enabled = true;
        cc.enabled = true;
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        pmov.enabled = true;
    }
}
