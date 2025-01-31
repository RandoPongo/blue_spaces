using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller_Scene_A : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine to play the scene and then transition to the next scene
        // audioSource.Play();
        StartCoroutine(PlayScene_A());
    }

    private IEnumerator PlayScene_A()
    {
        // Wait for the time based on the value from Global.time2
        yield return new WaitForSeconds(Global.time2);

        // Load the scene based on the user's selected option
        string sceneToLoad = GetSceneName(Global.selectedOption);
        Debug.Log("Selected Option: " + Global.selectedOption);
        Debug.Log("Scene to Load: " + sceneToLoad);

        // Load the scene corresponding to the user's selection
        SceneManager.LoadScene(sceneToLoad);
    }

    // Map the selected option to the actual scene name
    private string GetSceneName(string selectedOption)
    {
        // Example mapping logic (customize as needed):
        switch (selectedOption)
        {
            case "Rio Azul":
                return "scene_01";
            case "Rio Verde":
                return "scene_02";
            case "Lago Azul":
                return "scene_03";
            case "Lago Verde":
                return "scene_04";
            case "Mar Azul":
                return "scene_05";
            case "Mar Verde":
                return "scene_06";
            default:
                return "scene_01";  // Fallback to a default scene if nothing matches
        }
    }
}