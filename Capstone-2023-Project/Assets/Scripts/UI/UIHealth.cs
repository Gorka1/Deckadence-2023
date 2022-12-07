using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    [SerializeField] GameObject hpCardPrefab;   //Prefab for HP cards.
    List<Image> hpCards = new List<Image>();

    public void Start() {
        Globals.uiHealth = this;
    }

    public void IncrementHP() {
        GameObject newCard = Instantiate(hpCardPrefab, this.transform);
        newCard.gameObject.SetActive(true);
        hpCards.Add(newCard.GetComponent<Image>());
    }

    public void DecrementHP() {
        Destroy(hpCards[hpCards.Count - 1]);
        hpCards.RemoveAt(hpCards.Count - 1);
    }

}