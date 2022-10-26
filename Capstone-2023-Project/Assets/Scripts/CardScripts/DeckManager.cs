using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardObj> handList;
    [SerializeField]
    List<CardObj> deckList;
    [SerializeField]
    List<CardObj> discardList;
    [SerializeField]
    int maxHandSize = 5;
    [SerializeField]
    int handListInd;

    private void Start() {
        handList = new List<CardObj>(4);
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
        if (deckList.Count == 0) {
            DiscardToDeck();
        }
    }

    public List<CardObj> GetHandList() { return handList; }
    public List<CardObj> GetDeckList() { return deckList; }
    public List<CardObj> GetDiscardList() { return discardList; }
    public int GetHandListInd() { return handListInd; }
    public void SetHandInd(int newVal) { handListInd = newVal; }
    public CardObj GetHandCard() {
        if (handList.Count == 0) return null;
        else return handList[handListInd];
    }
    public void RemoveCurrCard() {
        if (handListInd != 0) { handListInd--; }
        handList.RemoveAt(handListInd);
    }
    CardObj GetDeckCard() {
        int index = Random.Range(0, deckList.Count);
        CardObj returnObj = deckList[index];
        deckList.RemoveAt(index);
        return returnObj;
    }
    void DiscardToDeck() {
        if (deckList.Count == 0) {
            deckList = new List<CardObj>(discardList);
            discardList.Clear();
        }
    }
    public void AddToHand(int position) {
        if (deckList.Count != 0) {
            handList[position] = GetDeckCard();
        }
    }
    public void AddToDeck(CardObj newCard) {
        deckList.Add(newCard);
    }
    void AddToDiscard(CardObj newCard) {
        discardList.Add(newCard);
    }
}
