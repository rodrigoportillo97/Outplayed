using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData

{
    public int deaths;
    public float time;
    public float[] position;

    public PlayerData (PlayerManagement player, IngameUI timer) 
    {
        deaths = player.deathcount;
        time = timer.time;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        
    }
}
