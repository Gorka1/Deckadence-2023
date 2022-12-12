using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardSelect : MonoBehaviour
{
    [SerializeField]
    GameObject CardButton;
    [SerializeField]
    GameObject ButtonPanel;
    [SerializeField]
    int numOfNewCards;
    GameObject MainCanvas;
    MouseLook Mouse;
    public CardAltar Altar;

    private void Start() {
        MainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        MainCanvas.SetActive(false);
        Mouse = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        Mouse.active = false;
        Cursor.lockState = CursorLockMode.None;
        for (int i = 0; i < numOfNewCards; i++) {
            NewCardButton currBut = Instantiate(CardButton, ButtonPanel.transform).GetComponent<NewCardButton>();
            currBut.NCS = this;
        }
    }

    public void End() {
        MainCanvas.SetActive(true);
        Mouse.active = true;
        Cursor.lockState = CursorLockMode.Locked;
        Altar.End();
        Destroy(this.gameObject);
    }
}
