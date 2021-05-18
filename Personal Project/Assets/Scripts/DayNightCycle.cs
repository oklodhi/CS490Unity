using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // all necessary objects and scripts
    public GameObject directionalSunlight;
    public GameObject shipLight;
    private GameManager gameManagerScript;
    private SpawnManager spawnManagerScript;

    // variables for day night cycle
    private bool dayNightCycleComplete;
    public bool nightTime;
    public int dayNightCycleCount = -1;

    // difficulty level that is increased with each day night cycle
    public float harder = 1;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        directionalSunlight = GameObject.Find("Directional Light");
        shipLight = GameObject.Find("ShipSpotlight");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DayNightTimeCycle();
    }

    // controls the day and night time cycle logic
    void DayNightTimeCycle()
    {
        if(gameManagerScript.isGameActive && directionalSunlight.transform.eulerAngles.x >= 0 && directionalSunlight.transform.eulerAngles.x <= 180 && shipLight != null)
        {
            directionalSunlight.transform.Rotate(10 * Time.deltaTime, 0, 0);
            shipLight.SetActive(false);
            nightTime = false;
            incrementDayNightCount();
        } else if (directionalSunlight.transform.eulerAngles.x > 180 && directionalSunlight.transform.eulerAngles.x < 360 && shipLight != null)
        {
            directionalSunlight.transform.Rotate(20 * Time.deltaTime, 0, 0);
            shipLight.SetActive(true);
            nightTime = true;
        }

        if(directionalSunlight.transform.eulerAngles.x > 350 && directionalSunlight.transform.eulerAngles.x < 360)
        {
            dayNightCycleComplete = true;
        }
    }

    // increment the day count that is used for score
    void incrementDayNightCount()
    {
        if (dayNightCycleComplete)
        {
            dayNightCycleCount++;
            dayNightCycleComplete = false;
            harder += 0.1f;
            spawnManagerScript.ManualStart();
        }
    }
}
