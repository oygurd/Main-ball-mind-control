using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMechanicBall : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] CircleCollider2D ballCollider;
    [SerializeField] private Rigidbody2D rb;

    //using inputsystem
    InputAction MoveInputAction;
    private Vector2 InputmoveValue;
    InputAction JumpInputAction;


    private float walkSpeed = 10;

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
        ball = GetComponent<GameObject>();
        ballCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //inputsystem
        MoveInputAction = InputSystem.actions.FindAction("Move");
        JumpInputAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        switch (movementState)
        {
            case MovementState.Idle:
                Debug.Log("Currently Idle");
                break;
            case MovementState.Walk:
                Debug.Log("Currently Walking");
                InputmoveValue = MoveInputAction.ReadValue<Vector2>();

                Walk();
                break;
        }
    }

    void UpdateState()
    {
        if (MoveInputAction.ReadValue<Vector2>() == Vector2.zero)
        {
            movementState = MovementState.Idle;
        }
        else if (MoveInputAction.ReadValue<Vector2>() != Vector2.zero)
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
            rb.AddForce(InputmoveValue * 10, ForceMode2D.Impulse);
        }
    }

    #endregion
}