using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bullet shot by Player")]
    private GameObject prefab;

    [SerializeField]
    [Tooltip("Since the bullet is shot")]
    private GameObject shootingPoint;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(prefab);
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            //TODO:
            Destroy(bullet,2);
        }
    }
}
