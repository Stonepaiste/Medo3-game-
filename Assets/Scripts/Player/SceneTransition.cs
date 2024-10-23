using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    private string sceneToLoad;

    // Call this method to start the transition
    public void StartSceneTransition(string sceneName)
    {
        sceneToLoad = sceneName;         // Store the name of the scene to load
        animator.SetTrigger("FadeOut");  // Start the fade-out animation
    }

    // This method is called at the end of the fade animation (via Animation Event)
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);  // Load the new scene when the fade is complete
    }
}
