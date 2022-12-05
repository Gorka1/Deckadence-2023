using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHand : MonoBehaviour {

    List<Image> hand = new List<Image>();

    void Start() {

        Globals.uiHand = this;

        Image [] cards = GetComponentsInChildren<Image>();

        foreach(Image i in cards) {
            Debug.Log("added");
            hand.Add(i);
            i.sprite = null;
        }
    }

    //Remove a card from the hand. 
    public void RemoveCard(int index) {
        Debug.Log("removed from hand");
        hand[index].sprite = null;
    }

    //Add a card to the hand.
    public void AddCard(int index, CardData card) {
        Debug.Log("added to hand");
        if(hand[index].sprite != null) {
            Debug.Log("ERR: card added to hand at index with a card in already");
        }
        hand[index].sprite = card.cardGraphic;
    }
    
}