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
    private int currHealth = 0;

    UIHealth uiHealth;

    private void Start() {
        
        uiHealth = GameObject.FindGameObjectWithTag("UIHealth").GetComponent<UIHealth>();

        //refill HP 
        while(currHealth < maxHealth) {
            currHealth++;
            uiHealth.IncrementHP();
        }
    }

    private void Update() {
        if (currHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int GetCurrHealth() { return currHealth; }

    //Can be positive or negative, will direct appropriately to hurt or heal 
    public void ChangeHP(int amount) {
        if(amount > 0) {
            Heal(amount);
        } else if(amount < 0) {
            TakeDmg(amount);
        }
    }

    //Reduce HP by the positive number dmg.
    public void TakeDmg(int dmg = 1) { 

        currHealth -= dmg; 

        //update in UI
        for(int i = 0; i < dmg; i++) {
            uiHealth.DecrementHP();
        }
    }

    //Increase HP by this amount.
    public void Heal(int health = 1) {
        currHealth += health; 

        //update in UI
        for(int i = 0; i < health; i++) {
            uiHealth.IncrementHP();
        }
    }
    
}
