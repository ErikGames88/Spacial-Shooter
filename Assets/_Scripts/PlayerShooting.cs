using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    private Animator _animator;

    public int bulletsAmount;

    public Weapon weapon;

    /*[SerializeField]
    private AudioSource noShotSFX;*/

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            _animator.SetBool("Shot Laser", true);

            if(bulletsAmount > 0 && weapon.ShootLaser("Player Laser", 0.25f))
            {
                bulletsAmount--;
                if(bulletsAmount < 0)
                {
                    bulletsAmount = 0;
                    //Instantiate(noShotSFX, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                //Instantiate(noShotSFX, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            _animator.SetBool("Shot Laser", false);
        }
    }

}
