using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainSceneControl : MonoBehaviour
{

    // private float sceneADuration = 5f; // Duration for scene_A

    void Start()
    {
        StartScene();
    }

    // Start the experiment
    public void StartScene()
    {
        StartCoroutine(PlayMainScene());
    }

    // go to user menu
    private IEnumerator PlayMainScene()
    {
        // wait here
        yield return new WaitForSeconds(Global.time2);
        SceneManager.LoadScene("menu_user");
    }

}