using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PowerOffSignalReciever : MonoBehaviour, INotificationReceiver
{
    public LampLighthouse lampLighthouse;
    
    
    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SignalEmitter)
        {
            lampLighthouse.TurnPowerOff();
        }
    }
   
}
