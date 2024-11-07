

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string finalSceneName = "SceneC_rio_azul"; // Default final scene

    public void StartSequence()
    {
        PlayerPrefs.SetString("FinalScene", finalSceneName);
        SceneManager.LoadScene("SceneA");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
