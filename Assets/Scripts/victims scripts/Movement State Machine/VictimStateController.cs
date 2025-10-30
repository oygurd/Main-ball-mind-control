using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(VictimMoveStates))]
public class VictimStateController : SerializedMonoBehaviour
{
    public bool isControlled;

    //state machine
    public VictimMoveStates currentState;

    //ball holder
    public Transform BallHolderObject;

    //input system
    [HideInInspector] public InputAction MoveInput;
    [HideInInspector] public Vector2 moveInputValue;
    [HideInInspector] public InputAction JumpInput;

    //rigidbody
    public Rigidbody2D victimRigidbody;
    
    //ground detection
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] bool isGrounded;
    [SerializeField] float rayDistance;
    [SerializeField] int jumpCount;
    [SerializeField] private bool didJump;
    [SerializeField] float airTime;
    
    [Required("Cannot be 0!")]
    public float airTimeSetter;

    public enum MovementStates
    {
        Idle,
        Walking,
        Jumping
    }

    public MovementStates movementStates;
    
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
        //movement
        moveInputValue = MoveInput.ReadValue<Vector2>();
        if (moveInputValue.x != 0)
        {
            transform.localScale = new Vector3(moveInputValue.x, 1, 1);
        }        switch (movementStates)
        {
            case MovementStates.Idle:
                currentState.IdleState();
                break;
            case MovementStates.Walking:
                currentState.WalkState();
                break;
            case MovementStates.Jumping:
                jumpCount -= 1;
                currentState.JumpState();
                break;
        }

        RaycastGroundCheck();
        ChangeMovementState();
        
        //actions
        
        
    }


    public void ChangeMovementState()
    {
        if (!MoveInput.IsPressed())
        {
            movementStates = MovementStates.Idle;
        }

        if (MoveInput.IsPressed())
        {
            movementStates = MovementStates.Walking;
        }

        if (JumpInput.IsPressed() && isGrounded )
        {
            movementStates = MovementStates.Jumping;
        }
    }


    public void RaycastGroundCheck()
    {
        //managing the ground detection -----------------
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;

            jumpCount = 1;
            didJump = false;
            airTime = airTimeSetter; // need to adjust it to any victim based on wepaon

            victimRigidbody.gravityScale = 1f;
            victimRigidbody.linearDamping = 5;

            Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.green);
            
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

    }
}