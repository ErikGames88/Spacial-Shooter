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
        StartCoroutine(PlayThunderAtIntervals());
    }

    private IEnumerator PlayThunderAtIntervals()
    {
        while (true) 
        {
            _audioSource.Play(); 
            yield return new WaitForSeconds(interval); 
        }
    }
}
