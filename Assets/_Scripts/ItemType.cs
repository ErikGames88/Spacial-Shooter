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



    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el Player
        if (other.CompareTag("Player"))
        {
            // Accede al componente Life del Player
            Life playerLife = other.GetComponent<Life>();

            if (playerLife != null)
            {
                // Aplica el efecto basado en el tipo de item
                switch (itemType)
                {
                    case Items.PlayerLife:
                        playerLife.ApplyHealth(amountPlayerLife); // Aplica vida al Player
                        Debug.Log("Vida añadida al Player.");
                        break;

                    case Items.CoreLife:
                        // Encuentra el GameObject de la Base y accede a su componente Life
                        GameObject coreObject = GameObject.FindGameObjectWithTag("Core");
                        if (coreObject != null)
                        {
                            Life coreLife = coreObject.GetComponent<Life>();
                            if (coreLife != null)
                            {
                                coreLife.ApplyHealth(amountCoreLife); // Aplica vida a la Base
                                Debug.Log("Vida añadida a la Base.");
                            }
                        }
                        break;

                    // Añadir casos para Ammo y Score si es necesario
                }

                // Destruye el objeto item después de aplicar el efecto
                Destroy(gameObject);
            }
        }
    }

    /*private int amountPlayerLife = 50;
    private int amountCoreLife = 500;

    private void OnTriggerEnter(Collider other)
    {
        if (itemType == Items.PlayerLife && other.CompareTag("Player"))
        {   
            
            Life playerLife = gameObject.GetComponent<Life>();

            if (playerLife != null)
            {
                playerLife.AddPlayerLife(amountPlayerLife); 
                Destroy(gameObject);
            }
        }
        else if (itemType == Items.CoreLife && other.CompareTag("Player"))
        {
            Life coreLife = gameObject.GetComponent<Life>();

            
            if (coreLife != null)
            {
                coreLife.AddCoreLife(amountCoreLife); 
                Destroy(gameObject);
            }
        }
        
    }*/

    
}

