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
    [SerializeField] private int Jumps; //increase in order to have a restriction on jumping
    [SerializeField] private bool didJump;
    [SerializeField] float airTime;

    private RaycastHit2D hit;
    private RaycastHit2D coyoteTimeHit1;
    private RaycastHit2D coyoteTimeHit2;
    private RaycastHit2D boxCastHit;

    [SerializeField] Collider2D lastSurface;

    public Transform DebuggingEmpty;

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
            Jumps += 1;
            didJump = true;
        }
    }


    public void RaycastGroundCheck()
    {
        //managing the ground detection -----------------
        hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);

        boxCastHit = Physics2D.BoxCast(transform.position, new Vector2(1.0f, 0.2f), 0, Vector2.down, rayDistance,
            groundLayer);

        lastSurface = hit.collider;

        if (boxCastHit.collider != null )
        {
            
                isGrounded = true;
                jumpCount = 1;
                didJump = false;
                airTime = airTimeSetter; // need to adjust it to any victim based on wepaon

                GravityManager.instance.SetGravityScale(1, 1);
                victimRigidbody.linearDamping = 5;

                Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.green);
            
            
           
        }

        else if (boxCastHit.collider == null)
        {
            isGrounded = false;
            jumpCount = 0;
            didJump = true;
            Jumps = 0;
            if (airTime != 0)
            {
                airTime -= 1 * Time.deltaTime;
                if (airTime <= 0)
                {
                    GravityManager.instance.SetGravityScale(4, 2);
                    victimRigidbody.linearDamping = 2;
                }
            }

           // Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        }
    }


    private void OnDrawGizmos()
    {
        if (boxCastHit.collider == null)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawCube(DebuggingEmpty.transform.position, new Vector2(1.0f, 0.2f));
    }
}