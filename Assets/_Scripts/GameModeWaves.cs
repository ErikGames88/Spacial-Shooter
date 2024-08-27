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

    void Awake()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        coreLife.onDeath.AddListener(CheckLoseCondition);

        EnemyManager.SharedInstace.onEnemyChanged.AddListener(CheckWinCondition);
        WaveManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckWinCondition()
    {
        if(EnemyManager.SharedInstace.EnemyCount <= 0 && WaveManager.SharedInstance.WaveCount <= 0)
        {
            SceneManager.LoadScene("Win Scene", LoadSceneMode.Single);
        }
    }

    void CheckLoseCondition()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        SceneManager.LoadScene("Lose Scene", LoadSceneMode.Single);
    }
    
}
