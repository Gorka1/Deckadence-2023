using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> activeCards;

    private void Start() {
        activeCards = new List<CardData>();
    }

    public void TakeEvent(QuestEvent newEvent) {
        foreach (CardData currCard in activeCards) {
            Debug.Log(currCard);
            Debug.Log(currCard.GetQuestStatus());
            if (currCard.questEvent.Compare(newEvent)) {
                currCard.IncCount();
                if (currCard.CheckCompletion()) {
                    Debug.Log(currCard.ToString() + " has been completed");
                    CompleteCard(currCard);
                }
            }
        }
    }

    void CompleteCard(CardData inputCard) {
        inputCard.SetQuestStatus(true);
        Debug.Log("Card's new status " + inputCard.GetQuestStatus());
    }

    public void AddCard(CardData inputCard) { activeCards.Add(inputCard); }

    public void RemoveCard(CardData inputCard) { activeCards.Remove(inputCard); }
}
