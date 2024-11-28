using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AssignmentTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI assignmentText; // TextMeshPro text to display the assignment
    private HashSet<string> playedMessages = new HashSet<string>(); // Set to track played messages
    [SerializeField] private string assignmentMessage; // The message to display

    private void Start()
    {
        if (assignmentText != null)
        {
            assignmentText.gameObject.SetActive(false); // Ensure the text is hidden at the start
        }
    }

    public void ShowAssignmentMessage(string message)
    {
        if (assignmentText != null && !playedMessages.Contains(message))
        {
            assignmentText.text = assignmentMessage; // Set the assignment message
            assignmentText.gameObject.SetActive(true); // Show the assignment text
            MarkMessageAsPlayed(assignmentMessage); // Mark the message as played
            Invoke("HideAssignmentMessage", 5f); // Hide the assignment message after 5 seconds
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(assignmentText != null)
            {
                assignmentText.text = assignmentMessage; // Set the assignment message
                ShowAssignmentMessage(assignmentMessage); // Show the assignment message when the player enters the trigger
                MarkMessageAsPlayed(assignmentMessage); // Mark the message as played
            }
            
            // This part can be removed if you only want to show messages through scripts
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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
    
    public void HideAssignmentMessage()
    {
        if (assignmentText != null)
        {
            assignmentText.gameObject.SetActive(false); // Hide the assignment text
        }
    }
}