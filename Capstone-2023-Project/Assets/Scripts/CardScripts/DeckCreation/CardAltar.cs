using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAltar : MonoBehaviour
{
    [SerializeField]
    GameObject AddCardCanvas;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            NewCardSelect NCS = Instantiate(AddCardCanvas, Vector3.zero, Quaternion.identity).GetComponent<NewCardSelect>();
            NCS.Altar = this;
        }
    }

    public void End() {
        Destroy(this.gameObject);
    }
}
