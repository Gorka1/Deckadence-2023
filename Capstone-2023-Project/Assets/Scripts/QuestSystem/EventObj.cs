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

    // compare itself to a EventData scriptable object
    public bool Compare(EventData other) {
        // Debug.Log("Comparing Event conditions: Input Event: " 
        // + string.Join(", ", conditions) 
        // + " Quest Event: " 
        // + string.Join(", ", other.conditions));
        // Debug.Log("Input origin: " + ((int)this.origin) + " Quest origin: " + ((int)other.origin));
        if (this.origin != other.origin) {
            return false;
        }
        foreach (string currCondition in other.conditions) {
            Debug.Log(currCondition);
            if (!this.conditions.Contains(currCondition)) {
                return false;
            }
        }
        return true;
    }
}
