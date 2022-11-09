using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CardData", menuName = "Capstone-2023-Project/CardData", order = 0)]
public class CardData : ScriptableObject
{
    public int cardID;
    public string cardName;
    public Color testWeaponColor;      // placeholder for testing
    public Sprite cardGraphic;
    // card info
    public CardEnums.CardRarity rarity;
    public GameObject effectObj;
    public CardEnums.TargetType targetType;
    public string target;
}
