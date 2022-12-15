using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAltar : MonoBehaviour
{
    [SerializeField]
    GameObject AddCardCanvas;
    PlayerMovement PlayerObject;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerObject = other.gameObject.GetComponent<PlayerMovement>();
            PlayerObject.moveEnabled = false;
            NewCardSelect NCS = Instantiate(AddCardCanvas, Vector3.zero, Quaternion.identity).GetComponent<NewCardSelect>();
            NCS.Altar = this;
        }
    }

    public void End() {
        PlayerObject.moveEnabled = true;
        Destroy(this.gameObject);
    }
}
