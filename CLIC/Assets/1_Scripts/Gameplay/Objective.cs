using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    SceneLoader sceneLoader;
    InputManager inputManager;

    [SerializeField] int inputsMaxForThisLevel = 0;
    [SerializeField] Animator fadeInOutAnim = default;

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
            fadeInOutAnim.SetTrigger("FadeOut");
        }
    }
}