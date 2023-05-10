using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSnap : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVC;
    public CinemachineFramingTransposer cameraFramingTransposer;

    private void Start()
    {
        cameraFramingTransposer = cinemachineVC.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    public void OnTriggerEnter2D(Collider2D camColl)
    {
        switch (camColl.tag)
        {
            case "snapPosition1":
                StartCoroutine(SmoothlyChangeScreenX(0.600f, 0.5f));
                break;
            case "snapPosition2":
                StartCoroutine(SmoothlyChangeScreenX(0.117f, 0.5f));
                break;
            default:
                break;
        }
    }

    private IEnumerator SmoothlyChangeScreenX(float newScreenX, float duration)
    {
        float startingScreenX = cameraFramingTransposer.m_ScreenX;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            cameraFramingTransposer.m_ScreenX = Mathf.Lerp(startingScreenX, newScreenX, t);
            yield return null;
        }

        cameraFramingTransposer.m_ScreenX = newScreenX;
    }
}
