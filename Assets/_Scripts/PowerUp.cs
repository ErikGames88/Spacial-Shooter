using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 2f; // Duración del PowerUp en segundos

    public void startPowerUp(GameObject other)
    {
        ApplyPowerUp(other);

        // Verifica si el GameObject sigue activo antes de iniciar la corrutina
        if (gameObject.activeInHierarchy)
        {
            Debug.Log("ENTERING THE COROUTINE");
            StartCoroutine(HandlePowerUpDuration());
        }
        else
        {
            Debug.LogWarning("Power-up GameObject is inactive. Cannot start coroutine.");
        }
    }

    private void ApplyPowerUp(GameObject player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        Life playerLife = player.GetComponent<Life>();

        if (playerShooting != null && playerLife != null)
        {
            // Activar munición infinita e invulnerabilidad
            playerShooting.hasInfiniteAmmunition = true;
            playerLife.isInvulnerable = true;

            // Mostrar mensaje de depuración
            Debug.Log("Power-up applied: Infinite ammunition and invulnerability activated.");
        }
        else
        {
            Debug.LogWarning("PlayerShooting or Life component not found.");
        }
    }

    private IEnumerator HandlePowerUpDuration()
    {
        // Esperar el tiempo especificado antes de destruir el objeto
        yield return new WaitForSeconds(duration);

        // Restaurar el PowerUp y desactivarlo después de la duración
        Debug.Log("Power-up deactivated.");
        Destroy(gameObject);
    }
}
