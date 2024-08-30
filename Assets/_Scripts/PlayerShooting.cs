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

    [SerializeField]
    private ParticleSystem fireEffect;

    [SerializeField]
    private AudioSource shotSFX;
    
    [SerializeField]
    private AudioSource noShotSFX;
    
    private float fireRate = 0.5f;

    private float lastShotTime;

    public int bulletsAmount;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            _animator.SetBool("Shot Laser", true);

            if( bulletsAmount > 0)
            {
                var timeSinceLastShot = Time.time - lastShotTime;
                if(timeSinceLastShot < fireRate)
                {
                    return;
                }
               
            
                lastShotTime = Time.time;

                Invoke("FireBullet", 0.15f);
            }
            else
            {
                Instantiate(noShotSFX, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            _animator.SetBool("Shot Laser", false);
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

        fireEffect.Play();
        Instantiate(shotSFX, transform.position, transform.rotation).GetComponent<AudioSource>().Play();

        bulletsAmount--;
        if(bulletsAmount < 0)
        {
            bulletsAmount = 0;
        }
    }
    
}
