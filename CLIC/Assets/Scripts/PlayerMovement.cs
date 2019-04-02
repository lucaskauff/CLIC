using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    float moveSpeed = 1f;

    public LayerMask unwalkableMask;
    public Transform startPoint;
    public bool canWalk = true;

    private int inputsCounter;
    private Vector3 nextPosition;
    private bool isWalking;

    void Start()
    {
        transform.position = startPoint.position;
        nextPosition = transform.position;
        isWalking = false;
    }

    void Update()
    {
        inputsCounter = FindObjectOfType<Objective>().inputsMax;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (transform.position == nextPosition)
        {
            isWalking = false;
        }

        if (horizontalMovement != 0 && !isWalking)
        {
            nextPosition += Vector3.right * horizontalMovement;
        }
        else if (verticalMovement != 0 && !isWalking)
        {
            nextPosition += Vector3.up * verticalMovement;
        }

        if (nextPosition != transform.position)
        {
            Vector2 dir = nextPosition - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.sqrMagnitude, unwalkableMask.value);

            if (hit.collider == null)
            {
                if (!canWalk)
                {
                    Debug.LogError("00000000, the player can't move");
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

                    if (inputsCounter == 0 && transform.position == nextPosition)
                    {
                        canWalk = false;
                    }
                }
            }
            else
            {
                Debug.LogError("There is an obstacle, the player can't move");
                nextPosition = transform.position;
            }
        }
    }
}