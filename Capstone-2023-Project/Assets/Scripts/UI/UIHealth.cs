using System.Collections.Generic;
using System.Collections;
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
        StartCoroutine(DropCard(hpCards[hpCards.Count - 1].transform));
        hpCards.RemoveAt(hpCards.Count - 1);
    }

    //Animate card off and kill it
    //-x^2 + 2x
    IEnumerator DropCard(Transform card) {

        float distScale = 30f;
        float timeScale = 15f;
        float timeLimit = 50f;

        float t = 0;
        Vector3 posOrig = card.position;

        while(t < timeLimit) {

            t += Time.deltaTime * timeScale;

            float yDiff = ( -(Mathf.Pow(t, 2)) + 2 * t ) * distScale;

            card.position = new Vector3(posOrig.x, posOrig.y + yDiff, posOrig.z);

            yield return null;
        }

        Destroy(card.gameObject);
    }

}