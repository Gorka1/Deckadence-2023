using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
[CreateAssetMenu(fileName = "QuestEvent", menuName = "Capstone-2023-Project/QuestEvent", order = 1)]
public class QuestEvent : ScriptableObject, System.IEquatable<QuestEvent>
{
    public QuestEnums.SignalOrigin origin;
    public List<string> conditions;

    public override bool Equals(object obj) => this.Equals(obj as QuestEvent);
    public override int GetHashCode() => conditions.GetHashCode();

    // only events that were designer made can call this
    public bool Equals(QuestEvent other) {
        if (this.origin == QuestEnums.SignalOrigin.Quest) {
            foreach (string currCondition in other.conditions) {
                if (!this.conditions.Contains(currCondition)) {
                    return false;
                }
            }
            return true;
        } else {
            return false;
        }
    }
}
