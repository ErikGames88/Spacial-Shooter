using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI actualScore, actualTime, bestScore, bestTime;

    [SerializeField]
    private bool playerHasWon;

    void Awake()
    {
        actualScore = GetComponent<TextMeshProUGUI>();
        actualTime = GetComponent<TextMeshProUGUI>();
        bestScore = GetComponent<TextMeshProUGUI>();
        bestTime = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(playerHasWon)
        {
            actualScore.text = "SCORE: " + PlayerPrefs.GetInt("Last Score");
            actualTime.text = "TIME: " + PlayerPrefs.GetInt("Last Time");
            bestScore.text = "BEST SCORE: " + PlayerPrefs.GetFloat("High Score");
            bestTime.text = "BEST TIME: " + PlayerPrefs.GetInt("Low Time");
        }
    }

    
    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
