using UnityEngine;

public class UIHealth : MonoBehaviour {

    [SerializeField] GameObject hpCard;

    public void Start() {
        Globals.uiHealth = this;
    }

    public void IncrementHP() {
        //copy the highest child
    }

    public void DecrementHP() {
        //delete the highest child 
    }


}