using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UserController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    void Start()
    {
        // Set button listeners
        startButton.onClick.AddListener(StartScenes);
        quitButton.onClick.AddListener(BackToMaster);
    }


    // Start the experiment
    public void StartScenes()
    {
        SceneManager.LoadScene("scene_A");
    }


    // Quit the application
    public void BackToMaster()
    {
        SceneManager.LoadScene("menu_master");
    }
}
