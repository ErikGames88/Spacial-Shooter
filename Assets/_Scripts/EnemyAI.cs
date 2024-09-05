using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;

    public enum EnemyState {GoToCore, AttackCore, ChasePlayer, AttackPlayer}

    public EnemyState currentState; 

    private Sight _sight;

    private Transform coreTransform;

    public float coreAttackDistance, playerAttackDistance;

    [SerializeField]
    private float tolerance = 1.2f;

    private float lastShotTime;

    public float shotRate;

    private Animator _animator;

    void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _sight = GetComponent<Sight>();
        _animator = GetComponentInParent<Animator>();

        coreTransform = GameObject.FindGameObjectWithTag("Core").transform;
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
        _animator.SetBool("Shot Laser", false);

        _agent.isStopped = false;
        _agent.SetDestination(coreTransform.position);

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
        _agent.isStopped = true;

        LookAt(coreTransform.position);
        ShootTarget();
    }	

    private void ChasePlayer()
    {
        _animator.SetBool("Shot Laser", false);

        if(_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToCore;
            return;
        }

        _agent.isStopped = false;
        _agent.SetDestination(_sight.detectedTarget.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if(distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }	

    private void AttackPlayer()
    {
        _agent.isStopped = true;

        if(_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToCore;
            return;
        }

        LookAt(_sight.detectedTarget.transform.position);
        ShootTarget();

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if(distanceToPlayer > playerAttackDistance * tolerance)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void ShootTarget()
    {
        if(Time.timeScale > 0)
        {
            var timeSiceLastShot = Time.time - lastShotTime;
            if(timeSiceLastShot < shotRate)
            {
                return;
            }

            lastShotTime = Time.time;

            _animator.SetBool("Shot Laser", true);
            var laser = ObjectPool.SharedInstance.GetFirstPooledObject();
            laser.layer = LayerMask.NameToLayer("Enemy Laser");
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            laser.SetActive(true);
        }
    }	

    void LookAt(Vector3 targetPosition)
    {
        var directionToLook = Vector3.Normalize(targetPosition - transform.position);
        directionToLook.y = 0;
        transform.parent.forward = directionToLook;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, coreAttackDistance);
    }    
}
