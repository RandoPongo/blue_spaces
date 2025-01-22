using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement; // For scene management
using System.Collections;

public class MasterMenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField sceneADurationField; // Input for Scene A duration
    [SerializeField] private TMP_InputField scenes1To6DurationField; // Input for Scenes 1-6 duration
    [SerializeField] private TMP_Dropdown sceneDropdown; // TMP_Dropdown for selecting Scene 1-6
    [SerializeField] private Button startButton; // Button to start the sequence
    [SerializeField] private Button quitButton; // Button to quit the application

    private int sceneADuration;
    private int scenes1To6Duration;

    private void Start()
    {
        // Ensure the input fields only accept integers
        sceneADurationField.contentType = TMP_InputField.ContentType.IntegerNumber;
        scenes1To6DurationField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // Set button listeners
        startButton.onClick.AddListener(StartExperiment);
        quitButton.onClick.AddListener(QuitApplication);
    }

    private void StartExperiment()
    {
        // Parse integer values from input fields
        if (int.TryParse(sceneADurationField.text, out sceneADuration) &&
            int.TryParse(scenes1To6DurationField.text, out scenes1To6Duration))
        {
            Debug.Log($"Starting experiment:\nScene A Duration: {sceneADuration} seconds\nScenes 1-6 Duration: {scenes1To6Duration} seconds");

            // Start the experiment sequence, first go to User Menu
            StartCoroutine(ExperimentSequence());
        }
        else
        {
            Debug.LogError("Please enter valid integers for the duration fields!");
        }
    }

    // Coroutine to handle the sequence of scenes
    private IEnumerator ExperimentSequence()
    {
        // 1. Go to User Menu
        Debug.Log("Loading User Menu...");
        SceneManager.LoadScene("UserMenu"); // Load User Menu scene
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "UserMenu");

        // Wait for the user to press the "Start" button in the User Menu (handle this in UserMenu script)
        yield return new WaitUntil(() => UserMenuController.Instance.IsExperimentStarted);

        // 2. Load Scene A and play for the inserted duration
        Debug.Log("Loading Scene A...");
        SceneManager.LoadScene("SceneA"); // Load Scene A
        yield return new WaitForSeconds(sceneADuration); // Wait for the specified duration

        // 3. Load the selected scene (1-6) and play for the inserted duration
        string selectedScene = sceneDropdown.options[sceneDropdown.value].text;
        Debug.Log($"Loading Scene {selectedScene}...");
        SceneManager.LoadScene(selectedScene); // Load the selected scene by name
        yield return new WaitForSeconds(scenes1To6Duration); // Wait for the specified duration

        // 4. Go back to User Menu for start/exit
        Debug.Log("Loading User Menu for next action...");
        SceneManager.LoadScene("UserMenu"); // Load User Menu scene
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "UserMenu");

        // Wait for the user to press the "Start" button again or "Escape" to go back to Master Menu
        yield return new WaitUntil(() => UserMenuController.Instance.IsExperimentRestarted || UserMenuController.Instance.IsEscapeToMasterMenu);

        // 5. Return to the Master Menu if Escape is pressed
        if (UserMenuController.Instance.IsEscapeToMasterMenu)
        {
            Debug.Log("Returning to Master Menu...");
            SceneManager.LoadScene("MasterMenu"); // Load Master Menu scene
        }
        else
        {
            // Otherwise, restart the experiment (loop through the User Menu again)
            StartCoroutine(ExperimentSequence());
        }
    }

    private void QuitApplication()
    {
        Debug.Log("Quitting application...");
        Application.Quit();
    }
}


