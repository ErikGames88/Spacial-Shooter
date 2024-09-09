using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player Life")]
    private Life playerLife;

    [SerializeField]
    [Tooltip("Base Life")]
    private Life coreLife;

    void Start()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        coreLife.onDeath.AddListener(CheckLoseCondition);

        EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
        WaveManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckWinCondition()
    {
        if(EnemyManager.SharedInstance.EnemyCount <= 0 && WaveManager.SharedInstance.WavesCount <= 0)
        {
            RegisterScore();
            RegisterTime();
            
            SceneManager.LoadScene("Win Scene", LoadSceneMode.Single);
        }
    }

    void CheckLoseCondition()
    {  
        SceneManager.LoadScene("Lose Scene", LoadSceneMode.Single);
    }

    void RegisterScore()
    {
        var actualScore = ScoreManager.SharedInstance.Amount;
        PlayerPrefs.SetInt("Last Score", actualScore);

        var highScore = PlayerPrefs.GetInt("High Score", 0);
        if(actualScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", actualScore);
        }
    }

    void RegisterTime()
    {
        var actualTime = Time.time;
        PlayerPrefs.SetFloat("Last Time", actualTime);

        var lowTime = PlayerPrefs.GetFloat("Low Time", 999999.0f);
        if(actualTime < lowTime)
        {
            PlayerPrefs.SetFloat("Low Time", actualTime);
        }
    }
    
}
