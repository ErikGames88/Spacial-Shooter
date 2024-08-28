using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
}    
