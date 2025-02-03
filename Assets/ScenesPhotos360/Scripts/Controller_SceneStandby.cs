using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller_SceneStandby : MonoBehaviour{
    public Button startButton;
    public Button backButton;
    
    void Start(){
        startButton.onClick.AddListener(StartBaseline);
        backButton.onClick.AddListener(StartGoBack);
        }

    void StartBaseline(){
        SceneManager.LoadScene("scene_B");
        }

    void StartGoBack(){
        SceneManager.LoadScene("menu_master");
        }    

}



 
