using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName;


    // Function to load the play scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");  // This is helpful to confirm the button works in the editor
        Application.Quit();
    }

}