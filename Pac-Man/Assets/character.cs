using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //movement speed in units per second
    public float movementSpeed = 5f;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(0,horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime);

        //output to log the position change
        Debug.Log(transform.position);
        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);
    }
}
