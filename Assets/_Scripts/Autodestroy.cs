using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Time after which the laser is destroyed")]
    private float delay;
    
    void OnEnable()
    {
        Invoke("HideObject", delay); 
    }

    /// <summary>
    /// Method that hides the object instantiated by "GetFirstPooledObject()", stored in "bullet" variable
    /// </summary>
    private void HideObject()
    {
        gameObject.SetActive(false); // Desable the object
    }
}
