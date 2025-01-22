using UnityEngine;
using UnityEngine.UI;

public class UserMenuController : MonoBehaviour
{
    public static UserMenuController Instance { get; private set; } // Singleton for easy access
    public Button startButton; // Start button in the User Menu
    public Button escapeButton; // Escape button to return to Master Menu

    public bool IsExperimentStarted { get; private set; } = false; // Flag to track if the experiment started
    public bool IsExperimentRestarted { get; private set; } = false; // Flag for restarting the experiment
    public bool IsEscapeToMasterMenu { get; private set; } = false; // Flag for escaping to Master Menu

    private void Awake()
    {
        // Ensure there is only one instance of UserMenuController
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        // Set button listeners
        startButton.onClick.AddListener(StartExperiment);
        escapeButton.onClick.AddListener(EscapeToMasterMenu);
    }

    private void StartExperiment()
    {
        // Set the flag to true when the user clicks "Start"
        IsExperimentStarted = true;
        IsExperimentRestarted = true;
        Debug.Log("User has started the experiment.");
    }

    private void EscapeToMasterMenu()
    {
        // Set the flag to return to Master Menu when Escape is clicked
        IsEscapeToMasterMenu = true;
        Debug.Log("User has chosen to return to Master Menu.");
    }
}
