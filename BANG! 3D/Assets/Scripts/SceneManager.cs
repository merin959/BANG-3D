using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public void Start()
    {
        Screen.fullScreen = true;
    }
    public void ChangeScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
