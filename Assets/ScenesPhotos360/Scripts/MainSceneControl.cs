using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainSceneControl : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    void Start()
    {
        StartScene();
    }

    // Start the experiment
    public void StartScene()
    {
        StartCoroutine(PlayMainScene());
    }

    // go to scene_standby
    private IEnumerator PlayMainScene()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is not assigned in the Inspector!");
        }

        yield return new WaitForSeconds(Global.time3);
        SceneManager.LoadScene("scene_standby");
    }
}



/* using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainSceneControl : MonoBehaviour{

    public AudioSource audioSource;
    
    void Start(){
        audioSource = GetComponent<AudioSource>();
        StartScene();
        }

    // Start the experiment
    public void StartScene(){
        StartCoroutine(PlayMainScene());
    }

    // go to scene_standby
    private IEnumerator PlayMainScene(){
        // wait time
        audioSource.Play();
        yield return new WaitForSeconds(Global.time3);
        SceneManager.LoadScene("scene_standby");
        }

    } */



