using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform door;  
    public float moveDistance = 3.0f; 
    public float transitionSpeed = 2.0f; 
    public float openCloseThreshold = 0.1f; 

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isPlayerNear;

    public float timeToTrigger = 0.5f; 

    private float enterTime; 


    void Start()
    {
        closedPosition = door.position;
        openPosition = door.position + door.right * moveDistance; 
    }

    void Update()
    {
        Vector3 targetPosition = isPlayerNear ? openPosition : closedPosition;

        if (Vector3.Distance(door.position, targetPosition) > openCloseThreshold)
        {
            door.position = Vector3.Lerp(door.position, targetPosition, Time.deltaTime * transitionSpeed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTime = Time.time;
            StartCoroutine(CheckPlayerInTrigger());
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(CheckPlayerInTrigger());
            isPlayerNear = false;
            
        }
    }

    IEnumerator CheckPlayerInTrigger()
    {
        yield return new WaitForSeconds(timeToTrigger);
        if (Time.time - enterTime >= timeToTrigger)
        {
            isPlayerNear = true;
        }
    }
}
