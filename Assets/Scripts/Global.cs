using UnityEngine;
using TMPro; // For TMP elements

public class Global : MonoBehaviour
{
    // Static variables for global access
    public static int time1 = 1;
    public static int time2 = 2;
    public static int time3 = 4;
    public static string selectedOption = "scene_01";

    // Public TMP components to assign in the Inspector
    public TMP_InputField time1InputField; // For setting Time1
    public TMP_InputField time2InputField; // For setting Time2
    public TMP_InputField time3InputField; // For setting Time2
    public TMP_Dropdown dropdown;          // TMP Dropdown for selecting options

    // Function to apply user settings
    public void ApplySettings()
    {

        if (int.TryParse(time1InputField.text, out int t1)){time1 = t1;}
        else{Debug.LogError("Invalid input for Time1.");}
        if (int.TryParse(time2InputField.text, out int t2)){time2 = t2;}
        else{Debug.LogError("Invalid input for Time2.");}
        if (int.TryParse(time3InputField.text, out int t3)){time3 = t3;}
        else{Debug.LogError("Invalid input for Time2.");}
        // Get selected dropdown option
        selectedOption = dropdown.options[dropdown.value].text;
        // Log the updated settings
        Debug.Log($"Settings Applied: Time1 = {time1}, Time2 = {time2}, Time3 = {time3}, Option = {selectedOption}");
    }
}

