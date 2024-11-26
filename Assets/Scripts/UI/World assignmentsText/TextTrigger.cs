using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> textList; // List of TextMeshPro texts
    [SerializeField] private List<Collider> triggerList; // List of triggers

    private Dictionary<Collider, TextMeshProUGUI> triggerTextMap;

    private void Awake()
    {
        if (textList.Count != triggerList.Count)
        {
            Debug.LogError("Text list and trigger list must have the same number of elements.");
            return;
        }

        triggerTextMap = new Dictionary<Collider, TextMeshProUGUI>();

        for (int i = 0; i < triggerList.Count; i++)
        {
            triggerTextMap.Add(triggerList[i], textList[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerTextMap.ContainsKey(other))
        {
            triggerTextMap[other].gameObject.SetActive(true);
        }
    }
}