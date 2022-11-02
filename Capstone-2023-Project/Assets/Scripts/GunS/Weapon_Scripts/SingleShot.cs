using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BaseGunScript
{
    public override void FireEvent() {
        Debug.Log("Single Shot Firing");
        RaycastHit hit;

        if (Physics.Raycast(
            firePoint.transform.position,
            firePoint.transform.forward,
            out hit,
            weaponData.range
            )) {
            Debug.Log(hit.transform.name);
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null) {
                target.TakeDamage(weaponData.dmg);
            }
        }
    }
}