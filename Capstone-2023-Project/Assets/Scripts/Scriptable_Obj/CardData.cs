using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Capstone-2023-Project/CardData", order = 0)]
public class CardData : ScriptableObject//, IEqualityComparer<CardData>, IEquatable<CardData>, 
{
    public int cardID;
    public Color testWeaponColor;      // placeholder for testing
    public Sprite cardGraphic;
    public Dictionary<string, string> changesDict;

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
}
