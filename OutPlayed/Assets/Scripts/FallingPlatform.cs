using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private GameObject platformPrefab;
    public Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Fall() 
    {
        StartCoroutine(fallCR());
    }

    IEnumerator fallCR() 
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("off");
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1.5f);
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        anim.SetTrigger("on");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Fall();
    
        }
    }


}
