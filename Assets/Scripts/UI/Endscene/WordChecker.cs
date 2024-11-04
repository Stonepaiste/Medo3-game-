using UnityEngine;
using TMPro;
using System.Collections;

public class WordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text messageText;

    // End screen elements
    public GameObject endCanvas;
    public TMP_Text endMessageText;
    public TMP_Text scrollingText;
    public float scrollSpeed = 50f;

    private string[] acceptedWords = { "lonely", "lonley", "alone", "alnoe", "alnone", "allone", "loenly", "lonesome", "lone", "ensom", "alene" };

    void Start()
    {
        Cursor.visible = true;
        inputField.onEndEdit.AddListener(CheckInput);
        messageText.gameObject.SetActive(false);
        endCanvas.SetActive(false);
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
            inputField.gameObject.SetActive(false);

            // Show the end canvas
            endCanvas.SetActive(true);

            // Start the text display and scroll coroutine
            StartCoroutine(DisplayEndMessageThenScrollText());
        }
        else
        {
            messageText.text = "Incorrect word, try again!";
            messageText.gameObject.SetActive(true);
        }
    }

    private IEnumerator DisplayEndMessageThenScrollText()
    {
        // Show end message text for 10 seconds
        endMessageText.gameObject.SetActive(true);
        scrollingText.gameObject.SetActive(false);

        yield return new WaitForSeconds(10f);

        // Hide end message text
        endMessageText.gameObject.SetActive(false);

        // Show scrolling text and begin scrolling
        scrollingText.gameObject.SetActive(true);

        // Start scrolling text upwards
        while (scrollingText.rectTransform.position.y < Screen.height)
        {
            scrollingText.rectTransform.position += Vector3.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
