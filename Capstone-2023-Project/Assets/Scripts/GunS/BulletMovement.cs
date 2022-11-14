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
    int damage;

    public void Setup(Transform o, float r, int d, float speed = 2f) {
        origin = o;
        range = r;
        bulletSpeed = speed;
        damage = d;
        set = true;
    }

    private void Update() {
        if (set) {
            transform.Translate(this.transform.forward * bulletSpeed * Time.deltaTime);
            if (Vector3.Distance(origin.position, transform.position) > range) {
                Destroy(gameObject);
            }
        }
    }

    // TODO: clean this up
    private void OnCollisionEnter(Collision other) {
        TargetScript ts = other.gameObject.GetComponent<TargetScript>();
        if (ts != null) {
            ts.TakeDamage(damage);
        } else {
            NpcManager nm = other.gameObject.GetComponent<NpcManager>();
            if (nm != null) {
                nm.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
