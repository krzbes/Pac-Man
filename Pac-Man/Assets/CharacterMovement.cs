using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement: MonoBehaviour
{
    private Rigidbody _rigidbody;
    private CharacterController _characterController;

    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    //movement speed in units per second
    public float movementSpeed = 5f, horizontalSpeed = 2f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        _characterController.Move(move * movementSpeed * Time.deltaTime);

        //turn direction of camera
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
    
}
