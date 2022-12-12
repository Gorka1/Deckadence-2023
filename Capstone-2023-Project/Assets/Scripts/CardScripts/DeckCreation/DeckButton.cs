using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{
    public CardData currCard;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;
    bool setup = false;
    [SerializeField]
    DeckCreator DC;

    private void Start() {
        cardSprite = this.GetComponent<Image>();
        DC = GameObject.FindGameObjectWithTag("DeckMenu").GetComponent<DeckCreator>();
    }

    private void Update() {
        if (setup && currCard != null) {
            cardText.text = currCard.cardName;
            cardSprite.sprite = currCard.cardGraphic;
            setup = false;
        }
    }

    public void SetUp(CardData newCard) {
        currCard = newCard;
        setup = true;
    }

    public void OnClick() {
        DC.RemoveCard(currCard);
        DestroySelf();
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
