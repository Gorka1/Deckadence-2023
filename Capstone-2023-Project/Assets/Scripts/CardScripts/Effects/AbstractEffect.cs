using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour
{
    [SerializeField]
    float time = 5f;
    bool testCombat = true;
    bool active = false;        // is this even needed

    private void Update() {
        if (testCombat && !active) {
            MainEffect();
            Wait();
            active = true;
            Destroy(this);
        }
    }

    public abstract void MainEffect();
    public abstract void UndoEffect();
    public void Wait() {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine() {
        yield return new WaitForSeconds(time);     // get wait settings
        UndoEffect();
        // call UndoEffect
    }
}
