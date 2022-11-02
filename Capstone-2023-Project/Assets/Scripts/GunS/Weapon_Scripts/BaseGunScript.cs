using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunScript : MonoBehaviour
{
    public GameObject firePoint;
    public GunStats gunStats;
    public GunData gunData;
    protected WeaponManager WM;
    private float nextTimeToFire = 0f;

    protected virtual void Start() {
        WM = GameObject.Find("PlayerObject").GetComponent<WeaponManager>();
        firePoint = this.transform.parent.transform.Find("FirePoint").gameObject;
    }

    void Update() {
        bool inputRegistered;

        if (gunStats.fireType == GunEnums.FireType.Automatic) {
            inputRegistered = Input.GetButton("Fire1");
        } else {
            inputRegistered = Input.GetButtonDown("Fire1");
        }

        if (inputRegistered && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / gunStats.fireRate;
            WM.UpdateAmmo();
            FireEvent();
        }
    }

    public abstract void FireEvent();
}  
