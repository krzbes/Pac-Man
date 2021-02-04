using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement: MonoBehaviour
{
    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    //movement speed in units per second
    public float movementSpeed = 5f, horizontalSpeed = 2f;

    void Update()
    {
        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        _characterController.Move(move * movementSpeed * Time.deltaTime);

        //turn direction of camera
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Teleport_A"))
        {
            Vector3 position = transform.position;
            transform.position= new Vector3(-110f, position.y,position.z);
        }
        if (other.CompareTag("Teleport_B"))
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(110f, position.y, position.z);
        }
    }

}
