using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // all necessary objects and scripts
    private GameManager gameManagerScript;
    private AudioController audioControllerScript;
    private PlayerController playerControllerScript;

    // array of obstacles
    GameObject[] icebergObjects;

    // Start is called before the first frame update
    void Start()
    {
        GetScriptControllers();
    }

    // get the objects and script references from scene
    void GetScriptControllers()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioControllerScript = GameObject.Find("Main Camera").GetComponent<AudioController>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        icebergObjects = GameObject.FindGameObjectsWithTag("Iceberg");
    }

    // check for collision between player and obstacles
    private void OnCollisionEnter(Collision other)
    {
        if (playerControllerScript.collisionOccurred)
        {
            return;
        }

        // collision routine
        SetCollisionFlags();
        ChangeCollisionAudio();
        TurnOnGravity();
        gameManagerScript.GameOver();
    }

    // change audio source when collision happens
    void ChangeCollisionAudio()
    {
        audioControllerScript.audioSource.Stop();
        audioControllerScript.audioSource.clip = audioControllerScript.gameOverAudio;
        audioControllerScript.audioSource.Play();
    }

    // set collision flags in reference scripts
    void SetCollisionFlags()
    {
        playerControllerScript.collisionOccurred = true;
        gameManagerScript.isGameActive = false;
    }

    // turn on gravity for all obstacles in the scene
    void TurnOnGravity()
    {
        playerControllerScript.AddGravityOnCollision();
        for(int i = 0; i < icebergObjects.Length; i++)
        {
            if (icebergObjects[i] != null)
            {
                icebergObjects[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
