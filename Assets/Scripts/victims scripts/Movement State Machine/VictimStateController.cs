using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField]
    LayerMask groundLayer = 3;

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

    private void Update()
    {
        switch (movementState)
        {
            case State.Idle:

                break;
            case State.Walking:

                break;
            case State.Jumping:

                break;
        }
    }

    
    
    
    public void ChangeState(VictimMoveStates newState)
    {
        currentState = newState;
        
        
        
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
}