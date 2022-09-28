using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Capstone-2023-Project/CardData", order = 0)]
public class CardData : ScriptableObject
{
    public int cardID;
    public int cardRank;
    public Color testWeaponColor;      // placeholder for testing
    public Sprite cardGraphic;
    public Dictionary<string, string> changesDict;
    public int questCode;
    // card info
    public MonoBehaviour effectScript;
    public string target;
    public QuestEvent questEvent;
    public int numberOfEvents;
    int eventCount = 0;
    [SerializeField]
    bool questStatus = false;

    // extra funcs written to override the comparison process
    public override string ToString()
    {
        return "Card ID: " + cardID;
    }

    public override bool Equals(object obj) {
        Debug.Log("Called override .Equals(object) for CardData");
        if (obj == null) return false;
        CardData objAsCard = obj as CardData;
        if (objAsCard == null) return false;
        else return Equals(objAsCard);
    }

    public override int GetHashCode()
    {
        return cardID;
    }

    public bool Equals(CardData other)
    {
        Debug.Log("Called CardData signature .Equals()");
        return this.cardID == other.cardID;
    }

    public void IncCount(int inc = 1) { eventCount += inc; }
    public bool CheckCompletion() { return eventCount >= numberOfEvents; }
    public void ResetCount() { eventCount = 0; }
    public void SetQuestStatus(bool status = true) { questStatus = status; }
    public bool GetQuestStatus() { return questStatus; }
    public void ApplyEffect() {     // actually add effect script to its targets
        Debug.Log(cardID + "'s effect has been activated");
    }
}
