using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShader : MonoBehaviour
{
    Material material;

    bool isRespawning = false;
    float fade = 1f;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRespawning = true;
        }

        if (isRespawning)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isRespawning = false;
            }

            material.SetFloat("_Fade", fade);
        }
    }



}
