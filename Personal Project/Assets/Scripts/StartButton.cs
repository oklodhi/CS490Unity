using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // all necessary objects and scripts
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on button play click, game will start
    void StartGame()
    {
        gameManager.StartGame();
        gameManager.UpdateScore();
    }
}
