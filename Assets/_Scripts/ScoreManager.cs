using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;

    [SerializeField]
    [Tooltip("Score of the current game")]
    private int amount;

    public int Amount
    {
        get => amount;
        set => amount = value;
    }

    void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("Score Manager diplicates must be destroyed: ", gameObject);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
