using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration; // Duración del PowerUp en segundos
    GameObject player;

    public void startPowerUp(GameObject other)
    {
        player = other;
        ApplyPowerUp(player, true);

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

    private void ApplyPowerUp(GameObject player, bool apply)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        Life playerLife = player.GetComponent<Life>();

        if (playerShooting != null && playerLife != null)
        {
            // Activar/desactivar munición infinita e invulnerabilidad
            playerShooting.hasInfiniteAmmunition = apply;
            playerLife.isInvulnerable = apply;

            // Mostrar mensaje de depuración
            // Debug.Log("Power-up applied: Infinite ammunition and invulnerability activated.");
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
        ApplyPowerUp(player, false);
    }
}
