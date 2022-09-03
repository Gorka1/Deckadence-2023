using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> handList;
    [SerializeField]
    List<CardData> deckList;

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetDeckList() { return deckList; }
    CardData GetDeckCard() {
        int index = Random.Range(0, deckList.Count);
        CardData returnObj = deckList[index];
        deckList.RemoveAt(index);
        return returnObj;
    }
    void AddToHand() {
        if (deckList.Count != 0) {
            handList.Add(GetDeckCard());
        }
    }
    void AddToDeck(CardData newCard) {
        deckList.Add(newCard);
    }
}
