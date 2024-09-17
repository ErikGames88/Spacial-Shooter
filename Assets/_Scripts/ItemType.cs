using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public enum Items {PlayerLife, CoreLife, Ammunition, Score, PowerUp}

    
    public Items itemType;


    private int amountPlayerLife = 50;
    private int amountCoreLife = 100;
    private int ammountAmmunition;
    int scoreToAdd = 1000;

    PowerUp _powerUp;
    GameObject powerUpManager;


    void Start()
    {
        ammountAmmunition = Random.Range(10, 20);
        powerUpManager = GameObject.Find("PowerUpManager");
        _powerUp = powerUpManager.GetComponent<PowerUp>();
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
                    _powerUp.duration = 5f;
                    _powerUp.startPowerUp(other.gameObject);
                    break;

                default:
                break;
            }

                Destroy(gameObject);
            /*if (itemType != Items.PowerUp)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
                Collider itemCollider = GetComponent<Collider>();
                if (itemCollider != null)
                {
                    itemCollider.enabled = false;
                }
            }*/
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

        
        if (scoreManager != null)
        {
            scoreManager.Amount += scoreToAdd;
        }
        else
        {
            Debug.LogWarning("ScoreManager instance not found!");
        }
    }

    /*private void ApplyPowerUp(Collider player)
    {
       PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        Life playerLife = player.GetComponent<Life>();

        if (playerShooting != null && playerLife != null)
        {
            Debug.Log("Applying Power-up.");
            // Activar munición infinita e invulnerabilidad
            playerShooting.hasInfiniteAmmunition = true;
            playerLife.isInvulnerable = true;

            float powerUpDuration = 10f;
            // Desactivar el power-up después de un tiempo
            Debug.Log("Power-up coroutine started.");
            StartCoroutine(DisablePowerUp(playerShooting, playerLife, powerUpDuration));
        }
        else
        {
            Debug.LogWarning("PlayerShooting or Life component not found.");
        }
        
    }

    private IEnumerator DisablePowerUp(PlayerShooting playerShooting, Life playerLife, float duration)
    {
         Debug.Log("Waiting " + duration + " seconds to deactivate power-up...");
        yield return new WaitForSeconds(duration);

        // Desactivar munición infinita e invulnerabilidad
        playerShooting.hasInfiniteAmmunition = false;
        playerLife.isInvulnerable = false;
        
        // Opcional: Mostrar mensaje de depuración
        Debug.Log("Power-up deactivated.");

        // Destruir el PowerUp después de que el efecto haya terminado
        Destroy(gameObject);
    }*/

    
}

