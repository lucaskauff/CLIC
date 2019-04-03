using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] TextMeshProUGUI counter = default;

    private void Start()
    {
        inputManager = GameManager.Instance.inputManager;
    }

    private void Update()
    {
        counter.text = inputManager.inputsLeft.ToString();
    }
}