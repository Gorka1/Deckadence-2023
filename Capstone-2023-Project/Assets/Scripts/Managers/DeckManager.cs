using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> deckList;
    [SerializeField]
    List<CardData> handList = new List<CardData>(4);
    [SerializeField]
    List<CardData> internalDeckList;
    [SerializeField]
    List<CardData> discardList;
    [SerializeField]
    int maxHandSize = 5;
    [SerializeField]
    int handListInd;
    GameManager GM;
    UIHand uiHand;

    private void Start() {
        internalDeckList = new List<CardData>(deckList);
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uiHand = GameObject.FindGameObjectWithTag("UIHand").GetComponent<UIHand>();
    }

    public void Init() {
        // handList = new List<CardData>(4);
        for (int i = 0; i < 4; i++) {
            if (handList[i] == null) {
                //handList[i] = GetDeckCard();
                AddToHand(i);
            }
        }
    }

    private void Update() {
        // float currScollInput = Input.mouseScrollDelta.y * scrollwheelScale;
        // if (currScollInput > .5f && handListInd < handList.Count - 1) {
        //     handListInd++;
        // } else if (currScollInput < -.5f && handListInd > 0) {
        //     handListInd--;
        // }
        // if (internalDeckList.Count == 0) {
        //     int numOfNull = 0;
        //     foreach (CardData cd in handList) { if (cd == null) numOfNull++; }
        //     if (numOfNull == handList.Count)
        //         DiscardToDeck();
        //     // DiscardToDeck();
        // }
    }

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetinternalDeckList() { return internalDeckList; }
    public List<CardData> GetDiscardList() { return discardList; }
    public int GetHandListInd() { return handListInd; } // do we need this?
    public void IncHandListInd(int inc = 1) { handListInd += inc; }
    public void SetHandInd(int newVal) { handListInd = newVal; }
    public CardData GetHandCard() {
        if (handList.Count == 0) return null;
        else return handList[handListInd];
    }
    public void RemoveCurrCard() {
        AddToDiscard(handList[handListInd]);
        handList[handListInd] = null;
        uiHand.RemoveCard(handListInd); //?
    }
    CardData GetDeckCard() {
        if (internalDeckList.Count == 0) {
            return null;
        }
        int index = Random.Range(0, internalDeckList.Count);
        CardData returnObj = internalDeckList[index];
        internalDeckList.RemoveAt(index);
        return returnObj;
    }
    void DiscardToDeck() {
        if (internalDeckList.Count == 0) {
            internalDeckList = new List<CardData>(discardList);
            discardList.Clear();
            Init();
        }
    }

    //Pulls a card from deck, puts in hand.
    //Updates UI and other relevant things to reflect the change.
    public void AddToHand(int position) {
        if (internalDeckList.Count != 0) {
            handList[position] = GetDeckCard();
        } else {
            DiscardToDeck(); //QUESTION: why, what does this do? --Jaden 
            // handList[position] = GetDeckCard();
        }
        uiHand.AddCard(position, handList[position]); //?
    }
    public void AddToDeck(CardData newCard) {
        internalDeckList.Add(newCard);
    }
    void AddToDiscard(CardData newCard) {
        discardList.Add(newCard);
    }

    public void UseCurrCard() {
        CardData currCardData = handList[handListInd];
        if (currCardData != null && currCardData.cost <= GM.GetPlayerPoints()){
            CardObj currCardObj = new CardObj(currCardData);
            currCardObj.ApplyEffect();
            GM.SpendPoints(currCardData.cost);
            RemoveCurrCard();
            AddToHand(handListInd);
        }
    }
}
