using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunScript : MonoBehaviour
{
    public GameObject firePoint;
    public GunStats gunStats;
    public GunData gunData;
    [SerializeField]
    protected GameObject gunModel;
    protected WeaponManager WM;
    private float nextTimeToFire = 0f;
    bool gameEnabled = true;

    protected virtual void Start() {
        WM = GameObject.Find("PlayerObject").GetComponent<WeaponManager>();
        firePoint = this.transform.parent.transform.Find("FirePoint").gameObject;
    }

    void Update() {
        if (gameEnabled) {
            if (!gunModel.activeSelf) {
                gunModel.SetActive(true);
            }

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
        } else {
            if (gunModel.activeSelf) {
                gunModel.SetActive(false);
            }
        }
    }

    public GunStatusReport GetReport() {
        GunStatusReport returnData = new GunStatusReport();
        foreach (GameObject child in transform) {
            if (child.CompareTag("Effect")) {
                returnData.effectData.Add(child.GetComponent<AbstractEffect>().GetReport());
            }
        }
        return returnData;
    }

    public void SetGameEnabled(bool condition = true) { gameEnabled = condition; }
    public abstract void FireEvent();
}  
