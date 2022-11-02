using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestEvent", menuName = "Capstone-2023-Project/QuestEvent", order = 1)]
public class EventData : ScriptableObject
{
    [SerializeField]
    public QuestEnums.SignalOrigin origin;
    [SerializeField]
    public List<string> conditions;
}
