using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    List<CardObj> activeCards;

    private void Start() {
        activeCards = new List<CardObj>();
    }

    public void TakeEvent(QuestEvent newEvent) {
        foreach (CardObj currCard in activeCards) {
            Debug.Log(currCard);
            Debug.Log(currCard.GetQuestStatus());
            if (currCard.GetData().questEvent.Compare(newEvent)) {
                currCard.IncCount();
                if (currCard.CheckCompletion()) {
                    Debug.Log(currCard.ToString() + " has been completed");
                    CompleteCard(currCard);
                }
            }
        }
    }

    void CompleteCard(CardObj inputCard) {
        inputCard.SetQuestStatus(true);
        Debug.Log("Card's new status " + inputCard.GetQuestStatus());
    }

    public void AddCard(CardObj inputCard) { activeCards.Add(inputCard); }

    public void RemoveCard(CardObj inputCard) { activeCards.Remove(inputCard); }
}
