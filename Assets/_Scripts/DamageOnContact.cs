using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Amount of damage caused by the laser")]
    private float damage;
    
    void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false); Codigo original
        
        Life life = other.GetComponent<Life>();

        if(life != null)
        {
            //life.Amount -= damage;   Codigo original
            Debug.Log("Applying damage to: " + other.name); // CHAT GPT
            life.ApplyDamage(damage); // CHAT GPT
        }

        gameObject.SetActive(false); //CHAT GPT
    }
}
