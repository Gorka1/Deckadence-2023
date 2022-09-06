using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUIScript : MonoBehaviour
{
    [SerializeField]
    Image imageComp;
    public int cardID;
    public CardData card;
    bool selected = false;

    private void Start() {
        imageComp = this.GetComponent<Image>();
    }

    public void SetCard(CardData newCard) {
        card = newCard;
        cardID = newCard.cardID;
        //imageComp.sprite = newCard.cardGraphic;
    }

    public void Select() {
        imageComp.color = Color.red;
        selected = true;
    }

    public void Deselect() {
        imageComp.color = Color.white;
        selected = false;
    }

    public bool GetSelectedValue() { return selected; }
    public void DestroySelf() { Destroy(this); }
}
