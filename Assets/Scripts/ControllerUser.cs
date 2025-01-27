using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UserController : MonoBehaviour{
    
    void Start(){
        // Start the experiment after clicking remotely in PC app (TODO)
        StartCoroutine(StartUserHome());
        }

    private IEnumerator StartUserHome(){
        yield return new WaitForSeconds(Global.time0);
        SceneManager.LoadScene("scene_B");
        }   

    }   
