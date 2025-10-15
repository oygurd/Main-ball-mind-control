using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(VictimMoveStates))]
public class VictimStateController : SerializedMonoBehaviour
{
    public bool isControlled;
    
    public VictimMoveStates currentState;

    [HideInInspector] public InputAction MoveInput;
    [HideInInspector] public Vector2 moveInputValue;
    [HideInInspector] public InputAction JumpInput;

    public Rigidbody2D victimRigidbody;

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

    private void Awake()
    {
        currentState = GetComponent<VictimMoveStates>();
        currentState.enabled = true;
        //inputsystem
        MoveInput = InputSystem.actions.FindAction("Move");
        JumpInput = InputSystem.actions.FindAction("Jump");
    }

    private void Start()
    {
        currentState = GetComponent<VictimMoveStates>();
        victimRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInputValue = MoveInput.ReadValue<Vector2>();
        switch (movementState)
        {
            case State.Idle:
                currentState.IdleState();
                break;
            case State.Walking:
                currentState.WalkState();
                break;
            case State.Jumping:
                jumpCount -= 1;
                currentState.JumpState();
                break;
        }

        RaycastGroundCheck();
        ChangeState();
    }


    public void ChangeState()
    {
        if (!MoveInput.IsPressed())
        {
            movementState = State.Idle;
        }

        if (MoveInput.IsPressed())
        {
            movementState = State.Walking;
        }

        if (JumpInput.IsPressed() && RaycastGroundCheck())
        {
            movementState = State.Jumping;
        }
    }


    public bool RaycastGroundCheck()
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

            Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.green);
            return true;
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

            Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        }

        return false;
    }
}