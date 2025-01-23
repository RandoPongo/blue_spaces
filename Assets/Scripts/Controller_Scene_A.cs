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
        StartCoroutine(PlaScene());
    }

    // go to user menu
    private IEnumerator PlaScene()
    {
        // wait here
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("scene_05");
    }

}