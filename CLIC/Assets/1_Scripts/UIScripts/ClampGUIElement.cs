using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampGUIElement : MonoBehaviour
{
    [SerializeField] Transform whatToClamp = default;

    void Update()
    {
        Vector3 clampedObjectPos = this.transform.position;
        whatToClamp.position = clampedObjectPos;
    }
}
