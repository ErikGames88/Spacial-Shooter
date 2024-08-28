using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    private List<Enemy> enemies;

    public int EnemyCount
    {
        get => enemies.Count;
    }

    [Tooltip("Enemy added or destroyed")]
    public UnityEvent onEnemyChanged; 

    void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
            enemies = new List<Enemy>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onEnemyChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);  
        onEnemyChanged.Invoke();
    }

}
