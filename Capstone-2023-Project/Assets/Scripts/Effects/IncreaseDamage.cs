using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : AbstractEffect
{
    public override void MainEffect(GameObject GO) {
        Debug.Log("Applied effect to object: " + GO.name);
    }
}
