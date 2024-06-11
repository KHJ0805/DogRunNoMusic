using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] itemObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnItem();
            maxSpawnDelay = Random.Range(5f, 7f);
            curSpawnDelay = 0;
        }
           
    }

    void SpawnItem()
    {
        int ranItem = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 3);
        Instantiate(itemObjs[ranItem],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);
    }
}
