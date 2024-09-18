using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerEnemySpawn : MonoBehaviour
{
    public GameObject prefab;
    public float startTime, endTime;
    public float spawnRate;

    void Start()
    {
         InvokeRepeating("SpawnEnemy", startTime, spawnRate);
    }

    void SpawnEnemy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}