using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // obstacle movement speed
    public float speed = 40.0f;

    // obstacle bounds for Z and Y
    private float boundZ = -40.0f;
    private float boundY = -20.0f;

    // all necessary objects and scripts
    private GameObject spawnManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        spawnManagerObject = GameObject.Find("SpawnManager");
    }

    // Update is called once per frame
    void Update()
    {
        // moves the obstacles in the player's direction
        transform.position = Vector3.MoveTowards(transform.position, spawnManagerObject.transform.position, speed * Time.deltaTime);
        DestroyExtraObjects();
    }

    // destroy all other game objects in the scene
    void DestroyExtraObjects()
    {
        if(gameObject.transform.position.z < boundZ || gameObject.transform.position.y < boundY)
        {
            Destroy(gameObject);
        }
    }
}
