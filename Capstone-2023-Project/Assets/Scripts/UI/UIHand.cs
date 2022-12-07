using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHand : MonoBehaviour {

    List<Image> hand = new List<Image>();

    //TODO this is a placeholder for the December demo- replace with proper adding/removing
    Color transparency = new Color(1, 1, 1, 0.25f);
    Color opaque = new Color(1, 1, 1, 1);

    void Start() {

        Image [] cards = GetComponentsInChildren<Image>();

        for(int i = 0; i < cards.Length; i++) {
            hand.Add(cards[i]);
            RemoveCard(i);
        }
    }

    //Remove a card from the hand. 
    public void RemoveCard(int index) {
        hand[index].sprite = null;
        hand[index].color = transparency;
    }

    //Add a card to the hand.
    public void AddCard(int index, CardData card) {
        if(hand[index].sprite != null) {
            Debug.Log("ERR: card added to hand at index with a card in already");
        }
        hand[index].sprite = card.cardGraphic;
        hand[index].color = opaque;
    }
    
}