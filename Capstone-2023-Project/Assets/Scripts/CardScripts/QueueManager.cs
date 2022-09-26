using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> CardQueue;   // index 0 is front of queue
    [SerializeField]
    List<CardData> deckList;
    [SerializeField]
    int maxHandSize = 5;
    [SerializeField]
    int handListInd;
    [SerializeField]
    float scrollwheelScale = 0.1f;
    GameManager GM;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public CardData[] GetTopThree() { 
        CardData[] return_card = new CardData[3];
        for (int i = 0; i < 3; i++) {
            return_card[i] = CardQueue[i];
        }
        return return_card;
    }

    public void ActivateFirstTwoQuests() {
        CardData[] curr_cards = GetTopThree();
        // call GM's quest activate function twice
    }

    public void DiscardCard() {
        // call GM's quest deactivate function with card at index 0
        // play animations here
        PopCard();
    }

    public void UseCard() {
        bool questComplete = true; // actually call GM's quest checker
        if (questComplete) {
            // call gunManager's update card effect
            PopCard();
        }
    }

    private void PopCard() {
        CardQueue.RemoveAt(0);
    }

    // public List<CardData> GetHandList() { return handList; }
    // public List<CardData> GetDeckList() { return deckList; }
    // public int GetHandListInd() { return handListInd; }
    // public CardData GetHandCard() {
    //     if (handList.Count == 0) return null;
    //     else return handList[handListInd];
    // }
    // public void RemoveCurrCard() {
    //     if (handListInd != 0) { handListInd--; }
    //     handList.RemoveAt(handListInd);
    // }
    // CardData GetDeckCard() {
    //     int index = Random.Range(0, deckList.Count);
    //     CardData returnObj = deckList[index];
    //     deckList.RemoveAt(index);
    //     return returnObj;
    // }
    // public void AddToHand() {
    //     if (deckList.Count != 0) {
    //         handList.Add(GetDeckCard());
    //     }
    // }
    // public void AddToDeck(CardData newCard) {
    //     deckList.Add(newCard);
    // }
}
