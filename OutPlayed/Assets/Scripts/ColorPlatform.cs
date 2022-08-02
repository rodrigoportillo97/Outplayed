using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatform : MonoBehaviour
{
    public Sprite Brown;
    public Sprite Grey;

    public bool isBrown = true;
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

        if (isBrown)
        {
            MakeBrown();
        }
        else
        {
            MakeGrey();
        }
    }

    private void Update()
    {
        if (Time.time >= timeToChange)
        {
            if (isBrown)
            {
                MakeGrey();
            }
            else
            {
                MakeBrown();
            }
            timeToChange = Time.time + changeInterval;
        }
    }

    public void MakeBrown() 
    {
        sr.sprite = Brown;
        isBrown = true;
        coll.enabled = true;
    }

    public void MakeGrey() 
    {
        sr.sprite = Grey;
        isBrown = false;
        coll.enabled = false;

    }


}
