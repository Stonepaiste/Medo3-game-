using UnityEngine;
using TMPro;

public class WordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text messageText;

    private string[] acceptedWords = { "lonely", "lonley", "alone", "alnoe", "alnone", "allone", "loenly", "lonesome", "lone", "ensom", "alene" };

    void Start()
    {
        Cursor.visible = true;
        inputField.onEndEdit.AddListener(CheckInput);
        messageText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (messageText.gameObject.activeSelf && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            messageText.gameObject.SetActive(false);
        }
    }

    public void CheckInput(string userInput)
    {
        userInput = userInput.ToLower();

        if (System.Array.Exists(acceptedWords, word => word == userInput))
        {
            Debug.Log("Correct word!!");
            messageText.gameObject.SetActive(false);
        }
        else
        {
            messageText.text = "Incorrect word, try again!";
            messageText.gameObject.SetActive(true);
        }
    }
}



