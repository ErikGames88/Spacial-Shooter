using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player movement velocity: meters/second")]
    [Range(0, 10)]
    private float speed;

    [SerializeField]
    [Tooltip("Player rotation velocity: degrees/second")]
    [Range(0, 10)]
    private float rotationSpeed;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        // Space = Velocity * Time
        float space = speed * Time.deltaTime;
        
        float horizontal = Input.GetAxis("Horizontal"); // From -1 to 1
        float vertical = Input.GetAxis("Vertical"); // From -1 to 1

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction.normalized * space);

        float angle = rotationSpeed * Time.deltaTime;
        float cameraHorizontal = Input.GetAxis("Camera Horizontal");
        float cameraVertical = Input.GetAxis("Camera Vertical");

        transform.Rotate(0, cameraHorizontal * angle, 0);
        

        /*if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0,space);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,0,-space);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(space,0,0);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-space,0,0);
        }*/
    }
}
