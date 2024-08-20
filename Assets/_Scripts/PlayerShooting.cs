using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Since the laser is shot")]
    private GameObject shootingPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // OBJECT POOLING (EXECUTION)
            GameObject laser = ObjectPool.SharedInstance.GetFirstPooledObject(); 
            // Getting the firs bullet of the List pooledObjects

            laser.layer = LayerMask.NameToLayer("Player Laser");
            laser.transform.position = shootingPoint.transform.position;
            laser.transform.rotation = shootingPoint.transform.rotation;
            laser.SetActive(true); // Enable the bullet to display
        }
    }

    
    
}
