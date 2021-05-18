using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    // all necessary objects and scripts
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on button retart click, reload the scene to play again
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
