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
        public string monologueText;

        public float monologueDisplaytime;

        public List<MonologueChoice> monologueChoices;
    }

    [System.Serializable]
    public struct MonologueChoice
    {
        public string monologueChoice;
        public MonologueObject followMonologue;
    }
}
