using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
[CreateAssetMenu(fileName = "QuestEvent", menuName = "Capstone-2023-Project/QuestEvent", order = 1)]
public class QuestEvent : ScriptableObject
{
    [SerializeField]
    QuestEnums.SignalOrigin origin;
    [SerializeField]
    List<string> conditions;
    [SerializeField]
    bool userMade = true;

    public void Init(QuestEnums.SignalOrigin newOrigin, List<string> newConditions = null) {
        origin = newOrigin;
        if (newConditions != null) {
            conditions = new List<string>(newConditions);
        }
        userMade = false;   // assuming that QuestEvents made with the constructor are not designer made
    }

    public void AddCondition(string newCondition) {
        conditions.Add(newCondition);
    }

    public List<string> GetConditions() { return conditions; }
    public QuestEnums.SignalOrigin GetOrigin() { return origin; }

    public bool Compare(QuestEvent other) {
        if (this.userMade && !other.userMade) {
            if (this.origin != other.origin) {
                return false;
            }
            foreach (string currCondition in other.conditions) {
                if (!this.conditions.Contains(currCondition)) {
                    return false;
                }
            }
            return true;
        } else { return false; }
    }
}
