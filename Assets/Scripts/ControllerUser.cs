using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UserController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    void Start(){
        // Set button listeners
        startButton.onClick.AddListener(StartScenes);
        quitButton.onClick.AddListener(BackToMaster);
        }


    // Start the experiment
    public void StartScenes()
    {
        SceneManager.LoadScene("scene_B");
    }

    // Quit the application
    public void BackToMaster()
    {
        // Global.time1 = 60; // mudar no fim para 60
        // Global.time2 = 60; // mudar no fim para 180
        // Global.time3 = 180; // mudar no fim para 180
        // reset scene name
        SceneManager.LoadScene("menu_master");
    }
}
