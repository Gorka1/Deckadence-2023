using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> buttons;
    GameObject playerObj;
    [SerializeField]
    GunManager gunM;
    DeckManager deckM;
    QuestManager QuestM;
    QueueManager QueueM;
    [SerializeField]
    CardData testCard;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deckM = this.GetComponent<DeckManager>();
        QuestM = this.GetComponent<QuestManager>();
        QueueM = this.GetComponent<QueueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown("e")) {
            // ActivateCardSelection();
            gunM.InputCard(deckM.GetHandCard());
            deckM.RemoveCurrCard();
        }
        if (Input.GetKeyDown("u")) {
            deckM.AddToDeck(testCard);
        }
        if (Input.GetKeyDown("i")) {
            deckM.AddToHand();
        }
        // test event 
        if (Input.GetKeyDown("m")) {
            List<string> testConditions = new List<string>();
            testConditions.Add("test");
            QuestEvent testEvent = ScriptableObject.CreateInstance("QuestEvent") as QuestEvent;
            testEvent.Init(
                QuestEnums.SignalOrigin.Player,
                testConditions
            );
            Debug.Log(testEvent);
            TakeQuestEvent(testEvent);
        }
        if (Input.GetKeyDown("n")) {
            QueueM.ActivateFirstTwoQuests();
        }
        if (Input.GetKeyDown("b")) {
            QueueM.DiscardCard();
        }
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

    public void TakeQuestEvent(QuestEvent inputEvent) {
        QuestM.TakeEvent(inputEvent);
    }


}
