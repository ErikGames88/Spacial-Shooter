using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Life : MonoBehaviour
{
    private float amount;

    [SerializeField]
    private float maximumLife;

    public UnityEvent onDeath;

    public bool isInvulnerable;

    
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
    }

    
    public void ApplyDamage(float damage)
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (Amount <= 0)
        {
            return;
        }

        Amount -= damage;
        

        if (Amount <= 0)
        {
            Amount = 0;
        }
    }

}    
