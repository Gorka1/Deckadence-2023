using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    float health = 100;
    [SerializeField]
    float DamageModifier = 1;
    Renderer materialRenderer;
    public void TakeDamage(float amount) {
        health -= amount * DamageModifier;
    }

    private void Start() {
        materialRenderer = GetComponent<Renderer>();
    }

    private void Update() {
        if (health <= 20) {
            materialRenderer.material.color = Color.black;
        } else if (health <= 40) {
            materialRenderer.material.color = Color.red;
        } else if (health <= 60) {
            materialRenderer.material.color = Color.magenta;
        } else if (health <= 80) {
            materialRenderer.material.color = Color.blue;
        } else {
            materialRenderer.material.color = Color.white;
        }
    }
}
