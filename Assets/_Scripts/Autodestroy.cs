using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField]
    private float delay;
    
    void OnEnable()
    {
        Invoke("HideObject", delay); 
    }
    private void HideObject()
    {
        gameObject.SetActive(false); 
    }
}
