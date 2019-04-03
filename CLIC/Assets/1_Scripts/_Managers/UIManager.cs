using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] TextMeshProUGUI counter = default;
    [SerializeField] Color safeColor = default;
    [SerializeField] Color intermediateColor = default;
    [SerializeField] Color dangerColor = default;

    private void Start()
    {
        inputManager = GameManager.Instance.inputManager;
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        //Counter
        if (inputManager.inputsLeft > 5)
        {
            counter.color = safeColor;
        }
        else if (inputManager.inputsLeft > 3)
        {
            counter.color = intermediateColor;
        }
        else if (inputManager.inputsLeft >= 0)
        {
            counter.color = dangerColor;
        }
        else
        {
            return;
        }

        counter.text = inputManager.inputsLeft.ToString();
    }
}