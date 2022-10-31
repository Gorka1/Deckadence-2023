using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : AbstractEffect
{
    [SerializeField]
    int value = 1;
    GunManager GM;
    public override void MainEffect() {
        Debug.Log("Increased damage to: " + this.transform.parent.name);
        GM = this.GetComponentInParent<GunManager>();
        if (GM != null) {
            GM.gunStats.dmg += value;
        }
    }

    public override void UndoEffect() {
        if (GM != null) {
            GM.gunStats.dmg -= value;
        }
    }
}
