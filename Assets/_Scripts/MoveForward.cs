using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    private float speed;
    
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
