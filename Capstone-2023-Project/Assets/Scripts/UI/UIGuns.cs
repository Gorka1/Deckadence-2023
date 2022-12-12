using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIGuns : MonoBehaviour {

    [SerializeField] GameObject cardPrefab;


    //For each number of cards, positions. 
    [SerializeField] Transform[] t1;  
    [SerializeField] Transform[] t2;
    [SerializeField] Transform[] t3;

    //Ordered list of card positions. 
    Transform[][] positions = new Transform[3][];

    List<Image> cards = new List<Image>();

    public void Awake() {
        positions[0] = t1;
        positions[1] = t2;
        positions[2] = t3;
    }

    //Switch which gun we're on.
    public void SwitchGun(int indexSwitchTo) {

        for(int i = 0; i < cards.Count; i++) {
            Image card = cards[(int)(Mathf.Repeat(i + indexSwitchTo, cards.Count))];
            SlideTo(card.transform, positions[cards.Count - 1][i].position);
            card.GetComponent<Canvas>().sortingOrder = cards.Count - i;
        }

    }

    //Creates a new card with the card image.
    public void AddNewGun(Sprite gunCardSprite) {

        Image newCard = Instantiate(cardPrefab, this.transform).GetComponent<Image>();
        newCard.gameObject.SetActive(true);
        newCard.sprite = gunCardSprite;
        cards.Add(newCard);

        //update positions
        for(int i = 0; i < cards.Count; i++) {
            bool n = cards[i] == null;
            SlideTo(cards[i].transform, positions[cards.Count - 1][i].position);
        }
    }

    void SlideTo(Transform thing, Vector3 pos) {
        //TODO this should be a nice lerping coroutine, but for now, just transform.
        StartCoroutine(SlideToCoroutine(thing, pos));
    }

    float slideSpeed = 500f;
    IEnumerator SlideToCoroutine(Transform thing, Vector3 pos) {

        while(thing.position != pos) {

            Vector3 distance = pos - thing.position;
            Vector3 travel = Vector3.MoveTowards(Vector3.zero, distance, slideSpeed * Time.deltaTime);

            thing.Translate(travel);

            yield return null;
        }
    }
}