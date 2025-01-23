using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserMenuController : MonoBehaviour
{
    public static UserMenuController Instance { get; private set; } // Singleton for global access

    public Button startButton; // Start button in the User Menu
    public Button escapeButton; // Escape button to return to Master Menu

    // Flags to track the state of the experiment and navigation
    public bool IsExperimentStarted { get; private set; } = false;
    public bool IsExperimentRestarted { get; private set; } = false;
    public bool IsEscapeToMasterMenu { get; private set; } = false;

    private void Awake()
    {
        // Ensure only one instance of UserMenuController exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optionally keep across scenes if needed
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    private void Start()
    {
        // Set button listeners when entering User Menu
        startButton.onClick.RemoveAllListeners(); // Remove any existing listeners
        startButton.onClick.AddListener(StartExperiment);
        
        escapeButton.onClick.RemoveAllListeners(); // Remove any existing listeners
        escapeButton.onClick.AddListener(EscapeToMasterMenu);
    }

    private void StartExperiment()
    {
        // Start experiment logic
        Debug.Log("User has started the experiment. Loading Scene A...");
        IsExperimentStarted = true;         // Flag indicating the experiment has started
        IsExperimentRestarted = true;       // Flag indicating the experiment has restarted
        IsEscapeToMasterMenu = false;       // Reset the escape flag
        SceneManager.LoadScene("scene_A");   // Load Scene A
    }

    private void EscapeToMasterMenu()
    {
        // Return to master menu logic
        Debug.Log("User has chosen to return to Master Menu...");
        IsExperimentStarted = false;        // Flag indicating the experiment has stopped
        IsExperimentRestarted = false;     // Reset the restart flag
        IsEscapeToMasterMenu = true;       // Flag indicating escape to Master Menu
        SceneManager.LoadScene("master_menu"); // Load Master Menu
    }
}
