using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene_05_Control : MonoBehaviour
{

    // private float sceneADuration = 5f; // Duration for scene_A

    void Start()
    {
        StartScene();
    }

    // Start the experiment
    public void StartScene()
    {
        StartCoroutine(PlaScene_05());
    }

    // go to user menu
    private IEnumerator PlaScene_05()
    {
        // wait here
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("menu_user");
    }

}