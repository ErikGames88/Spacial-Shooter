using System;
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

    private Rigidbody _rigidbody;

    private Animator _animator;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
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
        _rigidbody.AddRelativeForce(direction.normalized * space);
        
        float angle = rotationSpeed * Time.deltaTime;
        float cameraHorizontal = Input.GetAxis("Camera Horizontal");
        //float cameraVertical = Input.GetAxis("Camera Vertical");
        //transform.Rotate(0, cameraHorizontal * angle, 0);
        
        // ROTATION FORCE (TORQUE)
        _rigidbody.AddRelativeTorque(0, cameraHorizontal * angle, 0);


        _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);
        
        /*_animator.SetFloat("Move X", horizontal);
        _animator.SetFloat("Move Y", vertical);

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);
        }
        else
        {
            if(Math.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01f)
            {
                _animator.SetFloat("Velocity", 0);
            }
            else
            {
                _animator.SetFloat("Velocity", 0.15f);
            }
        }*/

    }

    
        
        

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
