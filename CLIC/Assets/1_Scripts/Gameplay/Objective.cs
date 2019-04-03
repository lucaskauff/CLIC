using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    SceneLoader sceneLoader;
    InputManager inputManager;

    [SerializeField] string nextLevelName = default;
    [SerializeField] int inputsMaxForThisLevel = default;

    private void Start()
    {
        sceneLoader = GameManager.Instance.sceneLoader;
        inputManager = GameManager.Instance.inputManager;

        inputManager.inputsLeft = inputsMaxForThisLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            sceneLoader.LoadNewLevel(nextLevelName);
        }
    }
}