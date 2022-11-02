using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{   
    // How does this work:
    // you have a list of the current weapons in inventory
    // you instanciate the weapon in the player's hands
    // it keeps track of how many shots that have been fired
    // once it reaches the amount, it's done

    [SerializeField]
    List<GameObject> weaponInventory;
    [SerializeField]
    GameObject weaponPoint;
    private int ammoCount;
    private int currindex = 1;
    private WeaponObj weaponObj;
    private GameObject currWeapon;

    [SerializeField]
    Text ammoCounterText;
    [SerializeField]
    Text weaponListText;

    private void Start() {
        SetupPlayer();
    }

    private void Update() {
        // swap weapons if there are more weapons in the list, else just unarm player
        if (ammoCount <= 0) {
            if (currindex >= weaponInventory.Count) {
                Destroy(currWeapon);
            } else {
                SetWeapon(weaponInventory[currindex]);
                currindex++;
            }
        }
        // demo screen prints
        ammoCounterText.text = "Ammo: " + ammoCount;
        string tempString = "";
        for (int i = currindex - 1; i < weaponInventory.Count; i++) {
            tempString += weaponInventory[i].name + " ";
        }
        weaponListText.text = "Weapons: " + tempString;
    }

    private void SetWeapon(GameObject newWeapon) {
        // Destroy(currWeapon);
        // BaseGunScript gunScript = newWeapon.GetComponent<BaseGunScript>();
        // weaponObj = gunScript.GetWeaponObj();
        // ammoCount = WeaponDataObj.CreateFromJSON(weaponObj.jsonData.text).ammo;
        // currWeapon = Instantiate(newWeapon, weaponPoint.transform);
    }

    public void SetupPlayer() {
        currindex = 0;
        if (weaponInventory.Count != 0) {
            SetWeapon(weaponInventory[currindex]);
            currindex++;
        }
    }

    public void AddWeapon(GameObject newWeapon) {
        weaponInventory.Add(newWeapon);
    }

    public void UpdateAmmo() {
        ammoCount -= 1;
    }
}
