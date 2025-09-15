using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMechanicBall : MonoBehaviour
{
    //ball parameters
    [SerializeField] GameObject ball;
    [SerializeField] CircleCollider2D ballCollider;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isHeld;

    //victim parameters
    [SerializeField] BoxCollider2D victimCollider;
    [SerializeField] Rigidbody2D victimRb;
    [SerializeField] Transform VictimTransform;
    [SerializeField] Transform ballHolder;

    //using inputsystem
    InputAction MoveInputAction;
    private Vector2 InputmoveValue;
    InputAction JumpInputAction;


    [SerializeField] float walkSpeed;

    public enum MovementState
    {
        Idle,
        Walk,
        Jump,
        ThrowBall
    }

    public MovementState movementState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ball = gameObject;
        ballCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //inputsystem
        MoveInputAction = InputSystem.actions.FindAction("Move");
        JumpInputAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        InputmoveValue = MoveInputAction.ReadValue<Vector2>();

        UpdateState();
    }

    private void FixedUpdate()
    {
        switch (movementState)
        {
            case MovementState.Idle:
                Debug.Log("Currently Idle");
                break;
            case MovementState.Walk:
                Debug.Log("Currently Walking");
                //transform.position = ballHolder.position;
                //VictimTransform.position = transform.position;
                Walk();
                break;
        }
    }

    public void UpdateState()
    {
        if (victimCollider == null && MoveInputAction.ReadValue<Vector2>() != Vector2.zero)
        {
            movementState = MovementState.Idle;
        }
        else if (victimCollider != null && MoveInputAction.ReadValue<Vector2>() != Vector2.zero)
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
            //ball.transform.position = victimCollider.bounds.center;
            // rb.AddForceX(InputmoveValue.x * walkSpeed, ForceMode2D.Force);
            victimRb.AddForce(InputmoveValue * walkSpeed, ForceMode2D.Force);
        }
    }

    #endregion


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Victim"))
        {
            //other.gameObject.GetComponent<PolygonCollider2D>();
            victimCollider = other.gameObject.GetComponent<BoxCollider2D>();
            victimRb = other.gameObject.GetComponent<Rigidbody2D>();
            VictimTransform = other.gameObject.GetComponent<Transform>();

            ballHolder = victimCollider.transform.Find("Ball holder");
            isHeld = true;


            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            transform.position = ballHolder.position;
        }
    }
}