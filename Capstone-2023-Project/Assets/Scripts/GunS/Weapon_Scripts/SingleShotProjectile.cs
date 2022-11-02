using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotProjectile : BaseGunScript
{
    public GameObject projectileObj;

    public override void FireEvent() {
        GameObject bullet = Instantiate(projectileObj, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<BulletMovement>().Setup(firePoint.transform, gunStats.range, gunStats.dmg, gunStats.speed);
    }

    // public void InputCard(CardData newCard) {
    //     if (newCard.testWeaponColor != null) {
    //         gunModel.GetComponent<Renderer>().material.color = newCard.testWeaponColor;
    //     }
    // }
}
