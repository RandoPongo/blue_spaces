


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float sceneDuration = 5.0f; // Default duration for each scene

    private string finalSceneName;

    private void Start()
    {
        // Retrieve the final scene name from PlayerPrefs
        
        // ------------------------------------------------------------------------
        // /!\ >> SELECT GameObjectMenu and SET SCENE for build in Inspector << /!\
        // ------------------------------------------------------------------------
        // also remove uneeded scenes from build settings

        finalSceneName = PlayerPrefs.GetString("FinalScene", "SceneC_rio_azul");
        Invoke("LoadNextScene", sceneDuration);
    }

    private void Update()
    {
        // Check for "Esc" key press to skip scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipScene();
        }
    }

    private void LoadNextScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "SceneA")
        {
            SceneManager.LoadScene("SceneB");
        }
        else if (currentSceneName == "SceneB")
        {
            SceneManager.LoadScene(finalSceneName);
        }
        else if (currentSceneName == finalSceneName)
        {
            SceneManager.LoadScene("menu");
        }
    }

    public void SkipScene()
    {
        // Cancel the automatic scene load timer
        CancelInvoke("LoadNextScene");

        // Load the next scene immediately
        LoadNextScene();
    }
}



// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SceneController : MonoBehaviour
// {
//     public float sceneDuration = 5.0f; // Default duration for each scene

//     private string finalSceneName;

//     private void Start()
//     {
//         // Retrieve the final scene name from PlayerPrefs
//         finalSceneName = PlayerPrefs.GetString("FinalScene", "SceneC_rio_azul");
//         Invoke("LoadNextScene", sceneDuration);
//     }

//     private void LoadNextScene()
//     {
//         string currentSceneName = SceneManager.GetActiveScene().name;

//         if (currentSceneName == "SceneA")
//         {
//             SceneManager.LoadScene("SceneB");
//         }
//         else if (currentSceneName == "SceneB")
//         {
//             SceneManager.LoadScene(finalSceneName);
//         }
//         else if (currentSceneName == finalSceneName)
//         {
//             SceneManager.LoadScene("menu");
//         }
//     }
// }
