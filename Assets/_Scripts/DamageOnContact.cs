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
        //Debug.Log(other.name);
        //Destroy(gameObject); // Not doing it, using the pool
        gameObject.SetActive(false); // Desable the object as in the pool, without destroying it

        /*if(other.CompareTag("Enemy") || other.CompareTag("Player")) 
        {
            Destroy(other.gameObject);
        }*/

        Life life = other.GetComponent<Life>();

        if(life != null)
        {
            life.Amount -= damage; // life.amount = life.amount - damage;
        }
    }
}
