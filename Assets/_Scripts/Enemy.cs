using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int pointsAmount;

    EnemyAI _enemyAI;

    Life life;

    private AudioSource explosionAudio;

    void Awake()
    {
        life = GetComponent<Life>();
        _enemyAI = GetComponentInChildren<EnemyAI>();
        explosionAudio = GetComponent<AudioSource>();

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

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke("PlayDestruction", 1f);
        
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
        
        life.onDeath.RemoveListener(DestroyEnemy);
    }

    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
        explosionAudio.Play();
    }
}
