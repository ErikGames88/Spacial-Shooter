using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public enum EnemyState {GoToCore, AttackCore, ChasePlayer, AttackPlayer}

    public EnemyState currentState; 

    private Sight _sight;

    private Transform coreTransform;

    public float coreAttackDistance, playerAttackDistance;

    [SerializeField]
    private float tolerance = 1.2f;

    void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();

        _sight = GetComponent<Sight>();

        coreTransform = GameObject.FindWithTag("Core").transform;
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
        agent.isStopped = false;

        agent.SetDestination(coreTransform.position);

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
        agent.isStopped = true;
    }	

    private void ChasePlayer()
    {
        if(_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToCore;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(_sight.detectedTarget.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if(distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }	

    private void AttackPlayer()
    {
        agent.isStopped = true;

        if(_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToCore;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if(distanceToPlayer > playerAttackDistance * tolerance)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }	

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, coreAttackDistance);
    }    
}
