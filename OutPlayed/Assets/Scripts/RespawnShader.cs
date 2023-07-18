using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnShader : MonoBehaviour
{
    Material material;

    bool isRespawning = false;
    public float fade;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }


    public void Respawning () 
    {
        isRespawning = true;
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey($"Player_x"))
        {
            Respawning();
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
