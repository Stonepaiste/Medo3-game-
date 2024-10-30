using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonologueObject", menuName = "MonologueSystem/MonologueObject", order = 0)]
public class MonologueObject : ScriptableObject
{
    [Header("Monologue")]
    public List<string> monologueStrings = new List<string>();


    [Header("Follow on Monologue - Optional")]
    public MonologueObject endMonologue;
}
