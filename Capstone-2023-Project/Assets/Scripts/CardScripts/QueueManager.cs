using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> CardScriptableQueue;   // index 0 is front of queue
    List<CardObj> CardQueue;
    GameManager GM;
    QuestManager QuestM;

    private void Start() {
        GameObject GMObj = GameObject.FindGameObjectWithTag("GameManager");
        GM = GMObj.GetComponent<GameManager>();
        QuestM = GMObj.GetComponent<QuestManager>();
        CardQueue = new List<CardObj>();
        foreach(CardData currData in CardScriptableQueue) {
            CardQueue.Add(new CardObj(currData));
        }
    }

    public CardObj[] GetTopThree() { 
        CardObj[] return_card = new CardObj[3];
        for (int i = 0; i < 3; i++) {
            if (return_card.Length > i + 1) {
                return_card[i] = CardQueue[i];
            }
        }
        return return_card;
    }

    public void ActivateFirstTwoQuests() {
        CardObj[] curr_cards = GetTopThree();
        if (curr_cards.Length > 1) { QuestM.AddCard(curr_cards[0]); }
        if (curr_cards.Length > 2) { QuestM.AddCard(curr_cards[1]); }
    }

    public void DiscardCard() {
        // call GM's quest deactivate function with card at index 0
        // play animations here
        PopCard();
    }

    public void UseCard() {
        // call gunManager's update card effect
        bool result = QuestM.EngageTopCard();
        if (result) {   // only pop card if the actual top card is completed
            PopCard();
        }
    }

    private void PopCard() {
        if (CardQueue.Count < 3) {
            QuestM.AddCard(CardQueue[2]);   // card at index 2 is the next card
        }
        QuestM.RemoveCard(CardQueue[0]);
        CardQueue.RemoveAt(0);
    }

    public void AddToQueue(CardObj newCard) { CardQueue.Add(newCard); }
}
