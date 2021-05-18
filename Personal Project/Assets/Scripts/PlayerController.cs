using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player particle effects
    public ParticleSystem waterTrail;
    public ParticleSystem smokeTrail;

    // all necessary objects and scripts
    private Rigidbody rigidBody;

    // player movement variables
    private float turnSpeed = 100.0f;
    private float moveSpeed = 50.0f;
    public float horizontalInput;

    // player movement bounds
    private float turnAnglePosMax = 45.0f;
    private float turnAngleNegMax = 315.0f;
    private float staticPosZ = -8.0f;
    private float boundsX = 45.0f;
    private float boundY = -20.0f;

    // track player and obstacle collision
    public bool collisionOccurred = false;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        rigidBody = GetComponent<Rigidbody>();
        waterTrail = GameObject.Find("WaterTrail").GetComponent<ParticleSystem>();
        smokeTrail = GameObject.Find("EngineSmoke").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        DestroyPlayer();
    }

    void PlayerMovement()
    {
        // grab analog horizontal input from left and right arrow keys
        horizontalInput = Input.GetAxis("Horizontal");

        // if player is within X bounds and no collosion has occured
        if ((transform.position.x > -boundsX && transform.position.x < boundsX) && !collisionOccurred)
        {
            //then player should be able to slide left and right and rotate in respective direction 
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
            // and rotate in respective direction 
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            // keep the player wihtin rotation bounds
            if (transform.localEulerAngles.y < turnAngleNegMax && transform.localEulerAngles.y > 180)
            {
                transform.rotation = Quaternion.Euler(0, turnAngleNegMax + .01f, 0);
            }
            else if (transform.localEulerAngles.y > turnAnglePosMax && transform.localEulerAngles.y < 180)
            {
                transform.rotation = Quaternion.Euler(0, turnAnglePosMax + .01f, 0);
            }

            // automatically straighten the player if there is no movement
            if (horizontalInput == 0 && (transform.localEulerAngles.y > 0 || transform.localEulerAngles.y < 360))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), turnSpeed/moveSpeed * Time.deltaTime);
            }
        }

        // make sure player is always within X bounds
        if (transform.position.x < -boundsX)
        {
            transform.position = new Vector3(-boundsX + .01f, transform.position.y, transform.position.y);
        }
        else if (transform.position.x > boundsX)
        {
            transform.position = new Vector3(boundsX - .01f, transform.position.y, transform.position.z);
        }

        // keep the player in the same Z point
        if (transform.position.z > staticPosZ || transform.position.z < -staticPosZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, staticPosZ);
        }
    }

    // on collision, turn on gravity and stop smoke particle effect
    public void AddGravityOnCollision()
    {
        rigidBody.useGravity = true;
        smokeTrail.Stop();
    }

    // when the player sinks, destroy the player game object
    void DestroyPlayer()
    {
        if (gameObject.transform.position.y < boundY)
        {
            Destroy(gameObject);
        }
    }

    // play the boat particle effects
    public void PlayParticleSystems()
    {
        waterTrail.Clear();
        smokeTrail.Clear();
        if (!waterTrail.isPlaying)
        {
            waterTrail.Play();
        }
        if (!smokeTrail.isPlaying)
        {
            smokeTrail.Play();
        }
    }
}
