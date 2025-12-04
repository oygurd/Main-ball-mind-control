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

    //input system
    [HideInInspector] public InputAction MoveInput;
    [HideInInspector] public Vector2 moveInputValue;
    [HideInInspector] public InputAction JumpInput;

    //rigidbody
    public Rigidbody2D victimRigidbody;

    //ground detection
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] bool isGrounded;

    [InfoBox("Ray distance should be 0.45 under normal circumstances")] [SerializeField]
    float rayDistance;

    [SerializeField] int jumpCount;
    [SerializeField] private bool didJump;
    [SerializeField] float airTime;

    private RaycastHit2D hit;
    private RaycastHit2D coyoteTimeHit1;
    private RaycastHit2D coyoteTimeHit2;


    [Required("Cannot be 0!")] public float airTimeSetter;

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
        }

        switch (movementStates)
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

        CoyoteTime();
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

        if (JumpInput.IsPressed() && isGrounded)
        {
            movementStates = MovementStates.Jumping;
        }
    }


    public void RaycastGroundCheck()
    {
        //managing the ground detection -----------------
       hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;

            jumpCount = 1;
            didJump = false;
            airTime = airTimeSetter; // need to adjust it to any victim based on wepaon

            GravityManager.instance.SetGravityScale(1, 1);
            victimRigidbody.linearDamping = 5;

            Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.green);
        }

        else if (hit.collider == null)
        {
            isGrounded = false;
            jumpCount = 0;
            //didJump = true;

            if (airTime != 0)
            {
                airTime -= 1 * Time.deltaTime;
                if (airTime <= 0)
                {
                    GravityManager.instance.SetGravityScale(4, 2);
                    victimRigidbody.linearDamping = 2;
                }
            }

            Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        }
    }

    public void CoyoteTime()
    {
        coyoteTimeHit1 = Physics2D.Raycast(new Vector2(1,transform.position.y), Vector2.down, rayDistance, groundLayer);
        Debug.DrawRay(new Vector2(1, transform.position.y), Vector2.down * rayDistance, Color.red);
        
        if (!didJump && hit.collider == null)
        {
            jumpCount = 1;
        }
    }
}