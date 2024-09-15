using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs; 

    private Vector2 xRange = new Vector2(54f, 90f); 
    private Vector2 zRange = new Vector2(48f, 90f); 
    private float yHeight = 55f; 

    private Vector3 spawnAreaSize = new Vector3(0.5f, 0.5f, 0.5f); 

    [SerializeField]
    private LayerMask spawnLayerMask;

    [SerializeField]
    private float spawnInterval; 

    
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", 2f, spawnInterval);
    }

    /*IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }*/

    void SpawnRandomObject()
    {
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        Vector3 randomPosition = new Vector3(Random.Range(xRange.x, xRange.y), yHeight,
        Random.Range(zRange.x, zRange.y));

        if(!Physics.CheckBox(randomPosition, spawnAreaSize / 2, Quaternion.identity, spawnLayerMask))
        {
            
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
