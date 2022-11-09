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
    [SerializeField]
    CardData testCard;
    [SerializeField]
    GameObject testGun;
    bool startRun = false;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        WM = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        deckM = this.GetComponent<DeckManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!startRun) {
        //     QueueM.ActivateFirstTwoQuests();
        //     startRun = true;
        // }
        if (Input.GetKeyDown("f")) {    // start the deck system
            deckM.Init();
        }
        if (Input.GetButtonDown("restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown("e")) {        // add a gun to the weapon manager
            WM.AddWeapon(testGun);
        }
        if (Input.GetKeyDown("q")) {        // activate a card
            deckM.UseCurrCard();
        }
        // 1-4 card selection
        if (Input.GetKeyDown("1")) {
            deckM.SetHandInd(0);
            deckM.UseCurrCard();
        }
        if (Input.GetKeyDown("2")) {
            deckM.SetHandInd(1);
            deckM.UseCurrCard();
        }
        if (Input.GetKeyDown("3")) {
            deckM.SetHandInd(2);
            deckM.UseCurrCard();
        }
        if (Input.GetKeyDown("4")) {
            deckM.SetHandInd(3);
            deckM.UseCurrCard();
        }
        // if (Input.GetButtonDown("use card") || Input.GetKeyDown("e")) {
        //     QueueM.UseCard();
        // }
        // if (Input.GetButtonDown("discard card") || Input.GetKeyDown("q")) {
        //     QueueM.DiscardCard();
        // }
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
        // if (Input.GetKeyDown("m")) {    // create and send event
        //     List<string> testConditions = new List<string>();
        //     testConditions.Add("test");
        //     EventObj testEvent = new EventObj(QuestEnums.SignalOrigin.Player, testConditions);
        //     Debug.Log(testEvent);
        //     TakeQuestEvent(testEvent);
        // }
        // if (Input.GetKeyDown("n")) {    // actually start quests
        //     QueueM.ActivateFirstTwoQuests();
        // }
        // if (Input.GetKeyDown("b")) {    // get rid of card in queue
        //     QueueM.DiscardCard();
        // }
    }

    public DeckManager GetDeckM() { return deckM; }
    public WeaponManager GetWeaponM() { return WM; }
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
