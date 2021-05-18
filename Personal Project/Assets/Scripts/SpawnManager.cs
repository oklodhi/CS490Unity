using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // array of obstacles
    public GameObject[] icebergObjects;

    // spawning distance Z and spawn location X
    private float spawnZDistance = 300.0f;
    private float spawnLocation = 0.0f;

    // spawn start delay and interval between each obstacle
    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;
    private float newInterval;

    // keeps track of most recent player X position
    private float playerPosition;

    // all necessary objects and scripts
    private GameManager gameManagerScript;
    private GameObject playerObject;
    private DayNightCycle dayNightCycleScript;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        playerObject = GameObject.Find("Player");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        dayNightCycleScript = GameObject.Find("Directional Light").GetComponent<DayNightCycle>();
    }

    // start spawning the obstacles
    public void ManualStart()
    {
        CancelInvoke();
        InvokeRepeating("SpawnRandomIceberg", startDelay, newInterval);
    }

    // Update is called once per frame
    void Update()
    {
        newInterval = spawnInterval / dayNightCycleScript.harder;
    }

    // spawns a random obstacle in the player's X direction
    void SpawnRandomIceberg()
    {
        int icebergType = Random.Range(0, icebergObjects.Length);
        int spawnAggression = Random.Range(1, 5);

        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position.x * 1.5f;
        }
        spawnLocation += ((playerPosition - spawnLocation) / spawnAggression);

        if (gameManagerScript.isGameActive)
        {
            if(spawnAggression == 1)
            {
                Instantiate(icebergObjects[icebergType], new Vector3(playerObject.transform.position.x * -1, 0, spawnZDistance), Quaternion.Euler(new Vector3(0, getRandomRotation(), 0)));
                InvisibleAtNight(icebergObjects[icebergType]);
            } else
            {
                Instantiate(icebergObjects[icebergType], new Vector3(spawnLocation, 0, spawnZDistance), Quaternion.Euler(new Vector3(0, getRandomRotation(), 0)));
            }
            InvisibleAtNight(icebergObjects[icebergType]);
        }
    }

    // return a random euler angle 
    float getRandomRotation()
    {
        float angle = Random.Range(0.0f, 360.0f);
        return angle;
    }

    // handles the visibility of obstacle objects depending on day and night cycle
    void InvisibleAtNight(GameObject icebergObject)
    {
        if (dayNightCycleScript.nightTime)
        {
            icebergObject.GetComponent<Renderer>().sharedMaterial.color = new Color(0.97f, 1.0f, 1.0f, 0.0f);
        }
        else if (!dayNightCycleScript.nightTime)
        {
            icebergObject.GetComponent<Renderer>().sharedMaterial.color = new Color(0.97f, 1.0f, 1.0f, 1.0f);
        }
    }
}
