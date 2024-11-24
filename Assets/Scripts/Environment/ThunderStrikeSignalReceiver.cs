using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ThunderStrikeSignalReceiver : MonoBehaviour, INotificationReceiver
{
    public LightningController lightningController;
    public GameObject TurnOffSceneTrigger;
   

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SignalEmitter && lightningController.ThunderHasStruck == false)
        {
            lightningController.ThunderStrikeLighthouse();
            TurnOffSceneTrigger.SetActive(false);
            
        }
    }
}