using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // all necessary objects and scripts
    public AudioSource audioSource;

    public AudioClip mainMenuAudio;
    public AudioClip gamePlayAudio;
    public AudioClip gameOverAudio;

    // Start is called before the first frame update
    void Start()
    {
        // set the game audio source
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
