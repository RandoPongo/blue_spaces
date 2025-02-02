using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Controller_SceneStandby : MonoBehaviour{
    public Button startButton;
    
    void Start(){
        startButton.onClick.AddListener(StartBaseline);
        }

    void StartBaseline(){
        SceneManager.LoadScene("scene_B");
        }

}



 
