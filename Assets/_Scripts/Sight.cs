using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayer;
    public LayerMask obstacleLayer;

    public Collider detectedTarget;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,distance, targetLayer);
        // First filter passed: DISTANCE

        detectedTarget = null;

        foreach(Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);

            // The angle that the View Vector forms with the Target Vector.
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            // If the angle is less than the angle of vision...
            if(angleToCollider < angle)
            {   
                // Check that there are no obstacles in the enemy's line of sight to the target
                if(!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstacleLayer))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    
                    detectedTarget = collider; // Save the reference of the detected enemy
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.yellow;
        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);

        Gizmos.color = Color.yellow;
        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }
}
