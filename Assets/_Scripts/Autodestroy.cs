using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Time after which the bullet is destroyed")]
    private float destructionDelay;
    
    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }

    
}
