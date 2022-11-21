using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFirerate : AbstractEffect
{
    [SerializeField]
    float value = 1f;
    BaseGunScript GM;
    public override void MainEffect() {
        Debug.Log("Firerate changed to: " + this.transform.parent.name);
        GM = this.GetComponentInParent<BaseGunScript>();
        if (GM != null) {
            GM.gunStats.fireRate += value;
        }
    }

    public override void UndoEffect() {
        if (GM != null) {
            GM.gunStats.fireRate -= value;
        }
    }
}
