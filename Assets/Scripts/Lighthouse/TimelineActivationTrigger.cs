using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivationTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] GameObject  TimelineActivationTriggerObject;

    private void Start()
    {
        TimelineActivationTriggerObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playableDirector.Play();
        }
    }
}
