using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFirerate : AbstractEffect
{
    [SerializeField]
    float value = 1f;
    GunManager GM;
    public override void MainEffect(GameObject GO) {
        Debug.Log("Firerate changed to: " + GO.name);
        GM = GO.GetComponent<GunManager>();
        if (GM != null) {
            GM.gunStats.fireRate += value;
        }
    }

    public override void UndoEffect(GameObject GO) {
        if (GM != null) {
            GM.gunStats.fireRate -= value;
        }
    }
}
