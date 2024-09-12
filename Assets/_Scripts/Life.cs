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

    
    public float Amount
    {
        get => amount;
        set 
        {
            amount = value;
            
            if(amount <= 0)
            {
                onDeath.Invoke();
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

    
    public void ApplyHealth(float amount)
    {
        Amount += amount;
        Debug.Log("Nueva vida: " + Amount);
    }

}    
