using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnExitTrigger : MonoBehaviour
{
    
    // This script is used to turn on the exit trigger when the lightning has struck the lighthouse. We use the LightningHasStruk bool from
    // the LightningController script attached to ST_Thunderstrike under SignalsTimeline to turn on the exit trigger.
    
    public LightningController LightningScript;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Using the ThunderHasStruck bool in the LightningController script to turn on the exit trigger.
    public void TurnOnExit()
    {
        if (LightningScript != null && LightningScript.ThunderHasStruck) //If the LightningScript is not null and the ThunderHasStruck bool is true, enable the box collider.
        {
            if (boxCollider != null)  //If the box collider is not null, enable it.
            {
                boxCollider.enabled = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TurnOnExit();
    }
}
