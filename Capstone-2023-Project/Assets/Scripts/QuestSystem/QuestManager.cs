using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    List<CardData> activeCards;

    private void Start() {
        activeCards = new List<CardData>();
    }

    public void TakeEvent(QuestEvent newEvent) {
        foreach (CardData currCard in activeCards) {
            if (currCard.questEvent.Compare(newEvent)) {
                currCard.IncCount();
                if (currCard.CheckCompletion()) {
                    CompleteCard(currCard);
                }
            }
        }
    }

    void CompleteCard(CardData inputCard) {
        inputCard.SetQuestStatus(true);
    }

    public void AddCard(CardData inputCard) { activeCards.Add(inputCard); }

    public void RemoveCard(CardData inputCard) { activeCards.Remove(inputCard); }
}
