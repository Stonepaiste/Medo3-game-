using UnityEngine;
using TMPro;

public class AssignmentTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI assignmentText; // TextMeshPro text to display the assignment
    [SerializeField] private string assignmentMessage; // The assignment message to display

    private void Start()
    {
        if (assignmentText != null)
        {
            assignmentText.gameObject.SetActive(false); // Ensure the text is hidden at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            if (assignmentText != null)
            {
                assignmentText.text = assignmentMessage; // Set the assignment message
                assignmentText.gameObject.SetActive(true); // Show the assignment text
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            if (assignmentText != null)
            {
                assignmentText.gameObject.SetActive(false); // Hide the assignment text when the player exits the trigger
            }
        }
    }
}