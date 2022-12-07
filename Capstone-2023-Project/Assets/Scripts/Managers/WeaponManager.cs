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
    [SerializeField]
    GameObject firePoint;
    private int ammoCount;
    private int currindex = 1;
    private WeaponObj weaponObj;
    private GameObject currWeapon;

    [SerializeField]
    Text ammoCounterText;
    [SerializeField]
    Text weaponListText;
    [SerializeField]
    float scrollwheelScale;

    UIGuns uiGuns;

    private void Start() {
        uiGuns = GameObject.FindGameObjectWithTag("UIGuns").GetComponent<UIGuns>();
        SetupPlayer();
    }

    private void Update() {
        float currScollInput = Input.mouseScrollDelta.y * scrollwheelScale;
        if (currScollInput > .5f && currindex < weaponInventory.Count - 1) {
            ChangeWeapon(1);
        } else if (currScollInput < -.5f && currindex > 0) {
            ChangeWeapon(-1);
        }
        // swap weapons if there are more weapons in the list, else just unarm player
        // if (ammoCount <= 0) {
        //     if (currindex >= weaponInventory.Count) {
        //         Destroy(currWeapon);
        //     } else {
        //         SetWeapon(weaponInventory[currindex]);
        //         currindex++;
        //     }
        // }
        // demo screen prints
        // ammoCounterText.text = "Ammo: " + ammoCount;
        // string tempString = "";
        // for (int i = currindex - 1; i < weaponInventory.Count; i++) {
        //     tempString += weaponInventory[i].name + " ";
        // }
        // weaponListText.text = "Weapons: " + tempString;
    }

    public void SetupPlayer() {
        currindex = 0;
        if (weaponInventory.Count != 0) {
            SetWeaponAtInd(currindex, true);
        }
        foreach(GameObject go in weaponInventory) {
            uiGuns.AddNewGun(go.GetComponent<BaseGunScript>().GetCardSprite());
        }
    }

    public List<GunStatusReport> GetGunStatus() {
        List<GunStatusReport> returnList = new List<GunStatusReport>(weaponInventory.Count);
        foreach (GameObject gun in weaponInventory) {
            returnList.Add(gun.GetComponent<BaseGunScript>().GetReport());
        }
        return returnList;
    }

    public int CurrInd() { return currindex; }

    public GameObject GetCurrGun() { return weaponInventory[currindex]; }

    private void SetWeaponAtInd(int ind, bool status) {
        weaponInventory[ind].GetComponent<BaseGunScript>().SetGameEnabled(status);
    }

    public void ChangeWeaponToIndex(int newIndex) {
        ChangeWeapon((int)Mathf.Repeat(newIndex - currindex, weaponInventory.Count - 1));
    }

    //Switches weapon and updates in ui. 
    private void ChangeWeapon(int indChange) {
        SetWeaponAtInd(currindex, false);
        currindex += indChange;
        SetWeaponAtInd(currindex, true);
        uiGuns.SwitchGun(currindex);
    }

    // take in prefab to add to weapon list
    public void AddWeapon(GameObject newWeapon) {

        Debug.Log("adding weapon");

        GameObject gunObj = Instantiate(newWeapon, this.transform);
        BaseGunScript gunInfo = gunObj.GetComponent<BaseGunScript>();
        gunInfo.firePoint = firePoint;
        weaponInventory.Add(gunObj);
        if (weaponInventory.Count == 1) {
            SetWeaponAtInd(currindex, true);
        }
        uiGuns.AddNewGun(gunInfo.GetCardSprite());

        //When we get a new gun, it feels good to switch to it. 
        ChangeWeaponToIndex(weaponInventory.Count - 1);
    }

    public void UpdateAmmo() {
        ammoCount -= 1;
    }
}
