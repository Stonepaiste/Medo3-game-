using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName;
    public GameObject mainMenu;
    public GameObject settingsPanel;
    public GameObject controlPanel;
   


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

    public void BackToMenu()
    {
        BackToMenu();
    }
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            bool isActive = controlPanel.activeSelf;
            controlPanel.SetActive(!isActive);
            mainMenu.SetActive(isActive);  // Hide main menu when control panel is active
            Debug.Log("Toggling control panel: " + (!isActive ? "Open" : "Close"));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                settingsPanel.SetActive(false);
                mainMenu.SetActive(true);  // Show main menu when settings panel is closed
                Debug.Log("Closing settings panel with Esc");
            }
            else if (controlPanel.activeSelf)
            {
                controlPanel.SetActive(false);
                mainMenu.SetActive(true);  // Show main menu when control panel is closed
                Debug.Log("Closing control panel with Esc");
            }

        }
    }*/

 

}