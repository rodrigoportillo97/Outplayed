using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{

    public Sprite Brown;
    public Sprite Grey;
    private Sprite startSprite;
    BoxCollider2D coll;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startSprite = sr.sprite;
        coll = GetComponent<BoxCollider2D>();
    }

    public void MakeBrown() 
    {
        sr.sprite = Brown;
        coll.enabled = true;
    }

    public void MakeGrey() 
    {
        sr.sprite = Grey;
        coll.enabled = false;
    }

    public void TurnGrey() 
    {
        StartCoroutine(turngreyCR());
    }

    IEnumerator turngreyCR() 
    {
        yield return new WaitForSeconds(1.5f);
        sr.sprite = Grey;
        coll.enabled = false;
        yield return new WaitForSeconds(0.8f);
        coll.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            MakeBrown();
            TurnGrey();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        MakeGrey();
        
    }
}
