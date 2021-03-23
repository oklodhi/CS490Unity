using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 15.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the vehicle forward based on the vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // rotates the car based on the horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
    }
}
