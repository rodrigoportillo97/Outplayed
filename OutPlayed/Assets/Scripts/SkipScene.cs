using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{
    public SceneFader fader;


    public void Skipsc() 
    {
        fader.FadeTo();
    }
}
