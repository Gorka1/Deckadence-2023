using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    ParticleSystem PS;
    // private void OnEnable() {
    //     StartCoroutine(Wait(PS.main.duration));
    //     this.gameObject.SetActive(false);
    // }

    public void Activate() {
        foreach (Transform child in this.transform) {
            child.gameObject.SetActive(true);
        }
        PS.Play();
        Debug.Log(PS.main.duration);
        StartCoroutine(Wait(PS.main.duration));
    }

    IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        PS.Stop();
        foreach (Transform child in this.transform) {
            child.gameObject.SetActive(false);
        }
    }
}
