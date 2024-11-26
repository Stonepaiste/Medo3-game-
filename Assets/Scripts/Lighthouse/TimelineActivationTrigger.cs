using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivationTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] GameObject  TimelineActivationTriggerObject;
    public LightningController LightningController;
    private void Start()
    {
        TimelineActivationTriggerObject.SetActive(false);

    }
    
    private void Update()
    {
        TurnOffCollider();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playableDirector.Play();
        }
    }
    
    public void TurnOffCollider()
    {
        if (LightningController.ThunderHasStruck)
        {
            TimelineActivationTriggerObject.SetActive(false);
        }
    }
}



