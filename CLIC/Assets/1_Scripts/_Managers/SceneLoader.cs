using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [HideInInspector] public string activeScene;

    public void Awake()
    {
        activeScene = SceneManager.GetActiveScene().name;       
    }

    public void LoadNewLevel(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        activeScene = sceneToLoad;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}