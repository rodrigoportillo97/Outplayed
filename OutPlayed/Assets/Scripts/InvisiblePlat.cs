using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlat : MonoBehaviour
{
    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Reload() 
    {
        StartCoroutine(reloadCR());
    }

    IEnumerator reloadCR()
    {
        yield return new WaitForSeconds(3);
        rend.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.enabled = true;
            Reload();
        }
    }
}
