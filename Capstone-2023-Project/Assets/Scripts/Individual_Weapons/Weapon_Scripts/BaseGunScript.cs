using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunScript : MonoBehaviour
{
    public GameObject firePoint;
    public WeaponObj weaponObject;
    [SerializeField]
    protected WeaponDataObj weaponData;
    protected GameObject projectileObj;
    protected WeaponManager WM;
    private float nextTimeToFire = 0f;

    private void Start() {
        WM = GameObject.Find("PlayerObject").GetComponent<WeaponManager>();
        firePoint = this.transform.parent.transform.Find("FirePoint").gameObject;
        weaponData = WeaponDataObj.CreateFromJSON(weaponObject.jsonData.text);
        projectileObj = weaponObject.projectile;
    }

    void Update() {
        bool inputRegistered = false;

        if (weaponData.automatic) {
            inputRegistered = Input.GetButton("Fire1");
        } else {
            inputRegistered = Input.GetButtonDown("Fire1");
        }

        if (inputRegistered && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / weaponData.fireRate;
            WM.UpdateAmmo();
            FireEvent();
        }
    }

    public WeaponObj GetWeaponObj() {
        return weaponObject;
    }

    public abstract void FireEvent();
}  
