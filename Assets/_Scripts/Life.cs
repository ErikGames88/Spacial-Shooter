using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Amount of life of Player and enemies")]
    private float amount;
    public float Amount
    {
        get => amount;
        set 
        {
            amount = value;
            
            if(amount <= 0)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Play Die");

                Invoke("PlayDestruction", 1.01f);
                Destroy(gameObject, 1.3f);
            }
        } 
    }

    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }


}    
