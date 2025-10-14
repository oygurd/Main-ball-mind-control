using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(VictimMoveStates))]
public class VictimStateController : SerializedMonoBehaviour
{
    public VictimMoveStates currentState;

    [HideInInspector] public InputAction MovemInput;
    [HideInInspector] private Vector2 moveInputValue;
    [HideInInspector] public InputAction JumpInput;

    private Rigidbody2D victimRigidbody;

    [SerializeField] float airTime;
    [SerializeField] float airTimeSetter;

//ground detection
    [SerializeField] LayerMask groundLayer = 3;

    [SerializeField] bool isGrounded;
    [SerializeField] float rayDistance;
    [SerializeField] int jumpCount;
    [SerializeField] private bool didJump;

    public enum State
    {
        Idle,
        Walking,
        Jumping
    }

    public State movementState;

    private void Start()
    {
        currentState  = GetComponent<VictimMoveStates>();
    }

    private void Update()
    {
        switch (movementState)
        {
            case State.Idle:
                currentState.IdleState();
                break;
            case State.Walking:
                currentState.WalkState();
                break;
            case State.Jumping:
                currentState.JumpState();
                break;
        }

        RaycastGroundCheck();
    }


    public void ChangeState()
    {
        if (!MovemInput.IsPressed())
        {
            movementState = State.Idle;
        }

        if (MovemInput.IsPressed())
        {
            movementState = State.Walking;
        }

        if (JumpInput.IsPressed())
        {
            movementState = State.Jumping;
        }
    }


    private void RaycastGroundCheck()
    {
        //managing the ground detection -----------------
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, ~groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;

            jumpCount = 1;
            didJump = false;
            airTime = airTimeSetter;

            victimRigidbody.gravityScale = 1f;
            victimRigidbody.linearDamping = 5;

            Debug.DrawRay(transform.position, Vector2.down, Color.red);
        }
        else if (hit.collider == null)
        {
            isGrounded = false;
            jumpCount = 0;
            didJump = true;

            if (airTime != 0)
            {
                airTime -= 1 * Time.deltaTime;
                if (airTime <= 0)
                {
                    victimRigidbody.gravityScale = 4;
                    victimRigidbody.linearDamping = 2;
                }
            }

            Debug.DrawRay(transform.position, Vector2.down, Color.green);
        }
    }
}