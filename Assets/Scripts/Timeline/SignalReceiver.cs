using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//ChatGPT helped making this script
public class SignalReceiver : MonoBehaviour, INotificationReceiver
{
    [SerializeField] CanvasActivator canvasActivator;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SignalEmitter)
        {
            canvasActivator?.ActivateCanvas();
        }
    }

}
