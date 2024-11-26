using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLocation : MonoBehaviour
{
    private string sceneKey; // Key for the current scene

    void Start()
    {
        // Get the current scene's name
        string sceneName = SceneManager.GetActiveScene().name;

        // Create a unique key for this scene
        sceneKey = $"{sceneName}_Position";

        // Load the position for this scene if it exists
        if (PlayerPrefs.HasKey($"{sceneKey}_x"))
        {
            float x = PlayerPrefs.GetFloat($"{sceneKey}_x");
            float y = PlayerPrefs.GetFloat($"{sceneKey}_y");
            float z = PlayerPrefs.GetFloat($"{sceneKey}_z");
            transform.position = new Vector3(x, y, z);
        }
    }

    void Update()
    {
        // Save the position for this specific scene
        PlayerPrefs.SetFloat($"{sceneKey}_x", transform.position.x);
        PlayerPrefs.SetFloat($"{sceneKey}_y", transform.position.y);
        PlayerPrefs.SetFloat($"{sceneKey}_z", transform.position.z);
    }
}
