using UnityEngine;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject padlockCanvas;
    public Camera mainCamera;

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
                    //Time.timeScale = 0;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && padlockCanvas.activeSelf)
        {
            padlockCanvas.SetActive(false);
            //Time.timeScale = 1;
        }
    }
}
