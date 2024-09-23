using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2000)]
    private float speed;
    
    [SerializeField]
    [Range(0, 100)]
    private float rotationSpeed;

    private Rigidbody _rigidbody;

    private Animator _animator;

    private AudioSource steepsAudio;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        steepsAudio = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        // Space = Velocity * Time
        float space = speed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal"); // From -1 to 1
        float vertical = Input.GetAxis("Vertical"); // From -1 to 1
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        // TRANSLATION FORCE
        _rigidbody.AddRelativeForce(direction.normalized * space);
        
        float angle = rotationSpeed * Time.deltaTime;
        float cameraHorizontal = Input.GetAxis("Camera Horizontal");
        float cameraVertical = Input.GetAxis("Camera Vertical");
        
        // ROTATION FORCE (TORQUE)
        _rigidbody.AddRelativeTorque(0, cameraHorizontal * angle, 0);
        
        _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);

        if (_rigidbody.velocity.magnitude > 0.1f) 
        {
            if (!steepsAudio.isPlaying)
            {
                steepsAudio.Play(); 
            }
        }
        else 
        {
            if (steepsAudio.isPlaying)
            {
                steepsAudio.Stop(); 
            }
        }
    }
}
