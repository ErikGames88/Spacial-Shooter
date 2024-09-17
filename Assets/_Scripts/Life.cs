using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Life : MonoBehaviour
{
    [Tooltip("Amount of life of Player and enemies")]
    private float amount;

    [SerializeField]
    [Tooltip("Maximum life for each object (Player, Enemy and Core)")]
    private float maximumLife;

    [Tooltip("Related death event")]
    public UnityEvent onDeath;

    public bool isInvulnerable;

    Enemy _enemy;
    
    public float Amount
    {
        get => amount;
        set 
        {
            if(!isInvulnerable)
            {
                amount = Mathf.Clamp(value, 0, maximumLife);
            
                if(amount <= 0)
                {
                    onDeath.Invoke();
                }
            }
        } 
    }

    public float MaximumLife
    {
        get => maximumLife;
        set => maximumLife = value;
    }


    

    void Awake()
    {
        amount = maximumLife;
        _enemy = GetComponent<Enemy>();
    }

    
    
    // TODO A PARTIR DE AQUÍ PARA ABAJO CHAT GPT, POSIBLE BORRAR
    public void ApplyDamage(float damage)
    {
        if (!gameObject.activeInHierarchy)
        {
            //Debug.Log("Object inactive, not applying damage.");
            return;
        }

        if (Amount <= 0)
        {
            //Debug.Log("Object already destroyed, not applying damage.");
            return;
        }

        //Debug.Log("Applying damage: " + damage);
        Amount -= damage;
        //Debug.Log("New health: " + Amount);

        if (Amount <= 0)
        {
            Amount = 0;
            //Debug.Log("Object destroyed");
            _enemy.DestroyEnemy();
        }
    }

}    
