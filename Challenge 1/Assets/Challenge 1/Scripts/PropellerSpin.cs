using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    private float speed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spin the propeller
        transform.Rotate(Vector3.forward * Time.deltaTime * speed); //rotates 50 degrees per second around z axis
    }
}
