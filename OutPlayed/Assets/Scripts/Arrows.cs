using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator anim;

    private void Start()
    {
       anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        anim.enabled = true;
        Destroy();
    }

    public void Destroy()
    {
        StartCoroutine(DestroyCR());
    }

    IEnumerator DestroyCR() 
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
