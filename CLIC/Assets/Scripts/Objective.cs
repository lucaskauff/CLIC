using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int inputsMax;

    public string nextLevelName;

    public GameObject player;

    private void Update()
    {
        if (inputsMax > 0 && Input.anyKeyDown)
        {
            inputsMax -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FindObjectOfType<SceneLoader>().SendMessage("LoadNewLevel", nextLevelName);
        }
    }
}