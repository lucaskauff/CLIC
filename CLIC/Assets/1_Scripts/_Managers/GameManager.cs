using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
[RequireComponent(typeof(InputManager))]
public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    [HideInInspector] public SceneLoader sceneLoader;
    [HideInInspector] public InputManager inputManager;

    void Awake()
    {
        sceneLoader = GetComponent<SceneLoader>();
        inputManager = GetComponent<InputManager>();
    }
}