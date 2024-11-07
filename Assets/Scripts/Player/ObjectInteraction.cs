using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{

    public string sceneToLoad;

    void OnMouseDown()
    {
        // Code to "pick up" the object
        Debug.Log("Object picked up!");

    }
}
