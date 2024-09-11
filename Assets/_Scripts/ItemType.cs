using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public enum Item{PlayerHealth, CoreHealth, Ammunition, Score, PowerUp}

    /*public Item item;

    Life _life;

    void Awake()
    {
        _life = GetComponent<Life>();
    }

    void Update()
    {
        switch(item)
        {
            case Item.PlayerHealth:
            _life.Amount += 50f;
            break;

            /*case EnemyState.AttackCore:
            AttackCore();
            break;

            case EnemyState.ChasePlayer:
            ChasePlayer();
            break;

            case EnemyState.AttackPlayer:
            AttackPlayer();
            break;

            default:
            break;
        }
    }*/

    
}
