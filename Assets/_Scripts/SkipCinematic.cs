using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipCinematic : MonoBehaviour
{
    public PlayableDirector playableDirector; // Asigna tu PlayableDirector aquí
    public GameObject skipButton; // Asigna el botón de saltar aquí
    public GameObject skipImage;  // Asigna la imagen de instrucciones aquí

    private bool cinematicFinished = false;

    void Start()
    {
        // Desactivar al jugador al inicio para replicar el comportamiento del Activation Track
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(false); // Desactiva el Player al inicio
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }

        // Iniciar la corrutina para verificar cuando termine la cinemática
        StartCoroutine(WaitForCinematicToEnd());
    }

    // Método llamado cuando el botón para saltar la cinemática es presionado
    public void SkipCinematics()
    {
        if (!cinematicFinished)
        {
            // Detener la cinemática
            playableDirector.Stop();

            // Activar al jugador manualmente
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.SetActive(true); // Activa al jugador

                // Activar el componente de movimiento del jugador, si existe
                var movementComponent = player.GetComponent<PlayerMovement>(); // Asegúrate de cambiar 'PlayerMovement' por el nombre correcto
                if (movementComponent != null)
                {
                    movementComponent.enabled = true;
                }
            }
            else
            {
                Debug.LogError("Player not found when skipping cinematic.");
            }

            // Forzar la transición a la cámara del gameplay
            SwitchToGameplayCamera();

            // Marcar la cinemática como finalizada
            cinematicFinished = true;

            // Ocultar el botón de saltar la cinemática
            skipButton.SetActive(false);
            skipImage.SetActive(false);
        }
    }

    // Método para cambiar a la cámara de gameplay
    private void SwitchToGameplayCamera()
    {
        // Encontrar la cámara de gameplay (Virtual Camera Main)
        var gameplayCamera = GameObject.Find("Virtual Camera (Main)").GetComponent<CinemachineVirtualCamera>();
        if (gameplayCamera != null)
        {
            gameplayCamera.Priority = 10; // Aumenta la prioridad para que esta cámara tome el control
        }
        else
        {
            Debug.LogError("Gameplay Camera (Virtual Camera (Main)) not found.");
        }

        // Bajar la prioridad de la cámara de cinemática (Virtual Camera Track)
        var cinematicCamera = GameObject.Find("Virtual Camera (Track)").GetComponent<CinemachineVirtualCamera>();
        if (cinematicCamera != null)
        {
            cinematicCamera.Priority = 0; // Baja la prioridad de la cámara de cinemática
        }
        else
        {
            Debug.LogError("Cinematic Camera (Virtual Camera (Track)) not found.");
        }
    }

    // Método que espera a que la cinemática termine
    private IEnumerator WaitForCinematicToEnd()
    {
        // Esperar a que la duración del PlayableDirector llegue a su fin
        yield return new WaitUntil(() => playableDirector.state != PlayState.Playing);

        OnCinematicFinished();
    }

    // Método llamado cuando la cinemática termina naturalmente (sin saltarla)
    private void OnCinematicFinished()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(true); // Activar al jugador al terminar la cinemática
        }
        else
        {
            Debug.LogError("Player not found when cinematic finishes.");
        }

        // Asegurarse de que la cámara de gameplay esté activa
        SwitchToGameplayCamera();
    }
}
