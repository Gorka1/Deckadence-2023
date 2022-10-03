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
        foreach(CardData currData in CardScriptableQueue) {
            CardQueue.Add(new CardObj(currData));
        }
    }

    public CardObj[] GetTopThree() { 
        CardObj[] return_card = new CardObj[3];
        for (int i = 0; i < 3; i++) {
            return_card[i] = CardQueue[i];
        }
        return return_card;
    }

    public void ActivateFirstTwoQuests() {
        CardObj[] curr_cards = GetTopThree();
        QuestM.AddCard(curr_cards[0]);
        QuestM.AddCard(curr_cards[1]);
        // GM.TakeQuestEvent(curr_cards[0].)
        // call GM's quest activate function twice
    }

    public void DiscardCard() {
        // call GM's quest deactivate function with card at index 0
        // play animations here
        PopCard();
    }

    public void UseCard() {
        if (CardQueue[0].GetQuestStatus()) {
            // call gunManager's update card effect
            CardQueue[0].ApplyEffect();
            PopCard();
        }
    }

    private void PopCard() {
        QuestM.RemoveCard(CardQueue[0]);
        CardQueue.RemoveAt(0);
    }

    public void AddToQueue(CardObj newCard) { CardQueue.Add(newCard); }
}
