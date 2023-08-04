using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Saturation : MonoBehaviour
{
    private Volume globalVolume;
    private VolumeProfile volumeProfile;
    public ColorAdjustments colorAdjustments;

    void Start()
    {
        
        globalVolume = gameObject.GetComponent<Volume>();

        
        if (globalVolume != null)
        {
            volumeProfile = globalVolume.sharedProfile;
            volumeProfile.TryGet(out colorAdjustments);
        }
        

        if (PlayerPrefs.HasKey($"Player_x"))
        {
            colorAdjustments.saturation.value = 0;
        }
        else
        {
            colorAdjustments.saturation.value = -100f;
        }

    }
}
