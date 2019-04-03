using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int inputsLeft;

    //Player mouvement
    public float horizontalMovement = 0;
    public float verticalMovement = 0;

    public void Update()
    {
        //Important !
        if (Input.anyKeyDown)
        {
            inputsLeft--;
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }
}