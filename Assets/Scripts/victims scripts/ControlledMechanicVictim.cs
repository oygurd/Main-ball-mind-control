using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledMechanicVictim : MonoBehaviour
{
    //in this script I want the victim to move randomly (with a bit of intention to go to the ball, and when touching the ball, movement is possible

    [Header("Victim Parameters")]
    //vimctim parameters
    [SerializeField]
    public Collider2D victimCollider;

    [SerializeField] Rigidbody2D victimRigidbody;
    [SerializeField] float walkSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float airTime;
    [SerializeField] float airTimeSetter;

    public enum MovementState
    {
        Idle,
        Walk,
        Jump
    }

    public MovementState movementState; //referencer for the movementstate enum

    [Header("Ground Detection")]
    //ground detection
    [SerializeField]
    LayerMask groundLayer = 3;

    [SerializeField] bool isGrounded;
    [SerializeField] float rayDistance;
    [SerializeField] int jumpCount;
    [SerializeField] private bool didJump;

    [Header("Ball Parameters")]
    //ball parameters
    [SerializeField]
    private bool isHeld;

    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D ballRb;
    [SerializeField] CircleCollider2D ballCollider;
    
    //using inputsystem
    InputAction MoveInputAction;
    private Vector2 InputmoveValue;
    InputAction JumpInputAction;


    public Transform ballHolderInVictim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victimCollider = GetComponent<Collider2D>();
        victimRigidbody = GetComponent<Rigidbody2D>();

        jumpCount = 1;
        didJump = false;

        //inputsystem
        MoveInputAction = InputSystem.actions.FindAction("Move");
        JumpInputAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        InputmoveValue = MoveInputAction.ReadValue<Vector2>();
        switch (movementState)
        {
            case MovementState.Idle:
                Debug.Log("Currently Idle");
                break;
            case MovementState.Walk:
                Debug.Log("Currently Walking");
                ballTransform.position =
                    Vector2.MoveTowards(ballTransform.position, ballHolderInVictim.transform.position, 0.1f);
                Walk();
                break;
            case MovementState.Jump:
                Debug.Log("Currently Jumping");
                Jump();
                break;
        }

        ballTransform.position =
            Vector2.MoveTowards(ballTransform.position, ballHolderInVictim.transform.position, 0.1f);


        UpdateState();
        RaycastGroundCheck();
    }

    private void FixedUpdate()
    {
    }

    public void UpdateState()
    {
        if (ballTransform == null && MoveInputAction.ReadValue<Vector2>() != Vector2.zero)
        {
            movementState = MovementState.Idle;
        }
        else if (ballTransform != null && MoveInputAction.ReadValue<Vector2>() != Vector2.zero)
        {
            movementState = MovementState.Walk;
            if (JumpInputAction.IsPressed() && isGrounded && !didJump)
            {
                movementState = MovementState.Jump;
            }
        }
        else if (JumpInputAction.IsPressed() && isGrounded && !didJump)
        {
            movementState = MovementState.Jump;
        }
    }

    #region ActionStates

    public void Idle() //handle idling for ball
    {
    }

    public void Walk()
    {
        if (InputmoveValue.x != 0)
        {
            victimRigidbody.AddForceX(InputmoveValue.x * walkSpeed, ForceMode2D.Force);
            ballTransform.position = ballHolderInVictim.position;
        }
    }

    public void Jump()
    {
        if (JumpInputAction.IsPressed() && isGrounded)
        {
            victimRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount -= 1;
        }
    }

    #endregion

    public void RaycastGroundCheck()
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
        }
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballTransform = other.gameObject.GetComponent<Transform>();
            ballRb = other.gameObject.GetComponent<Rigidbody2D>();
            ballCollider = other.gameObject.GetComponent<CircleCollider2D>();
            isHeld = true;


            ballCollider.enabled = false;
            ballRb.freezeRotation = true;
            ballRb.constraints = RigidbodyConstraints2D.FreezePosition;
            ballTransform.position =
                Vector2.MoveTowards(ballTransform.position, ballHolderInVictim.transform.position, 0.1f);
        }
    }
}