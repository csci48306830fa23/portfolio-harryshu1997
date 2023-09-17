using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneSwitch : MonoBehaviour
{
    public string targetSceneName; // Name of the scene you want to load

    private void OnCollisionEnter(Collision collision)
    {
        // Check if we've collided with the player (or whatever object you're checking for)
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetSceneName);
            Debug.Log("Scene loaded: " + targetSceneName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
