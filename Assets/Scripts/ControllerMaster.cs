
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public TMP_InputField time1InputField;  // For time1 input field
    public TMP_InputField time2InputField;  // For time2 input field
    public TMP_Dropdown dropdown;           // For dropdown selection

    // Create a list of display names and corresponding scene names
    private string[] sceneDisplayNames = { "Rio Azul", "Rio Verde", "Lago Azul", "Lago Verde", "Mar Azul", "Mar Verde" };
    private string[] sceneNames = { "scene_01", "scene_02", "scene_03", "scene_04", "scene_0", "scene_06" };

    void Start()
    {
        // Set button listeners
        startButton.onClick.AddListener(HandControlToUser);
        quitButton.onClick.AddListener(QuitExperiment);

        // Initialize the input fields and dropdown with the current values
        InitializeMenuValues();

        // Populate dropdown with display names
        PopulateDropdown();
    }

    // Populate the dropdown with display names, linking them to scene names
    private void PopulateDropdown()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(sceneDisplayNames));  // Add user-friendly names to dropdown
    }

    // Initialize the input fields and dropdown with values from Global
    private void InitializeMenuValues()
    {
        time1InputField.text = Global.time1.ToString();   // Set time1 from Global
        time2InputField.text = Global.time2.ToString();   // Set time2 from Global
        dropdown.value = GetDropdownIndex(Global.selectedOption);  // Set dropdown value from Global
    }

    // Convert selected option in Global to dropdown index
    private int GetDropdownIndex(string selectedOption)
    {
        // Find the index of the selected option in the dropdown list
        for (int i = 0; i < sceneDisplayNames.Length; i++)
        {
            if (sceneDisplayNames[i] == selectedOption)
            {
                return i;
            }
        }
        return 0;  // Default to the first option if no match
    }

    // Apply the new settings to the static variables
    public void ApplyNewSettings()
    {
        // Ensure to parse inputs and set them to static variables
        if (int.TryParse(time1InputField.text, out int t1))
        {
            Global.time1 = t1;
        }

        if (int.TryParse(time2InputField.text, out int t2))
        {
            Global.time2 = t2;
        }

        // Set selected option based on dropdown selection
        Global.selectedOption = dropdown.options[dropdown.value].text;

        Debug.Log($"New Settings Applied: Time1 = {Global.time1}, Time2 = {Global.time2}, Selected Option = {Global.selectedOption}");
    }

    // Handle the start button click, passing control to the user
    public void HandControlToUser()
    {
        // Apply the settings before switching scenes
        ApplyNewSettings();

        // Get the selected scene from the dropdown
        string selectedScene = sceneNames[dropdown.value];

        // Load the selected scene
        // SceneManager.LoadScene(selectedScene);
        SceneManager.LoadScene("menu_user");
    }

    // Quit the application
    public void QuitExperiment()
    {
        Application.Quit();
    }

    // Reset values for time1, time2, and dropdown when going back to menu
    public void ResetValuesForMenu()
    {
        Global.time1 = 0;
        Global.time2 = 0;
        Global.selectedOption = "";  // Reset to default

        // Also reset input fields and dropdown
        InitializeMenuValues();
    }

    // Called when the user returns to the menu scene
    public void ReturnToMenu()
    {
        ResetValuesForMenu();
        SceneManager.LoadScene("MenuScene");  // Replace with your menu scene name
    }
}

/* 

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public TMP_InputField time1InputField;  // For time1 input field
    public TMP_InputField time2InputField;  // For time2 input field
    public TMP_Dropdown dropdown;           // For dropdown selection

    void Start()
    {
        // Initialize the input fields with the current values
        InitializeMenuValues();
        // Set button listeners
        startButton.onClick.AddListener(HandControlToUser);
        quitButton.onClick.AddListener(QuitExperiment);

    }

    // Initialize the input fields and dropdown with values from Global
    private void InitializeMenuValues()
    {
        time1InputField.text = Global.time1.ToString();   // Set time1 from Global
        time2InputField.text = Global.time2.ToString();   // Set time2 from Global
        dropdown.value = dropdown.options.FindIndex(option => option.text == Global.selectedOption);  // Set dropdown value from Global
    }

    // Update the static values in Global based on the user's input
    public void ApplyNewSettings()
    {
        // Ensure to parse inputs and set them to static variables
        if (int.TryParse(time1InputField.text, out int t1))
        {
            Global.time1 = t1;
        }

        if (int.TryParse(time2InputField.text, out int t2))
        {
            Global.time2 = t2;
        }

        Global.selectedOption = dropdown.options[dropdown.value].text;

        Debug.Log($"New Settings Applied: Time1 = {Global.time1}, Time2 = {Global.time2}, Selected Option = {Global.selectedOption}");
    }

    // Called when switching to the user scene, passing control to the user
    public void HandControlToUser()
    {
        // Apply the settings before switching scenes
        ApplyNewSettings();

        // Load the user scene
        SceneManager.LoadScene("menu_user");
    }

    // Quit the application
    public void QuitExperiment()
    {
        Application.Quit();
    }

    // Reset values for time1, time2, and dropdown when going back to menu
    public void ResetValuesForMenu()
    {
        Global.time1 = 0;
        Global.time2 = 0;
        Global.selectedOption = "";  // Reset to default

        // Also reset input fields and dropdown
        InitializeMenuValues();
    }

    // Called when the user returns to the menu scene
    public void ReturnToMenu()
    {
        ResetValuesForMenu();
        SceneManager.LoadScene("MenuScene");  // Replace with your menu scene name
    }
} */

/*
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;


    void Start()
    {
        // Set button listeners
        startButton.onClick.AddListener(HandControlToUser);
        quitButton.onClick.AddListener(QuitExperiment);
    }


    // Start the experiment
    public void HandControlToUser()
    {
        SceneManager.LoadScene("menu_user");
    }


    // Quit the application
    public void QuitExperiment()
    {
        Application.Quit();
    }
}
*/