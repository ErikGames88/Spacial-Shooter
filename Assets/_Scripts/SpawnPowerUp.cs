using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUp;

    [SerializeField]
    private LayerMask spawnLayerMask;

    [SerializeField]
    private float spawnInterval; 

    void Start()
    {
        InvokeRepeating("SpawningPowerUp", 2, spawnInterval);
    }

    void SpawningPowerUp()
    {
        Instantiate(powerUp, transform.position, Quaternion.identity);
    }
}
