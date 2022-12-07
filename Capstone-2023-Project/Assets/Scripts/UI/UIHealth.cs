using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    [SerializeField] GameObject hpCardPrefab;   //Prefab for HP cards.
    List<Image> hpCards = new List<Image>();

    public void IncrementHP() {
        GameObject newCard = Instantiate(hpCardPrefab, this.transform);
        newCard.gameObject.SetActive(true);
        hpCards.Add(newCard.GetComponent<Image>());
    }

    public void DecrementHP() {
        if(hpCards.Count <= 0) {
            Debug.Log("Tried to remove hp card but none left");
            return;
        }
        Destroy(hpCards[hpCards.Count - 1]);
        hpCards.RemoveAt(hpCards.Count - 1);
    }

}