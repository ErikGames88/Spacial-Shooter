using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player Life")]
    private Life playerLife;
    
    void Update()
    {
        // WIN
        if(EnemyManager.SharedInstace.enemies.Count <= 0 && WaveManager.SharedInstance.waves.Count <= 0)
        {
            SceneManager.LoadScene("Win Scene", LoadSceneMode.Single);
        }

        // LOSE
        if(playerLife.Amount <= 0)
        {
            SceneManager.LoadScene("Lose Scene", LoadSceneMode.Single);
        }
    }
}
