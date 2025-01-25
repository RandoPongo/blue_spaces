using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAControl : MonoBehaviour
{
    // private float sceneADuration = 5f; // Duration for scene_A

    void Start()
    {
        StartScenes();
    }

    // Start the experiment
    public void StartScenes()
    {
        StartCoroutine(PlaySceneA());
    }

    // Go to user menu
    private IEnumerator PlaySceneA()
    {
        // Wait for the time based on the value from Global.time1
        yield return new WaitForSeconds(Global.time1);

        // Load the scene based on the user's selected option
        // The scene name is stored in Global.selectedOption, which should contain a valid scene name
        string sceneToLoad = GetSceneName(Global.selectedOption);
        
        // Load the scene corresponding to the user's selection
        SceneManager.LoadScene(sceneToLoad);
    }

    // Map the selected option to the actual scene name
    private string GetSceneName(string selectedOption)
    {
        // You can implement your custom logic here to map the selected option to an actual scene name.
        // For example, the selected option might be something like "Scene 1", but the actual scene might be "scene_01".
        
        // Example mapping logic (customize as needed):
        switch (selectedOption)
        {
            case "Rio Azul":
                return "scene_01";  // Map "Scene 1" to "scene_01"
            case "Rio Verde":
                return "scene_02";  // Map "Scene 2" to "scene_02"
            case "Lago Azul":
                return "scene_03";  // Map "Scene 3" to "scene_03"
            case "Lago Verde":
                return "scene_04";  // Map "Scene 4" to "scene_04"
            case "Mar Azul":
                return "scene_05";  // Map "Scene 4" to "scene_04"
            case "Mar Verde":
                return "scene_06";  // Map "Scene 4" to "scene_04"
            default:
                return "scene_01";  // Fallback to a default scene if nothing matches
        }
    }
}


/* using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAControl : MonoBehaviour
{

    // private float sceneADuration = 5f; // Duration for scene_A

    void Start()
    {
        StartScenes();
    }



    // Start the experiment
    public void StartScenes()
    {
        StartCoroutine(PlaySceneA());
    }

    // go to user menu
    private IEnumerator PlaySceneA()
    {
        // wait here
        yield return new WaitForSeconds(Global.time1);
        SceneManager.LoadScene("scene_");
    }

} */