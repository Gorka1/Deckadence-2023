using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    [SerializeField]
    string ExitScene;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // loads scene on user input From anywhere
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(ExitScene);
        }
    }

    
}