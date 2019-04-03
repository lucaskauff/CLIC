using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    SceneLoader sceneLoader;

    [SerializeField] string nextLevelName = null;

    private void Start()
    {
        sceneLoader = GameManager.Instance.sceneLoader;
    }

    public void FadeOutDone()
    {
        sceneLoader.LoadNewLevel(nextLevelName);
    }
}