using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventObj
{

    QuestEnums.SignalOrigin origin;
    List<string> conditions;
    public EventObj(QuestEnums.SignalOrigin newOrigin, List<string> newConditions = null) {
        origin = newOrigin;
        if (newConditions != null) {
            conditions = new List<string>(newConditions);
        }
    }

    public void AddCondition(string newCondition) {
        conditions.Add(newCondition);
    }

    public List<string> GetConditions() { return conditions; }
    public QuestEnums.SignalOrigin GetOrigin() { return origin; }

    public bool Compare(EventData other) {
        if (this.origin != other.origin) {
            return false;
        }
        foreach (string currCondition in other.conditions) {
            if (!this.conditions.Contains(currCondition)) {
                return false;
            }
        }
        return true;
    }
}
