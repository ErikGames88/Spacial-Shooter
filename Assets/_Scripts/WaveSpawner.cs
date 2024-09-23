using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float startTime, endTime;

    [SerializeField]
    private float spawnRate;

    
    void Start()
    {
        WaveManager.SharedInstance.AddWave(this);

        InvokeRepeating("SpawnEnemy", startTime, spawnRate);
        Invoke("EndWave", endTime);
    }

   void SpawnEnemy()
    {
       Instantiate(prefab, transform.position, transform.rotation);
    }

    void EndWave()
    {
        WaveManager.SharedInstance.RemoveWave(this);
        CancelInvoke();
    }
}
