using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Shortcut : MonoBehaviour
{

    public TMP_Text shorcutText;

    private void Start()
    {
        shorcutText.enabled = false;
    }

    public void delayText() 
    {
        StartCoroutine(txtSC());
    }

    IEnumerator txtSC() 
    {
        yield return new WaitForSeconds(0.3f);
        shorcutText.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            delayText();
        }
    }


}
