using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GunStats gunStats;
    public GameObject firePoint;
    public GameObject projectileObj;
    public int ammoCount;
    float nextTimeToFire = 0f;
    [SerializeField]
    GameObject gunModel;

    // private void Start() {
    //     gunModel = GameObject.Find("GunModel");
    // }

    void Update() {
        FireUpdate();
    }

    private void FireUpdate() {
        bool inputRegistered = false;

        if (gunStats.automatic) {
            inputRegistered = Input.GetButton("Fire1");
        } else {
            inputRegistered = Input.GetButtonDown("Fire1");
        }

        if (inputRegistered && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / gunStats.fireRate;
            Fire();
        }
    }

    private void Fire() {
        GameObject bullet = Instantiate(projectileObj, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<BulletMovement>().Setup(firePoint.transform, gunStats.range, gunStats.dmg, gunStats.speed);
    }

    public void InputCard(CardData newCard) {
        if (newCard.testWeaponColor != null) {
            gunModel.GetComponent<Renderer>().material.color = newCard.testWeaponColor;
        }
    }
}
