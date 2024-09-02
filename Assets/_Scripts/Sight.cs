using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayer;
    public LayerMask obstacleLayer;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,distance, targetLayer);
        // First filter passed: DISTANCE

        foreach(Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - this.transform.position);

            float angleToCollider = Vector3.Angle(this.transform.forward, directionToCollider);
        }

        /*
        for(int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
        }
        */
    }
}
