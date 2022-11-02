using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject weapon;
    GunData gunData;
    GameManager GM;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gunData = weapon.GetComponent<BaseGunScript>().gunData;
        this.GetComponent<Image>().sprite = gunData.cardIcon;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("PlayerObject");
        // this.GetComponent<Button>().set = OnClickEvent;
    }

    public void OnClickEvent() {
        player.GetComponent<WeaponManager>().AddWeapon(weapon);
        GM.DeactivateCardSelection();
    }
}
