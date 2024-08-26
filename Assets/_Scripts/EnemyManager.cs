using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstace;

    public List<Enemy> enemies;

    void Awake()
    {
        if(SharedInstace == null)
        {
            SharedInstace = this;
            enemies = new List<Enemy>();
        }
        else
        {
            Destroy(this);
        }
    }

    

    
    void Update()
    {
        
    }
}
