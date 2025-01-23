using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private float sceneADuration = 5f; // Duration for scene_A
    private float mainSceneDuration = 10f; // Duration for scene_01

    void Start()
    {
        // Set button listeners
        startButton.onClick.AddListener(HandControlToUser);
        quitButton.onClick.AddListener(QuitExperiment);
    }


    // Start the experiment
    public void HandControlToUser()
    {
        SceneManager.LoadScene("menu_user");
    }


    // Quit the application
    public void QuitExperiment()
    {
        Application.Quit();
    }
}
