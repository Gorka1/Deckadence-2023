using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
