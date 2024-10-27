using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    public float openAngle = 90f;    // Angle to open the door
    public float openSpeed = 70f;     // Speed of opening the door

    public Transform doorTransform; // Reference to the door itself

    public void OpenDoor()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenDoorCoroutine());
            isOpen = true;
        }
    }

    private IEnumerator OpenDoorCoroutine()
    {
        float targetAngle = doorTransform.eulerAngles.y + openAngle; // Calculate the target angle
        float currentAngle = doorTransform.eulerAngles.y; // Get the current angle

        // Gradually rotate the door
        while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
        {
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, openSpeed * Time.deltaTime);
            doorTransform.eulerAngles = new Vector3(doorTransform.eulerAngles.x, currentAngle, doorTransform.eulerAngles.z);
            yield return null;
        }

        // Ensure door reaches the exact target angle
        doorTransform.eulerAngles = new Vector3(doorTransform.eulerAngles.x, targetAngle, doorTransform.eulerAngles.z);
    }
}
