using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    [SerializeField]
    GameObject cardUIPrefab;
    DeckManager DeckM;
    [SerializeField]
    List<CardData> hotbarList;
    [SerializeField]
    List<CardUIScript> cardUIList;
    CardUIScript currSelected = null;

    private void Start() {
        DeckM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
        CreateHandList(DeckM.GetHandList());
    }

    private void Update() {
        List<CardData> currList = DeckM.GetHandList();
        // foreach (var x in currList){
        //     Debug.Log(x.ToString());
        // }
        // Debug.Log("printing hotbar list");
        // foreach (var x in hotbarList) {
        //     Debug.Log(x.ToString());
        // }
        // if (hotbarList == null || hotbarList.Equals(currList)) {
        //     CreateHandList(currList);
        // }
        foreach (CardData handCard in currList) {
            if (!hotbarList.Contains(handCard)) {
                AddToBar(handCard);
            }
        }
        foreach (CardData uiCard in hotbarList) {
            if (!currList.Contains(uiCard)) {
                RemoveFromBar(uiCard);
            }
        }
        SetSelected(currList[DeckM.GetHandListInd()]);
    }

    private void CreateHandList(List<CardData> newList) {
        //ClearBar();
        hotbarList = new List<CardData>();
        foreach (CardData card in newList) {
            AddToBar(card);
            hotbarList.Add(card);
        }
    }
    private void AddToBar(CardData newCard) {
        CardUIScript currCardUI = Instantiate(cardUIPrefab, this.transform).GetComponent<CardUIScript>(); 
        currCardUI.SetCard(newCard);
        cardUIList.Add(currCardUI);
        hotbarList.Add(newCard);
    }
    private void RemoveFromBar(CardData removedCard) {
        int posOfCardToRemoveUIList = -1;
        int posOfCardToRemoveHotbarList = -1;
        for (int i = 0; i < cardUIList.Count; i++) {
            if (cardUIList[i].card.Equals(removedCard)) {
                posOfCardToRemoveUIList = i;
            }
        }
        for (int i = 0; i < hotbarList.Count; i++) {
            if (hotbarList[i].Equals(removedCard)) {
                posOfCardToRemoveHotbarList = i;
            }
        }
        if (posOfCardToRemoveUIList != -1) {
            CardUIScript currCardUI = cardUIList[posOfCardToRemoveUIList];
            cardUIList.RemoveAt(posOfCardToRemoveUIList);
            //currCardUI.DestroySelf();
            Destroy(currCardUI.gameObject);
        }
        if (posOfCardToRemoveHotbarList != -1) {
            hotbarList.RemoveAt(posOfCardToRemoveHotbarList);
        }
    }
    private void SetSelected(CardData newSelected) {
        // this gets fucked up with duplicates in the hand
        if (!newSelected.Equals(currSelected)) {
            if (currSelected != null){
                currSelected.Deselect();
            }
            foreach(CardUIScript currScript in cardUIList) {
                if (currScript.card.Equals(newSelected)) {
                    currScript.Select();
                    currSelected = currScript;
                }
            }
        }
    }
    // private void ClearBar() {
    //     foreach (GameObject cardUI in cardUIList) {
    //         Destroy(cardUI);
    //     }
    //     cardUIList.Clear();
    // }
}
