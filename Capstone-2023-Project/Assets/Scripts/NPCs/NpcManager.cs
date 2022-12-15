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
    bool isAttacking = false;
    [SerializeField]
    Renderer materialRenderer;
    [SerializeField]
    GameObject AttackingObj;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (Vector3.Distance(GM.GetPlayerPos(), this.transform.position) <= stats.attackRange && !isAttacking) {
            AttackPlayer(GM.GetPlayer());
        }
        if (isMoving && Vector3.Distance(GM.GetPlayerPos(), this.transform.position) >= stats.playerRange) {
            _agent.SetDestination(GM.GetPlayerPos());
            // start moving animation
        } else {
            _agent.isStopped = true;
            // start idle animation
        }
    }

    public void TakeDamage(int dmg) {
        stats.health -= dmg;
        if (stats.health <= 0) {
            GM.LethalHit();
            Die();
        } else {
            GM.NonLethalHit();
            StartCoroutine(ColorHit());
        }
    }

    void Die() {
        conditions.Add("dead");
        // EventObj newEvent = new EventObj(QuestEnums.SignalOrigin.Enemy, conditions);
        // GM.TakeQuestEvent(newEvent);
        Destroy(gameObject);
    }

    IEnumerator ColorHit() {
        Color currColor = materialRenderer.material.color; 
        materialRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(.1f);
        materialRenderer.material.SetColor("_Color", currColor);
    }

    public void AttackPlayer(GameObject player) {
        PlayerManager PM = player.GetComponent<PlayerManager>();
        StartCoroutine(AttackWait(PM));
    }
    IEnumerator AttackWait(PlayerManager PM) {
        isAttacking = true;
        Color currColor = materialRenderer.material.color; 
        materialRenderer.material.SetColor("_Color", Color.black);
        AttackingObj?.SetActive(true);
        yield return new WaitForSeconds(stats.attackRate);
        if (Vector3.Distance(GM.GetPlayerPos(), this.transform.position) <= stats.attackRange) {
            PM.TakeDmg();
        }
        materialRenderer.material.SetColor("_Color", currColor);
        AttackingObj?.SetActive(false);
        isAttacking = false;
    }
}
