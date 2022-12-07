using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBasedUI : MonoBehaviour
{
    GameManager GM;
    DeckManager DM;
    WeaponManager WM;
    PlayerManager PM;
    [SerializeField]
    Text CardText;
    [SerializeField]
    Text WeaponText;
    [SerializeField]
    Text PointsText;
    [SerializeField]
    Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DM = GM.GetComponentInParent<DeckManager>();
        WM = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string cardText = "Hand: ";
        foreach (CardData cd in DM.GetHandList()) {
            if (cd != null) {
                cardText += cd.cardName + " -";
            } else {
                cardText += "Null -";
            }
        }
        CardText.text = cardText;
        string weaponText = "Weapons: ";
        foreach (GunStatusReport gs in WM.GetGunStatus()) {
            weaponText += gs.name;
        }
        WeaponText.text = weaponText;
        PointsText.text = "Points: " + GM.GetPlayerPoints();
        HealthText.text = "Health: " + PM.GetCurrHealth();
    }
}
