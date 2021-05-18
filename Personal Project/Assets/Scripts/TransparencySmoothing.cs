using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencySmoothing : MonoBehaviour
{
    // all necessary objects and scripts
    public Image image;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        // get the objects and script references from scene
        image.GetComponent<Image>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // ping pong the contol's image alpha (transparency)
        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(0.1f, .5f, Mathf.PingPong(Time.time / 2, 1.0f)));
        
        // move the control's image with the player object
        Vector3 tempPosition = Camera.main.WorldToScreenPoint(playerObject.transform.position);
        image.transform.position = new Vector3(tempPosition.x, image.transform.position.y, image.transform.position.z);
    }
}
