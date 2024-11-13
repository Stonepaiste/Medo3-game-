using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonologueObject", menuName = "MonologueSystem/MonologueObject", order = 0)]
public class MonologueObject : ScriptableObject
{
    [Header("Monologue")]
    public List<MonologueSegment> monologueSegments = new List<MonologueSegment>();

    [Header("Follow on Monologue - Optional")]
    public MonologueObject endMonologue;

    [System.Serializable]
    public struct MonologueSegment
    {
        public string narratorName; //Field for narrator name
        public string monologueText; //Field for monologue text
        public float monologueDisplaytime; //Field for display time of monologue text
        public float waitTimeBeforeNext;  // Field for wait time before displaying the next monologue text  
        public List<MonologueChoice> monologueChoices;
    }

    [System.Serializable]
    public struct MonologueChoice
    {
        public string monologueChoice;
        public MonologueObject followMonologue;
    }
}
