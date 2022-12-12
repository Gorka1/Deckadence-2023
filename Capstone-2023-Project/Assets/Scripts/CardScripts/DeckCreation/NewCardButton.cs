using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCardButton : MonoBehaviour
{
    CardData currCard;
    GameCardManager GCM;
    DeckManager DM;
    public NewCardSelect NCS;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;

    private void Start() {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
        currCard = GCM.GetRandomCardMaster();
        cardSprite.sprite = currCard.cardGraphic;
        cardText.text = currCard.cardName;
    }

    public void OnClick() {
        DM.AddToDeck(currCard);
        NCS.End();
    }
}
