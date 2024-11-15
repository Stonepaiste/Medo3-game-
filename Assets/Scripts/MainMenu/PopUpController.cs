using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpPanel;// Assign the pop-up Panel in the Inspector
    public GameObject mainMenu;
    

    public void TogglePopUp()
    {
        bool isActive = !popUpPanel.activeSelf;
        popUpPanel.SetActive(isActive);

        mainMenu.SetActive(!isActive);
       
    }

    public void GoBackToMainMenu()
    {
        popUpPanel.SetActive(false); //Hide the pop-up panel
        mainMenu.SetActive(true); // Show the main menu
    }
}


