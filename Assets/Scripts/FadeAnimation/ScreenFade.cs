using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage; // Assign the UI Image for fading
    public float fadeDuration = 1f; // Duration of the fade
    public Transform targetPosition; // Set this in the Inspector to the new position

    private void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FadeTrigger")) // Make sure the trigger object has the tag "FadeTrigger"
        {
            StartCoroutine(FadeAndTeleport());
        }
    }

    private IEnumerator FadeAndTeleport()
    {
        // Start the fade out
        yield return StartCoroutine(FadeOut());

        // Move the player to the new position after fade out
        if (targetPosition != null)
        {
            transform.position = targetPosition.position;
        }

        // Fade in after teleporting
        yield return StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        while (elapsed < fadeDuration)
        {
            color.a = Mathf.Lerp(0, 1, elapsed / fadeDuration);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        color.a = 1;
        fadeImage.color = color;
    }

    public IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        while (elapsed < fadeDuration)
        {
            color.a = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        fadeImage.color = color;
    }
}

