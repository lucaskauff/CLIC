using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    SceneLoader sceneLoader;

    public int inputsLeft;

    //Any key
    public bool anyKeyPressed = false;

    //Player mouvement
    public float horizontalMovement = 0;
    public float verticalMovement = 0;

    public void Start()
    {
        sceneLoader = GameManager.Instance.sceneLoader;
    }

    public void Update()
    {
        anyKeyPressed = Input.anyKey;

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        //float test = Input.G

        if (Input.anyKeyDown && inputsLeft > 0 && horizontalMovement == 0 && verticalMovement == 0)
        {
            inputsLeft--;
        }
    }
}