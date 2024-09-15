using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas, si es necesario
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartPowerUp(GameObject powerUp, float duration)
    {
        StartCoroutine(HandlePowerUp(powerUp, duration));
    }

    private IEnumerator HandlePowerUp(GameObject powerUp, float duration)
    {
        // Desactivar el PowerUp en la escena, pero mantener la corrutina en ejecución
        powerUp.SetActive(false);

        // Esperar el tiempo especificado
        yield return new WaitForSeconds(duration);

        // Restaurar el PowerUp y desactivarlo después de la duración
        Destroy(powerUp);
    }
}
