using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQueue : MonoBehaviour
{
    [SerializeField]
    CardObj[] cards;
    public Image[] cardsSprites;
    [SerializeField]
    List<Vector3> SpriteStartPos;
    [SerializeField]
    float CardYShift = 20f;


    public QueueManager queueManager;

    // Start is called before the first frame update
    void Start()
    {
        SpriteStartPos = new List<Vector3>();
        for (int i = 0; i < cardsSprites.Length; i++) {
            SpriteStartPos.Add(cardsSprites[i].gameObject.GetComponent<RectTransform>().position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cards = queueManager.GetTopThree();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null)
            {
                cardsSprites[i].sprite = cards[i].GetData().cardGraphic;
                // if (cards[i].GetQuestStatus()) {
                //     cardsSprites[i].gameObject.GetComponent<RectTransform>().SetPositionAndRotation(
                //         new Vector3(SpriteStartPos[i].x, SpriteStartPos[i].y + CardYShift, SpriteStartPos[i].z),
                //         Quaternion.identity);
                // } else {
                //     cardsSprites[i].gameObject.GetComponent<RectTransform>().SetPositionAndRotation(
                //         SpriteStartPos[i],
                //         Quaternion.identity);
                // }
                print(cards[i].GetData().cardGraphic);
            }
        }
        // if there's a positive diff btwn cardsSprites.length - cards.length (n)
        // then there are less than 3 cards in the whole queue
        // you have to clear the sprite of the last n image in cardsSprites
    }
}