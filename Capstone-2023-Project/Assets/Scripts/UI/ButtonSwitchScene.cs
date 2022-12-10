using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSwitchScene : MonoBehaviour
{
    [SerializeField]
    string SceneName;
    public void SwitchToScene() {
        SceneManager.LoadScene(SceneName);
    }
}
