using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardObj
{
    readonly CardData Data;
    int eventCount = 0;
    bool questStatus = false;

    public CardObj() { Data = null; }

    public CardObj(CardData newData) { Data = newData; }

    public CardData GetData() { return Data; }

    // extra funcs written to override the comparison process
    public override string ToString()
    {
        return "Card ID: " + Data.cardID;
    }

    public override bool Equals(object obj) {
        Debug.Log("Called override .Equals(object) for CardObj");
        if (obj == null) return false;
        CardObj objAsCard = obj as CardObj;
        if (objAsCard == null) return false;
        else return Equals(objAsCard);
    }

    public override int GetHashCode()
    {
        return Data.cardID;
    }

    public bool Equals(CardObj other)
    {
        Debug.Log("Called CardObj signature .Equals()");
        return this.Data.cardID == other.GetData().cardID;
    }

    public void IncCount(int inc = 1) { eventCount += inc; }
    public bool CheckCompletion() { return eventCount >= Data.numberOfEvents; }
    public void ResetCount() { eventCount = 0; }
    public void SetQuestStatus(bool status = true) { questStatus = status; }
    public bool GetQuestStatus() { Debug.Log(string.Format("QuestStatus: {0} EventCount: {1}", questStatus.ToString(), eventCount.ToString()));
    return questStatus; }
    public void ApplyEffect() {     // actually add effect script to its targets
        Debug.Log(Data.cardID + "'s effect has been activated");
    }
}
