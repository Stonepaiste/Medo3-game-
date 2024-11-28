using UnityEngine;
using TMPro;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class Padlock : MonoBehaviour
{
    public string correctCode = "3006";
    private string enteredCode = "";
    public TextMeshProUGUI displayText;
    public int maxDigits = 4;
    public Door door;
    public bool enemycanspawn;
    private bool hasActivatedEnemy = false;
    EnemyHandler enemyHandler;

    private Color originalColor;
    
    private EventInstance _padlockButtonsEventInstance;
    private EventInstance _padlockCorrectEventInstance;
    private EventInstance _padlockIncorrectEventInstance;

    private void Start()
    {
        enemyHandler = FindObjectOfType<EnemyHandler>();
        enemycanspawn = false;
        originalColor = displayText.color;
        UpdateDisplay();
        _padlockButtonsEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.PadlockButtons);
        _padlockCorrectEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.PadlockCorrect);
        _padlockIncorrectEventInstance = RuntimeManager.CreateInstance(FmodEvents.Instance.PadlockIncorrect);
        
    }

    private void Update()
    {
        for (int i = 0; i<=9; i++)
        {
            if(Input.GetKeyDown(i.ToString()))
            {
                AddDigit(i.ToString());
            }
        }
    }

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < maxDigits)
        {
            enteredCode += digit;
            UpdateDisplay();
            
         //play the padlock buttons sound
            _padlockButtonsEventInstance.start();
            

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
           //play the padlock correct sound
            _padlockCorrectEventInstance.start();
        }
        else
        {
            Debug.Log("Incorrect Code!");
            StartCoroutine(DisplayResult(Color.red));
          //play the padlock incorrect sound
            _padlockIncorrectEventInstance.start();

            // Activate enemy movement only on the first incorrect code entry
            if (!hasActivatedEnemy)
            {
                enemyHandler.SpawnEnemiesAtEHouse();
                enemycanspawn = true;
                hasActivatedEnemy = true; // Prevent future activation
            }
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
