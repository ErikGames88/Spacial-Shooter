using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float lastShotTime;

    public float shotRate;

    [SerializeField]
    private GameObject shootingPoint;

    [SerializeField]
    private ParticleSystem fireEffect;

    [SerializeField]
    private AudioSource shotSFX;

    /*[SerializeField]
    private AudioSource noShotSFX;*/

    private string layerName;

    public bool ShootLaser(string layerName, float delay)
    {
        if(Time.timeScale > 0)
        {
            var timeSiceLastShot = Time.time - lastShotTime;
            if(timeSiceLastShot < shotRate)
            {
                return false;
            }

            lastShotTime = Time.time;
            this.layerName = layerName;
            Invoke("FireLaser", delay);
            
            return true;
        }

        return false;
    }

    public void FireLaser()
    {
        var laser = ObjectPool.SharedInstance.GetFirstPooledObject();
        laser.layer = LayerMask.NameToLayer(layerName);
        laser.transform.position = shootingPoint.transform.position;
        laser.transform.rotation = shootingPoint.transform.rotation;
        laser.SetActive(true);

        if(fireEffect != null)
        {
            fireEffect.Play();
        }
        
        if(shotSFX != null)
        {
           Instantiate(shotSFX, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
        }
        
    }
}
