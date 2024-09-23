using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField]
    private float damage;
    
    void OnTriggerEnter(Collider other)
    {
        
        Life life = other.GetComponent<Life>();

        if(life != null)
        {
            life.ApplyDamage(damage); 
        }

        gameObject.SetActive(false); 
    }
}
