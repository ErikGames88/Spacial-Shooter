using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipCinematic : MonoBehaviour
{
    public PlayableDirector playableDirector; 
    public GameObject skipPanel; // Asigna el panel aquí
    public GameObject player;
    
    public List<WaveSpawner> waveSpawners;
    private bool cinematicFinished;

    void Start()
    {
        // Si no has asignado el Player en el Editor, intenta buscarlo por Tag
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player != null)
        {
            player.SetActive(false); // Desactiva el Player al inicio
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }

        // Desactivar los WaveSpawners al inicio
        foreach (var spawner in waveSpawners)
        {
            spawner.gameObject.SetActive(false);
        }

        // Mostrar el panel de skip durante la cinemática
        skipPanel.SetActive(true);
    }

    void Update()
    {
        // Escuchar la tecla 'S' para saltar la cinemática
        if (Input.GetKeyDown(KeyCode.S))
        {
            SkipCinematics();
        }
    }

    // Método llamado cuando el botón para saltar la cinemática es presionado
    public void SkipCinematics()
    {
        if (!cinematicFinished)
        {
            // Detener la cinemática
            playableDirector.Stop();

            // Activar al jugador manualmente
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

            // Ocultar el panel de saltar la cinemática
            skipPanel.SetActive(false);

            // Activar los WaveSpawners
            foreach (var spawner in waveSpawners)
            {
                spawner.gameObject.SetActive(true);
            }
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

    // Método llamado cuando la cinemática termina naturalmente (sin saltarla)
    private void OnCinematicFinished(PlayableDirector director)
    {
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

        // Activar los WaveSpawners
        foreach (var spawner in waveSpawners)
        {
            spawner.gameObject.SetActive(true);
        }
    }

    // Si usas el evento del PlayableDirector para detectar cuando termina la cinemática
    private void OnEnable()
    {
        playableDirector.stopped += OnCinematicFinished; // Vincular evento al PlayableDirector
    }

    private void OnDisable()
    {
        playableDirector.stopped -= OnCinematicFinished; // Desvincular evento al desactivar el objeto
    }
}
