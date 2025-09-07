using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledMechanicVictim : MonoBehaviour
{
    //in this script I want the victim to move randomly (with a bit of intention to go to the ball, and when touching the ball, movement is possible


    [SerializeField] public Collider2D victimCollider;
    [SerializeField] Rigidbody2D victimRigidbody;
    [SerializeField] float walkSpeed;


    //ball parameters
    [SerializeField] private bool isHeld;
    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D ballRb;

    //using inputsystem
    InputAction MoveInputAction;
    private Vector2 InputmoveValue;
    InputAction JumpInputAction;

    public Transform ballHolderInVictim;


    public enum MovementState
    {
        Idle,
        Walk,
        Jump,
        ThrowBall
    }

    public MovementState movementState;

    public enum Attack
    {
        Punch,
        Shoot,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victimCollider = GetComponent<Collider2D>();
        victimRigidbody = GetComponent<Rigidbody2D>();


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
               
                ballTransform.position = Vector2.MoveTowards(ballTransform.position, ballHolderInVictim.transform.position, 0.1f);

                Walk();
                break;
        }

        UpdateState();
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
        }
    }

    #region ActionStates

    public void Idle() //handle idling for ball
    {
    }

    public void Walk()
    {
        //Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (InputmoveValue.x != 0)
        {
            victimRigidbody.AddForceX(InputmoveValue.x * walkSpeed, ForceMode2D.Force);
            ballTransform.position = ballHolderInVictim.position;
        }
    }

    #endregion


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballTransform = other.gameObject.GetComponent<Transform>();
            ballRb = other.gameObject.GetComponent<Rigidbody2D>();

            isHeld = true;
            
            ballRb.freezeRotation = true;
            ballRb.constraints = RigidbodyConstraints2D.FreezePosition;
            ballTransform.position = Vector2.MoveTowards(ballTransform.position, ballHolderInVictim.transform.position, 0.1f);

        }
    }
}