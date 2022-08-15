using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunScript : MonoBehaviour
{
    public GameObject firePoint;
    public WeaponObj weaponObject;
    [SerializeField]
    protected WeaponDataObj weaponData;
    private float nextTimeToFire = 0f;

    private void Start() {
        weaponData = WeaponDataObj.CreateFromJSON(weaponObject.jsonData.text);
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
            FireEvent();
        }
    }

    public abstract void FireEvent();
}  
