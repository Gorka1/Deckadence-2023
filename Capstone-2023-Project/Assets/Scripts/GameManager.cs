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
    [SerializeField]
    CardData testCard;

    private void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deckM = this.GetComponent<DeckManager>();
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
}
