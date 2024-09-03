using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sight))]
public class EnemyAI : MonoBehaviour
{
    public enum EnemyState {GoToCore, AttackCore, ChasePlayer, AttackPlayer}

    public EnemyState currentState; 

    private Sight _sight;

    public Transform coreTransform;
    public float coreAttackDistance, playerAttackDistance;

    void Awake()
    {
        _sight = GetComponent<Sight>();
    }

    void Update()
    {
        switch(currentState)
        {
            case EnemyState.GoToCore:
            GoToCore();
            break;

            case EnemyState.AttackCore:
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
    }

    private void GoToCore()
    {
        print("Go to core");

        if(_sight.detectedTarget != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToCore = Vector3.Distance(transform.position, coreTransform.position);
        if(distanceToCore < coreAttackDistance)
        {
            currentState = EnemyState.AttackCore;
        }
    }	

    private void AttackCore()
    {
        print("Attack the core");
    }	

    private void ChasePlayer()
    {
        print("Chase to player");

        if(_sight.detectedTarget == null)
        {
            GoToCore();
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if(distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }	

    private void AttackPlayer()
    {
        print("Attack to player");
    }	

}
