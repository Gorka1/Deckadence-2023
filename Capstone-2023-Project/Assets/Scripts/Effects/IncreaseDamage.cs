using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : AbstractEffect
{
    [SerializeField]
    int value = 1;
    public override void MainEffect(GameObject GO) {
        Debug.Log("Applied effect to object: " + GO.name);
        GunManager GM = GO.GetComponent<GunManager>();
        if (GM != null) {
            GM.gunStats.dmg += value;
        }
    }
}
