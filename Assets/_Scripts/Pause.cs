using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    private Button exitButton;
    
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
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ExitGame()
    {
        print("EXECUTION COMPLETED");
        Application.Quit();
    }

}
