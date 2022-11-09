using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BaseGunScript
{
    public override void FireEvent() {
        Debug.Log("Single Shot Firing");
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(
            firePoint.transform.position,
            firePoint.transform.forward,
            out hit,
            gunStats.range
            )) {
            Debug.Log(hit.transform.name);
            Debug.Log(hit);
            NpcManager target = hit.transform.GetComponent<NpcManager>();
            if (target != null) {
                target.TakeDamage(gunStats.dmg);
            }
        }
    }
}