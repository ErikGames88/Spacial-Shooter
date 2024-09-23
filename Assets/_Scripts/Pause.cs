using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private AudioMixerSnapshot pauseSnapshot, gameSnapshot;

    
    void Awake()
    {
        pauseMenu.SetActive(false);

        exitButton.onClick.AddListener(ExitGame);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            pauseSnapshot.TransitionTo(0.2f);
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameSnapshot.TransitionTo(0.2f);
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

}
