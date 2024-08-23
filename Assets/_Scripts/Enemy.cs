using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Amount of points got after defeating an enemy")]
    private int pointsAmount;
    
    void OnDestroy()
    {
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }
}
