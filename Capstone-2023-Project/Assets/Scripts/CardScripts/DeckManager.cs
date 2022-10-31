using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> deckList;
    [SerializeField]
    List<CardData> handList;
    [SerializeField]
    List<CardData> internalDeckList;
    [SerializeField]
    List<CardData> discardList;
    [SerializeField]
    int maxHandSize = 5;
    [SerializeField]
    int handListInd;

    private void Start() {
        internalDeckList = new List<CardData>(deckList);
    }

    public void Init() {
        handList = new List<CardData>(4);
        for (int i = 0; i < 4; i++) {
            handList[i] = GetDeckCard();
        }
    }

    private void Update() {
        // float currScollInput = Input.mouseScrollDelta.y * scrollwheelScale;
        // if (currScollInput > .5f && handListInd < handList.Count - 1) {
        //     handListInd++;
        // } else if (currScollInput < -.5f && handListInd > 0) {
        //     handListInd--;
        // }
        if (internalDeckList.Count == 0) {
            DiscardToDeck();
        }
    }

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetinternalDeckList() { return internalDeckList; }
    public List<CardData> GetDiscardList() { return discardList; }
    public int GetHandListInd() { return handListInd; }
    public void IncHandListInd(int inc = 1) { handListInd += inc; }
    public void SetHandInd(int newVal) { handListInd = newVal; }
    public CardData GetHandCard() {
        if (handList.Count == 0) return null;
        else return handList[handListInd];
    }
    public void RemoveCurrCard() {
        if (handListInd != 0) { handListInd--; }
        handList.RemoveAt(handListInd);
    }
    CardData GetDeckCard() {
        int index = Random.Range(0, internalDeckList.Count);
        CardData returnObj = internalDeckList[index];
        internalDeckList.RemoveAt(index);
        return returnObj;
    }
    void DiscardToDeck() {
        if (internalDeckList.Count == 0) {
            internalDeckList = new List<CardData>(discardList);
            discardList.Clear();
        }
    }
    public void AddToHand(int position) {
        if (internalDeckList.Count != 0) {
            handList[position] = GetDeckCard();
        }
    }
    public void AddToDeck(CardData newCard) {
        internalDeckList.Add(newCard);
    }
    void AddToDiscard(CardData newCard) {
        discardList.Add(newCard);
    }
}
