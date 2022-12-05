using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // move to GameManager

public class PlayerManager : MonoBehaviour
{
    public bool inCombat;
    [SerializeField]
    int maxHealth = 3;
    [SerializeField]
    int currHealth = 0;

    private void Start() {
        Globals.player = this;
        currHealth = maxHealth;
    }

    private void Update() {
        if (currHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void TakeDmg(int dmg = 1) { currHealth -= dmg; }
    public int GetCurrHealth() { return currHealth; }
}
