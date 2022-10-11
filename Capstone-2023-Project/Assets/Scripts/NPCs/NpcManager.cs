using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    public NpcStats stats;
    GameManager GM;
    NavMeshAgent _agent;
    [SerializeField]
    List<string> conditions;
    [SerializeField]
    bool isMoving = true;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _agent = this.GetComponent<NavMeshAgent>();
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

    private void Update() {
        if (isMoving) {
            _agent.SetDestination(GM.GetPlayerPos());
        }
    }
}
