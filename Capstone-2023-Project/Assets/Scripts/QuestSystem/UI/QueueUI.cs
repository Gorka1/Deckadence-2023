using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueUI : MonoBehaviour
{
    CardObj[] cards;
    public Image[] cardsSprites;
    

    public QueueManager queueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cards = queueManager.GetTopThree();

        for (int i = 0; i < cards.Length; i++)
        {
            cardsSprites[i].sprite = cards[i].GetData().cardGraphic;
        }
    }
}
