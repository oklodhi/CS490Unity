using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    // oscillation range
    private float degreesPerSecond = 10.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // oscillates the logos and gives an animation to the images
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.fixedTime * degreesPerSecond, 40) - 20, 0);
    }
}
