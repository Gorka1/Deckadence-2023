using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> masterDeckList;
    [SerializeField]
    List<GameObject> buttons;
    GameObject playerObj;
    [SerializeField]
    WeaponManager WM;
    DeckManager deckM;
    QuestManager QuestM;
    QueueManager QueueM;
    [SerializeField]
    CardData testCard;
    bool startRun = false;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deckM = this.GetComponent<DeckManager>();
        QuestM = this.GetComponent<QuestManager>();
        QueueM = this.GetComponent<QueueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!startRun) {
            QueueM.ActivateFirstTwoQuests();
            startRun = true;
        }
        if (Input.GetButtonDown("restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetButtonDown("use card") || Input.GetKeyDown("e")) {
            QueueM.UseCard();
        }
        if (Input.GetButtonDown("discard card") || Input.GetKeyDown("q")) {
            QueueM.DiscardCard();
        }
        // if (Input.GetKeyDown("e")) {
        //     // ActivateCardSelection();
        //     gunM.InputCard(deckM.GetHandCard());
        //     deckM.RemoveCurrCard();
        // }
        // if (Input.GetKeyDown("u")) {
        //     deckM.AddToDeck(testCard);
        // }
        // if (Input.GetKeyDown("i")) {
        //     deckM.AddToHand();
        // }
        // test event 
        if (Input.GetKeyDown("m")) {    // create and send event
            List<string> testConditions = new List<string>();
            testConditions.Add("test");
            EventObj testEvent = new EventObj(QuestEnums.SignalOrigin.Player, testConditions);
            Debug.Log(testEvent);
            TakeQuestEvent(testEvent);
        }
        // if (Input.GetKeyDown("n")) {    // actually start quests
        //     QueueM.ActivateFirstTwoQuests();
        // }
        // if (Input.GetKeyDown("b")) {    // get rid of card in queue
        //     QueueM.DiscardCard();
        // }
    }

    // for the individual weapons system
    public void ActivateCardSelection() {
        Cursor.lockState = CursorLockMode.Confined;
        foreach(GameObject button in buttons) {
            button.SetActive(true);
        }
        playerObj.GetComponent<PlayerMovement>().moveEnabled = false;
    }

    public void DeactivateCardSelection() {
        Cursor.lockState = CursorLockMode.Locked;
        foreach(GameObject button in buttons) {
            button.SetActive(false);
        }
        playerObj.GetComponent<PlayerMovement>().moveEnabled = true;
    }

    public void TakeQuestEvent(EventObj inputEvent) {
        Debug.Log("Event inputted, conditions: " + string.Join(", ", inputEvent.GetConditions()));
        // QuestM.TakeEvent(inputEvent);
    }

    public Vector3 GetPlayerPos() { return playerObj.transform.position; }
}
