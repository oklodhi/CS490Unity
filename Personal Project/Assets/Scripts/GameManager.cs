using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // time in seconds for audio delay before playing sound
    private float audioDelaySeconds = 1.0f;

    // keep track of if the game is active and being played
    public bool isGameActive;

    // all necessary objects and scripts
    public TextMeshProUGUI scoreText;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject scoreHandler;

    public Button playAgainButton;

    private SpawnManager spawnManagerScript;
    private AudioController audioControllerScript;
    private PlayerController playerControllerScript;
    private DayNightCycle dayNightCycleScript;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audioControllerScript = GameObject.Find("Main Camera").GetComponent<AudioController>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        dayNightCycleScript = GameObject.Find("Directional Light").GetComponent<DayNightCycle>();

        // setting game resolution
        ScreenResize();
    }

    // adjusts the resolution size 
    private void ScreenResize()
    {
        Screen.SetResolution(875, 460, false, 60);
    }

    public void StartGame()
    {
        // starts playing the game and sets flags and screens as active/inactive
        spawnManagerScript.ManualStart();
        scoreHandler.SetActive(true);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);

        // change gameplay music
        UpdateBackgroundMusic(audioControllerScript);

        // start playing player's particle systems
        playerControllerScript.PlayParticleSystems();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    //update gameplay music sources
    public void UpdateBackgroundMusic(AudioController ac)
    {
        ac.audioSource.Stop();
        ac.audioSource.clip = audioControllerScript.gamePlayAudio;
        ac.audioSource.PlayDelayed(audioDelaySeconds);
    }

    // updates score time in textmesh GUI
    public void UpdateScore()
    {
        if (isGameActive)
        {
            //float timer = Time.time - initialTime;

            //int minutes = (int)timer / 60000;
            //int seconds = (int)timer / 1000 - 60 * minutes;
            //int milliseconds = (int)timer - minutes * 60000 - 1000 * seconds;

            scoreText.SetText("Day at Sea: {0}", dayNightCycleScript.dayNightCycleCount);
        }
    }

    // display game over screen when the game is over
    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }
}
