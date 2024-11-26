using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AssignmentTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI assignmentText; // TextMeshPro text to display the assignment
    [SerializeField] private string assignmentMessage; // The assignment message to display
    private HashSet<string> playedMessages = new HashSet<string>(); // Set to track played messages

    private void Start()
    {
        if (assignmentText != null)
        {
            assignmentText.gameObject.SetActive(false); // Ensure the text is hidden at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playedMessages.Contains(assignmentMessage)) // Ensure the player has the tag "Player" and message hasn't been played
        {
            if (assignmentText != null)
            {
                assignmentText.text = assignmentMessage; // Set the assignment message
                assignmentText.gameObject.SetActive(true); // Show the assignment text
                MarkMessageAsPlayed(assignmentMessage); // Mark the message as played
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

    private void MarkMessageAsPlayed(string message)
    {
        playedMessages.Add(message); // Add the message to the set of played messages
    }
}
