using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollider : MonoBehaviour
{
    // all necessary objects and scripts
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the objects and script references from scene
        playerObject = GameObject.Find("Player");
    }

    // when obstacles enter the cone mesh collider of spotlight
    // then reveal the obstacles
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.color = new Color(0.97f, 1.0f, 1.0f, 1.0f);
    }

    // when obstacles leave the cone mesh collider of spotlight
    // then either hide or stay revealing the obstacles
    private void OnTriggerExit(Collider other)
    {
        float distance = Vector3.Distance(other.transform.position, playerObject.transform.position);
        if (distance > 35)
        {
            other.GetComponent<Renderer>().material.color = new Color(0.97f, 1.0f, 1.0f, 0.0f);
        }
    }
}
