using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SceneLoader sceneLoader;
    InputManager inputManager;

    Animator myAnim;

    [SerializeField, Range(1f, 10f)]
    float moveSpeed = 1f;

    public LayerMask unwalkableMask;
    public Transform startPoint;
    public bool canWalk = true;

    private Vector3 nextPosition;
    private bool isWalking;
    private bool inputCheck = false;
    private bool wallCheck = false;

    void Start()
    {
        sceneLoader = GameManager.Instance.sceneLoader;
        inputManager = GameManager.Instance.inputManager;

        myAnim = GetComponent<Animator>();

        transform.position = startPoint.position;
        nextPosition = transform.position;
        isWalking = false;
    }

    void Update()
    {
        if (transform.position == nextPosition)
        {
            isWalking = false;

            if (!wallCheck || (wallCheck && !inputManager.anyKeyPressed))
            {
                inputCheck = false;
            }
        }

        if (inputManager.horizontalMovement != 0 && !isWalking)
        {
            nextPosition += Vector3.right * inputManager.horizontalMovement;
        }
        else if (inputManager.verticalMovement != 0 && !isWalking)
        {
            nextPosition += Vector3.up * inputManager.verticalMovement;
        }

        if (nextPosition != transform.position)
        {
            Vector2 dir = nextPosition - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.sqrMagnitude, unwalkableMask.value);

            if (!inputCheck)
            {
                inputManager.inputsLeft--;
                inputCheck = true;
            }

            if (hit.collider == null)
            {
                if (!canWalk)
                {
                    Debug.Log("No CLICS left, the player can't move.");
                    nextPosition = transform.position;
                    return;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * moveSpeed);

                    if (!isWalking)
                    {
                        isWalking = true;
                    }

                    if (transform.position == nextPosition && inputManager.inputsLeft <= 0)
                    {
                        canWalk = false;
                    }
                }
            }
            else
            {
                Debug.Log("There is an obstacle, the player can't move.");
                nextPosition = transform.position;
                wallCheck = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (inputManager.inputsLeft < 0)
        {
            myAnim.SetTrigger("OnReload");
        }
    }

    private void WaveFinished()
    {
        sceneLoader.ReloadLevel();
    }
}