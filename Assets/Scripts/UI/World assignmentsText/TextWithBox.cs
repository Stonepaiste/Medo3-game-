using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWithBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro text
    [SerializeField] private Color boxColor = Color.black; // Color of the box
    [SerializeField] private Vector2 padding = new Vector2(10, 10); // Padding around the text

    private void Start()
    {
        // Create a new GameObject for the box
        GameObject boxObject = new GameObject("TextBox");
        boxObject.transform.SetParent(textMeshPro.transform.parent);

        // Add an Image component to the box
        Image boxImage = boxObject.AddComponent<Image>();
        boxImage.color = boxColor;

        // Set the box as the parent of the text
        textMeshPro.transform.SetParent(boxObject.transform);

        // Adjust the size of the box to fit the text with padding
        RectTransform textRect = textMeshPro.GetComponent<RectTransform>();
        RectTransform boxRect = boxObject.GetComponent<RectTransform>();
        boxRect.sizeDelta = textRect.sizeDelta + padding;

        // Position the box correctly
        boxRect.anchoredPosition = textRect.anchoredPosition;
        textRect.anchoredPosition = Vector2.zero;
    }
}