using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenArrows;
    public Transform firepoint;
    public GameObject arrowsPrefab;
    private float cooldown;

    public void SpawnArrow() 
    {
        cooldown = 0;
        Instantiate(arrowsPrefab, firepoint.position, firepoint.rotation);
    }

    private void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= timeBetweenArrows)
        {
            SpawnArrow();
        }
    }
}
