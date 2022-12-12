using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCreator : MonoBehaviour
{
    GameCardManager GCM;
    [SerializeField]
    GameObject DeckButton;  // represents the cards in the deck
    [SerializeField]
    GameObject SelectButton;  // represents the cards in the player's inventory
    [SerializeField]
    GameObject DeckPanel;
    [SerializeField]
    GameObject SelectPanel;
    [SerializeField]
    TMPro.TextMeshProUGUI deckSizeText;
    Dictionary<string, int> masterCardCount;
    Dictionary<string, SelectButton> associatedSelect;
    int deckSize;
    private void Start() {
        Debug.Log("started deck creator");
        masterCardCount = new Dictionary<string, int>();
        associatedSelect = new Dictionary<string, SelectButton>();
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        foreach (GameCardData card in GCM.MainCardList){
            Debug.Log("Adding:" + card.CD.cardName);
            masterCardCount.Add(card.CD.cardName, card.count);
        }
        foreach (CardData card in GCM.CurrCardList) {
            masterCardCount[card.cardName] -= 1;
            CreateDeckButton(card);
            deckSize++;
        }
        foreach (GameCardData card in GCM.MainCardList){
            CreateSelectButton(card.CD);
        }
        deckSizeText.text = "Deck: " + deckSize.ToString() + "/" + GCM.maxDeckSize.ToString();
    }

    public bool SelectCard(CardData selectCard) {
        if (masterCardCount[selectCard.cardName] <= 0 || GCM.CurrCardList.Count >= GCM.maxDeckSize) {
            return false;
        } else {
            masterCardCount[selectCard.cardName] -= 1;
            CreateDeckButton(selectCard);
            GCM.CurrCardList.Add(selectCard);
            deckSize++;
            deckSizeText.text = "Deck: " + deckSize.ToString() + "/" + GCM.maxDeckSize.ToString();
            return true;
        }
    }

    public void RemoveCard(CardData removeCard) {
        masterCardCount[removeCard.cardName] += 1;
        GCM.CurrCardList.Remove(removeCard);
        associatedSelect[removeCard.cardName].count += 1;
        deckSize--;
        deckSizeText.text = "Deck: " + deckSize.ToString() + "/" + GCM.maxDeckSize.ToString();
    }

    private void CreateDeckButton(CardData newCard) {
        GameObject currButt = Instantiate(DeckButton, DeckPanel.transform);
        currButt.GetComponent<DeckButton>().SetUp(newCard);
    }

    private void CreateSelectButton(CardData newCard) {
        GameObject currButt = Instantiate(SelectButton, SelectPanel.transform);
        SelectButton newSelect = currButt.GetComponent<SelectButton>();
        newSelect.SetUp(newCard, masterCardCount[newCard.cardName]);
        associatedSelect.Add(newCard.cardName, newSelect);
    }
}
