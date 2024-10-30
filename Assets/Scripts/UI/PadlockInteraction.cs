using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;
    public Camera mainCamera;
    public PlayerInpuController playerInpuController;

    private void Start()
    {
        Cursor.visible = true;
        padlockCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    padlockCanvas.SetActive(true);
                    playerInpuController.enabled = false;
                    //Time.timeScale = 0;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && padlockCanvas.activeSelf)
        {
            padlockCanvas.SetActive(false);
            playerInpuController.enabled = true;
            //Time.timeScale = 1;
        }
    }
}
