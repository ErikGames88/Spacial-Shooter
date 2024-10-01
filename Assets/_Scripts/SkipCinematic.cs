using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipCinematic : MonoBehaviour
{
    PlayableDirector playableDirector; 
    public GameObject skipPanel; 
    public GameObject player;
    
    public List<WaveSpawner> waveSpawners;

    private bool cinematicFinished;

    public Canvas hiddeCanvas;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else if (player != null)
        {
            player.SetActive(false);
        }

        foreach (var spawner in waveSpawners)
        {
            if (spawner != null)
            {
                spawner.gameObject.SetActive(false);
            }
        }

        if (skipPanel != null)
        {
            skipPanel.SetActive(true); 
        }

        
        if (hiddeCanvas != null)
        {
            hiddeCanvas.enabled = false; 
        }

        playableDirector = GameObject.Find("Director")?.GetComponent<PlayableDirector>();
        if (playableDirector != null)
        {
            playableDirector.stopped += OnCinematicFinished;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || playableDirector?.time >= playableDirector?.duration)
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
                hiddeCanvas.enabled = true; 
            }
            cinematicFinished = true; 
            playableDirector.Stop(); 
            playableDirector.enabled = false;
            HandlePostCinematic(); 
        }
    }

    private void HandlePostCinematic()
    {
        if (skipPanel != null)
        {
            skipPanel.SetActive(false); 
        }

        if (player != null)
        {
            player.SetActive(true); 
        }

        SwitchToGameplayCamera();
        ActivateWaveSpawners();
    }

    private void SwitchToGameplayCamera()
    {
        var gameplayCamera = GameObject.Find("Virtual Camera (Main)")?.GetComponent<CinemachineVirtualCamera>();
        if (gameplayCamera != null)
        {
            gameplayCamera.Priority = 10; 
        }

        var cinematicCamera = GameObject.Find("Virtual Camera (Track)")?.GetComponent<CinemachineVirtualCamera>();
        if (cinematicCamera != null)
        {
            cinematicCamera.Priority = 0; 
        }
    }

    private void ActivateWaveSpawners()
    {
        foreach (var spawner in waveSpawners)
        {
            if (spawner != null)
            {
                spawner.gameObject.SetActive(true); 
            }
        }
    }

    private void OnCinematicFinished(PlayableDirector director)
    {
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

