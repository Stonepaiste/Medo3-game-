using UnityEngine;
using TMPro;
using System.Collections;

public class WordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text messageText;

    // End screen elements
    public GameObject endCanvas;
    public TMP_Text endCanvasText;

    private string[] acceptedWords = { "lonely", "lonley", "lonly", "alone", "alnoe", "alnone", "allone", "loenly", "lonesome", "lone", "ensom", "alene", "ensomhed", "sad", "sadness", "sadnes", "desperate", "desprate", "desperatee", "despirate", "isolated", "isolatted", "isolted", "empty", "emty", "empti", "frusrated", "frustrued", "frusted", "frustarted", "helpless", "helples", "helppless", "unwanted", "exhausted", "anxious", "anxiety", "anxius", "anxios", "depression", "depressed", "deppressed", "excluded", "misunderstood", "misunderstod", "ignored", "forgotten", "forgoten", "rejected", "abandoned" };

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

            endCanvas.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            StartCoroutine(ShowEndCanvasTextSequence());
        }
        else
        {
            messageText.text = "Incorrect word, try again!";
            messageText.gameObject.SetActive(true);
        }
    }

    private IEnumerator ShowEndCanvasTextSequence()
    {
        // Show the first text
        endCanvasText.text = "The theme of the game is loneliness. Loneliness is a deeply personal feeling that can give rise to other emotions as well. In Denmark, loneliness has been on the rise over the past decade, affecting more and more people. The Danish Parliament is already taking actions addressing the problem, but what can you do to help?";
        yield return new WaitForSeconds(15f); // Wait for 3 seconds

        // Change to the second text
        endCanvasText.text = "If you think someone might be feeling lonely, look for signs like isolation, a loss of interest in activities they once enjoyed, or difficulty sleeping. Reaching out to them can make a difference—try talking to them, actively listening, and being patient, as they may struggle to connect with others.";
        yield return new WaitForSeconds(15f); // Wait for another 3 seconds

        // Change to the final text or keep as is
        endCanvasText.text = "If you are experiencing loneliness yourself and need someone to talk to, you can reach out for help at this number: 35 36 26 00.";
        yield return new WaitForSeconds(10f);

        endCanvasText.text = "Thank you for playing!";
    }
}
