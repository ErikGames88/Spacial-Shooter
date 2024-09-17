using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Score got after defeating an enemy")]
    private int pointsAmount;

    EnemyAI _enemyAI;

    void Awake()
    {
        var life = GetComponent<Life>();
        var _enemyAI = GetComponent<EnemyAI>();

        life.onDeath.AddListener(DestroyEnemy);

    }

    void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }
    
    public void DestroyEnemy()
    {
        if(_enemyAI)
        {
            _enemyAI.currentState = EnemyAI.EnemyState.Death;
        }
        else
        {
            Debug.LogWarning("FAILED");
        }

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke("PlayDestruction", 1f);
        
        OnDestroy();
        
        Destroy(gameObject, 2f);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;

        if(ScoreManager.SharedInstance.Amount >= 9999999)
        {
            ScoreManager.SharedInstance.Amount = 9999999;
        }
    }

    void OnDestroy()
    {
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);
    }

    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
