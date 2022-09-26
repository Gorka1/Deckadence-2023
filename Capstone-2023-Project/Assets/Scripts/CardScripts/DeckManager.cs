using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> handList;
    [SerializeField]
    List<CardData> deckList;
    [SerializeField]
    int maxHandSize = 5;
    [SerializeField]
    int handListInd;
    [SerializeField]
    float scrollwheelScale = 0.1f;

    private void Update() {
        float currScollInput = Input.mouseScrollDelta.y * scrollwheelScale;
        if (currScollInput > .5f && handListInd < handList.Count - 1) {
            handListInd++;
        } else if (currScollInput < -.5f && handListInd > 0) {
            handListInd--;
        }
    }

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetDeckList() { return deckList; }
    public int GetHandListInd() { return handListInd; }
    public CardData GetHandCard() {
        if (handList.Count == 0) return null;
        else return handList[handListInd];
    }
    public void RemoveCurrCard() {
        if (handListInd != 0) { handListInd--; }
        handList.RemoveAt(handListInd);
    }
    CardData GetDeckCard() {
        int index = Random.Range(0, deckList.Count);
        CardData returnObj = deckList[index];
        deckList.RemoveAt(index);
        return returnObj;
    }
    public void AddToHand() {
        if (deckList.Count != 0) {
            handList.Add(GetDeckCard());
        }
    }
    public void AddToDeck(CardData newCard) {
        deckList.Add(newCard);
    }
}
