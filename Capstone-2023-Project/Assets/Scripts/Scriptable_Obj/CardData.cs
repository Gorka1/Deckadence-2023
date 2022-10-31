using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CardData", menuName = "Capstone-2023-Project/CardData", order = 0)]
public class CardData : ScriptableObject
{
    public int cardID;
    public int cardRank;
    public Color testWeaponColor;      // placeholder for testing
    public Sprite cardGraphic;
    public Dictionary<string, string> changesDict;
    // card info
    public CardEnums.CardRarity rarity;
    public AbstractEffect effectScript;
    public GameObject effectObj;
    public delegate void effectFunc();
    public CardEnums.TargetType targetType;
    public string target;
}
