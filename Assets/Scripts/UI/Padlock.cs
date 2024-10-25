using UnityEngine;
using TMPro;
using System.Collections;

public class Padlock : MonoBehaviour
{
    public string correctCode = "3006";
    private string enteredCode = "";
    public TextMeshProUGUI displayText;
    public int maxDigits = 4;
    public Door door;

    private Color originalColor;

    private void Start()
    {
        Cursor.visible = true;
        originalColor = displayText.color;
        UpdateDisplay();
    }

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < maxDigits)
        {
            enteredCode += digit;
            UpdateDisplay();

            if (enteredCode.Length == maxDigits)
            {
                CheckCode();
            }
        }
    }

    private void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Correct Code Entered!");
            StartCoroutine(DisplayResult(Color.green));
            door.OpenDoor();
        }
        else
        {
            Debug.Log("Incorrect Code!");
            StartCoroutine(DisplayResult(Color.red));
        }
    }

    private IEnumerator DisplayResult(Color resultColor)
    {
        displayText.color = resultColor;
        yield return new WaitForSeconds(1);
        ResetCode();
        displayText.color = originalColor;
    }

    private void UpdateDisplay()
    {
        displayText.text = enteredCode.PadRight(maxDigits, '_');
    }

    public void ResetCode()
    {
        enteredCode = "";
        UpdateDisplay();
    }
}
