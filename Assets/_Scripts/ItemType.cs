using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public enum Items {PlayerLife, CoreLife, Ammunition, Score, PowerUp}
    public Items itemType;

    private int amountPlayerLife = 50;
    private int amountCoreLife = 500;
    private int ammountAmmunition;
    private int scoreToAdd = 200;

    private PowerUp _powerUp;
    private GameObject powerUpManager;
    private ParticleSystem powerUpEffect;


    void Start()
    {
        ammountAmmunition = Random.Range(30, 40);
        powerUpManager = GameObject.Find("PowerUpManager");
        _powerUp = powerUpManager.GetComponent<PowerUp>();

        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            Transform particleTransform = player.transform.Find("Power Up Effect");
            if(particleTransform != null) 
            {
                powerUpEffect = particleTransform.GetComponentInChildren<ParticleSystem>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (itemType)
            {
                case Items.PlayerLife:
                    ApplyLife(other.gameObject);
                    break;

                case Items.CoreLife:
                    ApplyCoreLife();
                    break;

                case Items.Score:
                    ApplyScore(other);
                    break;

                case Items.Ammunition:
                    ApplyAmmunition(other);
                    break;

                case Items.PowerUp:
                    powerUpEffect.Play();
                    _powerUp.Duration = 40;
                    _powerUp.StartPowerUp(other.gameObject);
                    break;

                default:
                break;
            }

            Destroy(gameObject);
        }
    }

    private void ApplyLife(GameObject player)
    {
        Life playerLife = player.GetComponent<Life>();
        if (playerLife != null)
        {
            playerLife.Amount += amountPlayerLife; 
        }
    }

    private void ApplyCoreLife()
    {
        GameObject core = GameObject.FindGameObjectWithTag("Core");
        if (core != null)
        {
            Life coreLife = core.GetComponent<Life>();
            if (coreLife != null)
            {
                coreLife.Amount += amountCoreLife; 
            }
        }
    }

    private void ApplyAmmunition(Collider player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.bulletsAmount += ammountAmmunition; 
        }
    }
    
    void ApplyScore(Collider player)
    {
        ScoreManager scoreManager = ScoreManager.SharedInstance;
        scoreManager.Amount += scoreToAdd;
    }
}

