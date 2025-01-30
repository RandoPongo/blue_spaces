using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainSceneControl : MonoBehaviour{

    void Start(){
        StartScene();
        }

    // Start the experiment
    public void StartScene(){
        StartCoroutine(PlayMainScene());
    }

    // go to user menu
    private IEnumerator PlayMainScene(){
        // wait time
        yield return new WaitForSeconds(Global.time3);
        SceneManager.LoadScene("scene_standby");
        }

    }