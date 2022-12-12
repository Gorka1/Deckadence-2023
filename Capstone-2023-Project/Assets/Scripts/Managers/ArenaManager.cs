using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Walls;
    [SerializeField]
    List<GameObject> Enemies;
    [SerializeField]
    List<GameObject> EndObjects;
    GameManager GM;
    bool isActive = false;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        if (isActive) {
            int numOfNull = 0;
            foreach (GameObject e in Enemies) {
                if (e == null) {
                    numOfNull += 1;
                }
            }
            if (Enemies.Count == numOfNull) {
                isActive = false;
                foreach (GameObject w in Walls) {
                    w.SetActive(false);
                }
                foreach (GameObject e in EndObjects) {
                    e.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            isActive = true;
            GM.GetPlayer().GetComponent<PlayerManager>().inCombat = true;
            foreach (GameObject w in Walls) {
                w.SetActive(true);
            }
            foreach (GameObject e in Enemies) {
                e.SetActive(true);
            }
        }
    }
}
