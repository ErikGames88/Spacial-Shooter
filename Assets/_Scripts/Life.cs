using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Amount of life of Player and enemies")]
    private float amount;

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

}    
