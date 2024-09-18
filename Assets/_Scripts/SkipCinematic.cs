using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipCinematic : MonoBehaviour
{
    PlayableDirector playableDirector; 
    public GameObject skipPanel; // Asigna el panel aquí
    public GameObject player;
    
    public List<WaveSpawner> waveSpawners;

    private bool cinematicFinished;

    public Canvas hiddeCanvas;

    void Start()
    {
        // Asegurarse de que el Player está asignado
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player == null)
        {
            Debug.LogError("Player not found.");
        }
        else
        {
            player.SetActive(false); // Desactivar el Player al inicio
        }

        // Asegurar la existencia de WaveSpawners
        if (waveSpawners.Count == 0)
        {
            Debug.LogError("No WaveSpawners assigned.");
        }
        else
        {
            foreach (var spawner in waveSpawners)
            {
                if (spawner == null)
                {
                    Debug.LogError("A WaveSpawner is missing.");
                }
                else
                {
                    spawner.gameObject.SetActive(false); // Desactivar spawners al inicio
                }
            }
        }

        // Mostrar el skipPanel
        if (skipPanel != null)
        {
            skipPanel.SetActive(true); // Mostrar skipPanel al inicio
        }

        
        if (hiddeCanvas != null)
        {
            hiddeCanvas.enabled = false; // Mostrar skipPanel al inicio
        }

        playableDirector = GameObject.Find("Director").GetComponent<PlayableDirector>();
        if (playableDirector != null)
        {
            Debug.Log("DURATION: " + playableDirector.duration);
            Debug.Log("TIME: " + playableDirector.time);
            playableDirector.stopped += OnCinematicFinished;
            // playableDirector.Stop();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || playableDirector.time >= playableDirector.duration)
        {
            SkipCinematics();
        }
    }

    public void SkipCinematics()
    {
        if (!cinematicFinished && playableDirector != null)
        {
            if (hiddeCanvas != null)
            {
                hiddeCanvas.enabled = true; // Mostrar skipPanel al inicio
            }
            cinematicFinished = true; // Asegurar que sólo se salte una vez
            playableDirector.Stop(); // Detener la cinemática
            HandlePostCinematic(); // Manejar el post-cinemático
        }
    }

    private void HandlePostCinematic()
    {
        if (skipPanel != null)
        {
            skipPanel.SetActive(false); // Ocultar el skipPanel
        }

        if (player != null)
        {
            Debug.Log("Player activated.");
            player.SetActive(true); // Activar el Player
        }

        SwitchToGameplayCamera();
        ActivateWaveSpawners();
    }

    private void SwitchToGameplayCamera()
    {
        var gameplayCamera = GameObject.Find("Virtual Camera (Main)")?.GetComponent<CinemachineVirtualCamera>();
        if (gameplayCamera != null)
        {
            gameplayCamera.Priority = 10; // Activar la cámara de gameplay
            Debug.Log("Gameplay camera activated.");
        }

        var cinematicCamera = GameObject.Find("Virtual Camera (Track)")?.GetComponent<CinemachineVirtualCamera>();
        if (cinematicCamera != null)
        {
            cinematicCamera.Priority = 0; // Desactivar la cámara de cinemática
            Debug.Log("Cinematic camera deactivated.");
        }
    }

    private void ActivateWaveSpawners()
    {
        Debug.Log("ENTERING ACTIVATEWAVESPAWNER");
        foreach (var spawner in waveSpawners)
        {
            if (spawner != null)
            {
                spawner.gameObject.SetActive(true); // Activar WaveSpawners
                Debug.Log("WaveSpawner activated.");
            }
        }
    }

    private void OnCinematicFinished(PlayableDirector director)
    {
        Debug.Log("ONCINEMATICFINISHED");
        if (!cinematicFinished)
        {
            HandlePostCinematic();
        }
    }

    private void OnDisable()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnCinematicFinished;
        }
    }
}

