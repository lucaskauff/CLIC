using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    SceneLoader sceneLoader;

    public int inputsLeft;

    //Player mouvement
    public float horizontalMovement = 0;
    public float verticalMovement = 0;

    public void Start()
    {
        sceneLoader = GameManager.Instance.sceneLoader;
    }

    public void Update()
    {
        //Important !
        if (Input.anyKeyDown)
        {
            if (inputsLeft > 0)
            {
                inputsLeft--;
            }
            else
            {
                sceneLoader.ReloadLevel();
            }
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }
}