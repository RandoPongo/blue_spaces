
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this to resolve the IEnumerator error

public class NetworkListenerSimpler : MonoBehaviour
{
    private bool isRunning = false;

    void Start()
    {
        StartServer();
    }

    void StartServer()
    {
        // Simulate server listening logic here
        isRunning = true;
        // For example, simulate receiving a command:
        string command = "change_scene:scene_B";
        HandleCommand(command);
    }

    void HandleCommand(string command)
    {
        if (command.StartsWith("change_scene:"))
        {
            string sceneName = command.Split(':')[1];
            Debug.Log("Received command: " + command);
            // Call the coroutine to load the scene on the main thread
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        else
        {
            Debug.LogWarning("Unknown command: " + command);
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Optionally, you can display a loading screen or do other things here
        Debug.Log("Loading scene: " + sceneName);
        yield return null; // Wait for one frame, ensuring the load is done on the main thread
        SceneManager.LoadScene(sceneName); // Load the scene
    }
}



