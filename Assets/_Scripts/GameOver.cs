using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI actualScore, actualTime, bestScore, bestTime;

    public bool playerHasWon;

    [SerializeField]
    private Button exitButton;

    void Awake()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(playerHasWon)
        {
            actualScore.text = string.Format("SCORE: {0}", PlayerPrefs.GetInt("Last Score"));
            actualTime.text = string.Format("TIME: {0}", PlayerPrefs.GetFloat("Last Time"));
            bestScore.text = string.Format("BEST SCORE: {0}", PlayerPrefs.GetInt("High Score"));
            bestTime.text = string.Format("BEST TIME: {0}", PlayerPrefs.GetFloat("Low Time"));
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
