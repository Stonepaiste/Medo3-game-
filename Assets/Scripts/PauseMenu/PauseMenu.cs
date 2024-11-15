using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // The main pause menu panel
    public GameObject settingsPanel; // The settings panel
    public GameObject controlsPanel; // The controls panel

    public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at the start of the game
        Cursor.visible = false; // Hide the cursor at the start of the game
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }

    public void ShowSettingsPanel()
    {
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void ShowControlsPanel()
    {
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        pauseMenu.SetActive(true);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

