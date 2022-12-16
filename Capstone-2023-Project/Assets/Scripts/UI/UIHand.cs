using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHand : MonoBehaviour {

    List<Image> hand = new List<Image>();

    [SerializeField] Transform gunLoc; //for when the card is applied to the gun 

    //TODO this is a placeholder for the December demo- replace with proper adding/removing
    Color transparency = new Color(1, 1, 1, 0.25f);
    Color opaque = new Color(1, 1, 1, 1);

    //for selecting 
    float heightDefault;
    float heightSelectIncrease = 50;
    Vector3 scaleDefault;
    float scaleSelectIncrease = 1.2f;

    void Start() {

        Image [] cards = GetComponentsInChildren<Image>();

        for(int i = 0; i < cards.Length; i++) {
            hand.Add(cards[i]);
            RemoveCard(i);
        }

        heightDefault = cards[0].transform.position.y;
        scaleDefault = cards[0].transform.localScale;

    }

    //Remove a card from the hand. 
    public void RemoveCard(int index) {

        StartCoroutine(AnimateToGun(Instantiate(hand[index], hand[index].transform.position, hand[index].transform.rotation, this.transform.parent).transform));
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


    //Animate card to gun and kill it
    //-x^2 + 2x
    IEnumerator AnimateToGun(Transform c) {

        float timeScale = 2.25f;

        float t = 0;
        Vector3 posOrig = c.transform.position;
        Vector3 scaleOrig = c.transform.localScale;

        yield return null;


        while(t < 1) {

            t += Time.deltaTime * timeScale;

            c.transform.position = Vector3.Lerp(posOrig, gunLoc.position, t);

            c.transform.localScale = Vector3.Lerp(scaleOrig, Vector3.zero, t);

            yield return null;
        }

        Destroy(c.gameObject);

    }



    //Visually show a card in the hand is selected.
    public void Select(int index) {
        if(hand[index].transform.position.y == heightDefault) {
            ClearSelect();
            StartCoroutine(LerpSelect(hand[index].transform, heightDefault + heightSelectIncrease, scaleDefault * scaleSelectIncrease));
        }
    }

    public void ClearSelect() {
        foreach(Image card in hand) {
            if(card.transform.position.y != heightDefault) {
                //does this even work. TODO
                StopCoroutine(LerpSelect(card.transform, heightDefault + heightSelectIncrease, scaleDefault * scaleSelectIncrease));
                StartCoroutine(LerpSelect(card.transform, heightDefault, scaleDefault));
            }
        }
    }

    //Lerp the card to select/unselect height and size.
    float lerpSpeed = 100f;
    IEnumerator LerpSelect(Transform thing, float destY, Vector3 destScale) {

        //TOOD lerp 

        yield return null;

    }
    
}