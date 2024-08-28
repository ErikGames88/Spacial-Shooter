using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Since the laser is shot")]
    private GameObject shootingPoint;

    private Animator _animator;

    public int bulletsAmount;

    

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && bulletsAmount > 0)
        {
            _animator.SetTrigger("Shot Laser");

            Invoke("FireBullet", 0.15f);
        }
    }

    void FireBullet()
    {
        // OBJECT POOLING (EXECUTION)
            GameObject laser = ObjectPool.SharedInstance.GetFirstPooledObject(); 
            // Getting the firs bullet of the List pooledObjects

            laser.layer = LayerMask.NameToLayer("Player Laser");
            laser.transform.position = shootingPoint.transform.position;
            laser.transform.rotation = shootingPoint.transform.rotation;
            laser.SetActive(true); // Enable the bullet to display

            bulletsAmount--;
    }
    
}
