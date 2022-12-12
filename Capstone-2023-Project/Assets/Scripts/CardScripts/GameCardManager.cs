using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameCardData {
    [SerializeField]
    public CardData CD;
    [SerializeField]
    public int count;
}
public class GameCardManager : MonoBehaviour
{
    [SerializeField]
    public List<GameCardData> MainCardList;
    public List<CardData> CurrCardList;
    public int maxDeckSize = 10;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject[] searchObj = GameObject.FindGameObjectsWithTag(this.transform.tag);
        if (searchObj.Length != 1) {
            Destroy(this.gameObject);
        }
    }

    public CardData GetRandomCardMaster() {
        return MainCardList[Random.Range(0, MainCardList.Count - 1)].CD;
    }
    public CardData GetRandomCardDeck() {
        return CurrCardList[Random.Range(0, CurrCardList.Count - 1)];
    }
}
