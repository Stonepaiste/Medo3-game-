using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpPanel;// Assign the pop-up Panel in the Inspector
    

    public void TogglePopUp()
    {
        popUpPanel.SetActive(!popUpPanel.activeSelf);
       
    }
}


