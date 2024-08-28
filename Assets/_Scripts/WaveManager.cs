using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    private List<WaveSpawner> waves;

    public UnityEvent onWaveChanged;

    public int WavesCount
    {
        get => waves.Count;
    }

    private int maxWaves;

    public int MaxWaves
    {
        get => maxWaves;
    }

    void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
            waves = new List<WaveSpawner>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddWave(WaveSpawner wave)
    {
        maxWaves++;
        waves.Add(wave);
        onWaveChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onWaveChanged.Invoke();
    }
}
