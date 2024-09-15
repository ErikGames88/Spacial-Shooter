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


    void Start()
    {
        ammountAmmunition = Random.Range(10, 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dependiendo del tipo de item, aplicar efectos correspondientes
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
            }

            // Destruir el item después de aplicar el efecto
            Destroy(gameObject);
        }
    }

    private void ApplyLife(GameObject player)
    {
        Life playerLife = player.GetComponent<Life>();
        if (playerLife != null)
        {
            playerLife.Amount += amountPlayerLife; // Ajusta la cantidad de vida que se añade
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
                coreLife.Amount += amountCoreLife; // Ajusta la cantidad de vida que se añade
            }
        }
    }

    private void ApplyAmmunition(Collider player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.bulletsAmount += ammountAmmunition; // Ajustar la cantidad de munición según sea necesario
        }
    }
    
    void ApplyScore(Collider player)
    {
    // Obtener la instancia del ScoreManager
        ScoreManager scoreManager = ScoreManager.SharedInstance;

        // Verificar si la instancia del ScoreManager existe
        if (scoreManager != null)
        {
            // Añadir una cantidad de puntuación específica (ajustar según sea necesario)
             // Ajusta el valor según tus necesidades
            scoreManager.Amount += scoreToAdd;

            // Opcional: Mostrar el nuevo puntaje en la consola para depuración
            Debug.Log("Player's new score: " + scoreManager.Amount);
        }
        else
        {
            Debug.LogWarning("ScoreManager instance not found!");
        }
    }
}

