using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnShader : MonoBehaviour
{
    Material material;

    bool isRespawning = false;
    public float fade = 0f;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void Respawning () 
    {
        fade = SaveData.Instance.GetShader("Shade", fade);
        isRespawning = true;
    }

    private void Update()
    {

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
