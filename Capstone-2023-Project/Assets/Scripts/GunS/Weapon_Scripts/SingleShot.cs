using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BaseGunScript
{
    [SerializeField]
    GameObject propProjectile;
    public override void FireEvent() {
        Debug.Log("Single Shot Firing");
        RaycastHit hit = new RaycastHit();

        // TODO: spawn the propProjectile towards the shot
        // it doesn't go forward, it just goes down
        // GameObject bullet = Instantiate(propProjectile, propFirePoint.transform.position, propFirePoint.transform.rotation);
        // bullet.GetComponent<BulletMovement>().Setup(propFirePoint.transform, 10f, 0, 20f);

        if (Physics.Raycast(
            firePoint.transform.position,
            firePoint.transform.forward,
            out hit,
            gunStats.range
            )) {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(firePoint.transform.position, firePoint.transform.forward,Color.green, 5f);
            NpcManager target = hit.transform.GetComponent<NpcManager>();
            if (target != null) {
                target.TakeDamage(gunStats.dmg);
            }
        }
    }
}