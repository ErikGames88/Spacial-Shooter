using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Since the bullet is shot")]
    private GameObject shootingPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // OBJECT POOLING (EXECUTION)
            GameObject bullet = ObjectPool.SharedInstance.GetFirstPooledObject(); // Getting the firs bullet of the List pooledObjects
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true); // Enable the bullet to display
        }
    }

    
    
}
