using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour
{
    [SerializeField]
    float time = 5f;
    float internalTime = 0f;
    bool timerReached = false;
    [SerializeField]
    Sprite icon;
    [SerializeField]
    string name = "";
    bool testCombat = true;
    bool active = false;        // is this even needed

    private void Update() {
        if (!timerReached && active)
            internalTime += Time.deltaTime;
        if (internalTime > time)
            timerReached = true;        

        if (testCombat && !active) {
            active = true;
            MainEffect();
            Wait();
        }
    }

    public EffectData GetReport() {
        return new EffectData(icon, name, internalTime);
    }

    public abstract void MainEffect();
    public abstract void UndoEffect();
    public void Wait() {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine() {
        yield return new WaitForSeconds(time);     // get wait settings
        UndoEffect();
        Destroy(this.gameObject);
    }
}
