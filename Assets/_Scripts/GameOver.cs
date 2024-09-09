using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI actualScore, actualTime, bestScore, bestTime;

    public bool playerHasWon;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(playerHasWon)
        {
            actualScore.text = "SCORE: " + PlayerPrefs.GetInt("Last Score");
            actualTime.text = "TIME: " + PlayerPrefs.GetFloat("Last Time");
            bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("High Score");
            bestTime.text = "BEST TIME: " + PlayerPrefs.GetFloat("Low Time");
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
