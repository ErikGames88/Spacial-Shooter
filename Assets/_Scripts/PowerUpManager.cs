using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartPowerUp(GameObject powerUp, float duration)
    {
        StartCoroutine(HandlePowerUp(powerUp, duration));
    }

    private IEnumerator HandlePowerUp(GameObject powerUp, float duration)
    {
        powerUp.SetActive(false);

        yield return new WaitForSeconds(duration);
        Destroy(powerUp);
    }
}
