using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player force movement velocity: N/s")]
    [Range(0, 2000)]
    private float speed;

    [SerializeField]
    [Tooltip("Player force rotation velocity: N/s")]
    [Range(0, 100)]
    private float rotationSpeed;

    private Rigidbody rb;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        // Space = Velocity * Time
        float space = speed * Time.deltaTime;
        
        float horizontal = Input.GetAxis("Horizontal"); // From -1 to 1
        float vertical = Input.GetAxis("Vertical"); // From -1 to 1
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        //transform.Translate(direction.normalized * space);
        
        // TRANSLATION FORCE
        rb.AddRelativeForce(direction.normalized * space);
        
        float angle = rotationSpeed * Time.deltaTime;
        float cameraHorizontal = Input.GetAxis("Camera Horizontal");
        //float cameraVertical = Input.GetAxis("Camera Vertical");
        //transform.Rotate(0, cameraHorizontal * angle, 0);
        
        // ROTATION FORCE (TORQUE)
        rb.AddRelativeTorque(0, cameraHorizontal * angle, 0);
    }

    void Update()
    {
        
        

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
