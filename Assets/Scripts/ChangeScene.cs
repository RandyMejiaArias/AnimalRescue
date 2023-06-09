using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneNamed(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame() {
        Debug.Log("Exit");
        Application.Quit();
    }
}
