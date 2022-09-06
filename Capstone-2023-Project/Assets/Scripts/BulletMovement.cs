using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 2f;
    Transform origin;
    float range;
    bool set = false;
    float damage;

    public void Setup(Transform o, float r, float d, float speed = 2f) {
        origin = o;
        range = r;
        bulletSpeed = speed;
        damage = d;
        set = true;
    }

    private void Update() {
        if (set) {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
            if (Vector3.Distance(origin.position, transform.position) > range) {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        TargetScript ts = other.gameObject.GetComponent<TargetScript>();
        if (ts != null) {
            ts.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
