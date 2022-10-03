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
    public EventData questEvent;
    public int numberOfEvents;
}
