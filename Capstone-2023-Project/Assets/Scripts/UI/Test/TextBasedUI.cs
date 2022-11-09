using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBasedUI : MonoBehaviour
{
    GameManager GM;
    DeckManager DM;
    WeaponManager WM;
    [SerializeField]
    Text CardText;
    [SerializeField]
    Text WeaponText;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DM = GM.GetComponentInParent<DeckManager>();
        WM = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string cardText = "Hand: ";
        foreach (CardData cd in DM.GetHandList()) {
            if (cd != null) {
                cardText += cd.name + " ";
            } else {
                cardText += " Null ";
            }
        }
        CardText.text = cardText;
        string weaponText = "Weapons: ";
        foreach (GunStatusReport gs in WM.GetGunStatus()) {
            weaponText += gs.name;
        }
        WeaponText.text = weaponText;
    }
}
