using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public NpcStats stats;
    GameManager GM;
    [SerializeField]
    List<string> conditions;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void TakeDamage(int dmg) {
        stats.health -= dmg;
        if (stats.health <= 0) {
            Die();
        }
    }

    void Die() {
        conditions.Add("dead");
        EventObj newEvent = new EventObj(QuestEnums.SignalOrigin.Enemy, conditions);
        GM.TakeQuestEvent(newEvent);
        Destroy(gameObject);
    }
}
