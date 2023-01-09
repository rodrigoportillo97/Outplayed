using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private PlayerMovement pmov;
    [SerializeField] private bool hasDetectedTrigger;
    public Text deathCount;
    public Text deathCount2;
    public int deathcount;
    private Vector2 respawnPoint;
    public Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    public IngameUI ui;

    

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();

        deathcount = SaveData.Instance.GetDeaths("Death", deathcount);
        transform.position = SaveData.Instance.GetPosition("Player", transform.position);
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
        Debug.Log($"OnTriggerEnter2D from {hasDetectedTrigger} collided with {collision.gameObject.name}");
        if (collision.tag == "deadPoint" && hasDetectedTrigger == false)
        {
            pmov.enabled = false;
            Dead();
            DeathIncreased();
            hasDetectedTrigger = true;
            Debug.Log(deathcount);
            Debug.Log($"OnTriggerEnter2D from {gameObject.name} collided with {collision.gameObject.name}");
        }
        else if (collision.tag == "CheckPoint" && hasDetectedTrigger == false)
        {
            collision.gameObject.GetComponent<CheckPoint>()?.ActivateCheckPoint();
            SaveData.Instance.SetPosition("Player", transform.position);
            SaveData.Instance.SetDeaths("Death", deathcount);
            SaveData.Instance.Save();
            respawnPoint = transform.position;
            hasDetectedTrigger = true;
        }

        //hasDetectedTrigger = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log($"OnTriggerExit2D from {hasDetectedTrigger} collided with {collision.gameObject.name}");
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
        anim.SetBool("isJumping", false);
        anim.SetTrigger("death");
        yield return new WaitForSeconds(0.7f);
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
        yield return new WaitForSeconds(0.7f);
        anim.SetTrigger("isAlive");
        bc.enabled = true;
        cc.enabled = true;
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        pmov.enabled = true;
    }

 
}
