using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Score got after defeating an enemy")]
    private int pointsAmount;

    void Start()
    {
        EnemyManager.SharedInstace.enemies.Add(this);
    }
    
    void OnDestroy()
    {
        EnemyManager.SharedInstace.enemies.Remove(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;

        if(ScoreManager.SharedInstance.Amount >= 9999999)
        {
            ScoreManager.SharedInstance.Amount = 9999999;
        }
    }
}
