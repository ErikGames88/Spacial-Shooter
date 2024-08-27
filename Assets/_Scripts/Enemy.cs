using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Score got after defeating an enemy")]
    private int pointsAmount;

    void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }

    void Start()
    {
        EnemyManager.SharedInstace.AddEnemy(this);
    }
    
    void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke("PlayDestruction", 1f);
        Destroy(gameObject, 2f);

        EnemyManager.SharedInstace.AddEnemy(this);
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
