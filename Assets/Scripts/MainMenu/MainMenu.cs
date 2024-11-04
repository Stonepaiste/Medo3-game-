using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName;


    // Function to load the play scene
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");  // This is helpful to confirm the button works in the editor
        Application.Quit();
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(2);
        }
    }

}