using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource; 
    private float interval = 120f; 

    private void Start()
    {
        // Inicia la corrutina
        StartCoroutine(PlayThunderAtIntervals());
    }

    private IEnumerator PlayThunderAtIntervals()
    {
        while (true) // Ejecuta de manera infinita
        {
            _audioSource.Play(); // Reproduce el trueno
            yield return new WaitForSeconds(interval); // Espera el intervalo antes de reproducir nuevamente
        }
    }
}
