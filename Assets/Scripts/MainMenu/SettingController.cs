using UnityEngine;

public class SettingController : MonoBehaviour
{
    public GameObject SettingsPanel;  // Reference to the settings panel
    public GameObject mainMenu;  // Reference to the main menu panel

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);    // Show settings panel
        mainMenu.SetActive(false);   // Hide main menu panel
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);   // Hide settings panel
        mainMenu.SetActive(true);    // Show main menu panel
    }
}

