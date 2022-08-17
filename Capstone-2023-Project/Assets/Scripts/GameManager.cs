using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> buttons;
    GameObject playerObj;

    private void Start() {
        playerObj = GameObject.Find("PlayerObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown("e")) {
            ActivateCardSelection();
        }
    }

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
