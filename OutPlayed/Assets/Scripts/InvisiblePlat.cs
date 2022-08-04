using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlat : MonoBehaviour
{
    public Sprite platform;

    public bool isActive = true;
    public float changeInterval = 1f;
    float timeToChange;

    SpriteRenderer sr;
    BoxCollider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timeToChange = changeInterval;
        coll = GetComponent<BoxCollider2D>();

        if (isActive)
        {
            MakePlatform();
        }
        else
        {
            NoPlatform();
        }
    }

    private void Update()
    {
        if (Time.time >= timeToChange)
        {
            if (isActive)
            {
                NoPlatform();
            }
            else
            {
                MakePlatform();
            }
            timeToChange = Time.time + changeInterval;
        }
    }

    public void MakePlatform()
    {
        sr.sprite = platform;
        sr.enabled = true;
        isActive = true;
        coll.enabled = true;
    }

    public void NoPlatform()
    {
        sr.enabled = false;
        isActive = false;
        coll.enabled = false;
        
    }
}
