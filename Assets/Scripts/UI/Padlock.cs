using UnityEngine;
using TMPro;

public class Padlock : MonoBehaviour
{
    public string correctCode = "3006";  // The correct code for the lock
    private string enteredCode = "";     // The code the player is entering
    public TextMeshProUGUI displayText;  // Reference to the TextMeshPro field to show the input
    public int maxDigits = 4;            // Limit the number of digits a player can enter

    private void Start()
    {
        Cursor.visible = true;
    }

    public void AddDigit(string digit)
    {
        Debug.Log("Button works!");
        if (enteredCode.Length < maxDigits)
        {
            enteredCode += digit;
            UpdateDisplay();
        }
    }

    // Update the TextMeshPro display with the current input
    private void UpdateDisplay()
    {
        displayText.text = enteredCode;
    }

    // This method checks if the entered code is correct
    public void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Correct Code Entered!");
            // Add your logic here for what happens when the correct code is entered
        }
        else
        {
            Debug.Log("Incorrect Code!");
            // Add logic for incorrect input if needed
        }

        // Reset the entered code after checking
        ResetCode();
    }

    // Reset the entered code and clear the display
    public void ResetCode()
    {
        enteredCode = "";
        UpdateDisplay();
    }
}