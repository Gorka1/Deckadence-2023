using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    List<CardObj> activeCards;

    public object CardQueue { get; internal set; }

    private void Start() {
        activeCards = new List<CardObj>();
    }

    public void TakeEvent(EventObj newEvent) {
        foreach (CardObj currCard in activeCards) {
            // Debug.Log(currCard);
            // Debug.Log(currCard.GetQuestStatus());
            if (newEvent.Compare(currCard.GetData().questEvent)) {
                Debug.Log("Common card found");
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
        inputCard.ApplyEffect();
    }

    public void AddCard(CardObj inputCard) { activeCards.Add(inputCard); }

    public void RemoveCard(CardObj inputCard) { activeCards.Remove(inputCard); }
}
