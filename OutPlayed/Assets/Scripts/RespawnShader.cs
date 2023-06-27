using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShader : MonoBehaviour
{
    Material material;

    bool isRespawning = false;
    [Range(0f,1f)]
    public float fade = 0f;

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
            fade += Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 1f;
                isRespawning = false;
            }

            material.SetFloat("_Fade", fade);
        }
    }


}
