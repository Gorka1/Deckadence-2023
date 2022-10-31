using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour
{
    public abstract void MainEffect(GameObject GO);
    public abstract void UndoEffect(GameObject GO);
    public void Wait() {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine() {
        yield return new WaitForSeconds(5);     // get wait settings
        // call UndoEffect
    }
}
