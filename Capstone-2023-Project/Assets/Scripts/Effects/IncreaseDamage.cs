using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : AbstractEffect
{
    [SerializeField]
    int value = 1;
    GunManager GM;
    public override void MainEffect(GameObject GO) {
        Debug.Log("Increased damage to: " + GO.name);
        GM = GO.GetComponent<GunManager>();
        if (GM != null) {
            GM.gunStats.dmg += value;
        }
    }

    public override void UndoEffect(GameObject GO) {
        if (GM != null) {
            GM.gunStats.dmg -= value;
        }
    }
}
