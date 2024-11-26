using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ChatGPT helped with this script
public class CanvasActivator : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public void ActivateCanvas()
    {
        canvas.SetActive(true);
    }
}
