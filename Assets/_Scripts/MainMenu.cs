using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button startGameButton;

    [SerializeField]
    private Button exitGameButton;

    [SerializeField]
    private Button controlsButton;

    [SerializeField]
    private GameObject controlsPanel;

    
    
    void Awake()
    {
        exitGameButton.onClick.AddListener(ExitGame);
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);  
    }

    
    public void HideControls()
    {
        controlsPanel.SetActive(false);  
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Introduction Scene");
    }

    public void ExitGame()
    {
        print("EXECUTION COMPLETED");
        Application.Quit();
    }
}
