using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Enemy prefab to instatiate (Spawning)")]
    private GameObject prefab;

    [SerializeField]
    [Tooltip("Time at which the wave is initialised and ended up")]
    private float startTime, endTime;

    [SerializeField]
    [Tooltip("Time between each enemy is generated")]
    private float spawnRate;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    /// <summary>
    /// Method by which the enemies are generated
    /// </summary>
    void SpawnEnemy()
    {
        /*float rangeEnemy = Random.Range(-45.0f, 45.0f);
        Quaternion quaternion = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rangeEnemy, 0);*/
        Instantiate(prefab, transform.position, transform.rotation);
        
    }
}