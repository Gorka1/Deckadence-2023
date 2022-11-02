using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [SerializeField]
    // List<CardObj> activeCards;

    // public object CardQueue { get; internal set; }

    // private void Start() {
    //     activeCards = new List<CardObj>();
    // }

    // public void TakeEvent(EventObj newEvent) {
    //     foreach (CardObj currCard in activeCards) {
    //         if (newEvent.Compare(currCard.GetData().questEvent)) {
    //             Debug.Log("Common card found");
    //             currCard.IncCount();
    //             if (currCard.CheckCompletion()) {
    //                 Debug.Log(currCard.ToString() + " has been completed");
    //                 CompleteCard(currCard);
    //             }
    //         }
    //     }
    // }

    // public bool EngageTopCard() {
    //     Debug.Log("EngageTopCard() called");
    //     if (activeCards[0].GetQuestStatus()) {
    //         ActivateCard(activeCards[0]);
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    // void CompleteCard(CardObj inputCard) {
    //     inputCard.SetQuestStatus(true);
    // }

    // void ActivateCard(CardObj inputCard) {
    //     Debug.Log("CompletedCard: " + inputCard.ToString());
    //     inputCard.ApplyEffect();
    // }

    // public void AddCard(CardObj inputCard) { activeCards.Add(inputCard); }

    // public void RemoveCard(CardObj inputCard) { activeCards.Remove(inputCard); }
    // public void RemoveTopCard() { activeCards.RemoveAt(0); }
}
