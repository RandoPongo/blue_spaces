using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneBControl : MonoBehaviour{
    void Start(){
        StartCoroutine(PlaySceneB());
        }


    private IEnumerator PlaySceneB()
    {
        // Wait time 1
        yield return new WaitForSeconds(Global.time1);

        // Load scene A
        SceneManager.LoadScene("scene_A");
    }
}