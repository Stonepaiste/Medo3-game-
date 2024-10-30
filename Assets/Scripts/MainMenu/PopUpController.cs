using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpPanel; // Assign the pop-up Panel in the Inspector
    public GameObject mainMenu;   // Assign the main menu Panel in the Inspector

    public void TogglePopUp()
    {
        bool isActive = popUpPanel.activeSelf;
        popUpPanel.SetActive(!isActive);  // Toggle pop-up panel
        mainMenu.SetActive(isActive);     // Toggle main menu based on pop-up visibility
    }
}

