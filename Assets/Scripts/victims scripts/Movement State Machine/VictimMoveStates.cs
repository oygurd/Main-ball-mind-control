using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class VictimMoveStates : SerializedMonoBehaviour
{
    public ClassManagerConfig victimClassValues;
    private MeleeWeaponParameters meleeClass;
    private RangedWeaponParameters RangedClass;
    
    [Required]
    private VictimStateController victimStateController;

    [SerializeField] float victimSpeed;
    [SerializeField] float victimJumpStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
       //victimClassValues = GetComponent<ClassManagerConfig>();
        victimSpeed = victimClassValues.movementSpeed;
        victimJumpStrength = victimClassValues.jumpStrength;

        victimStateController = GetComponent<VictimStateController>();
    }

    public void IdleState()
    {
    }

    public void WalkState()
    {
        victimStateController.victimRigidbody.AddForceX(victimStateController.moveInputValue.x * victimSpeed,
            ForceMode2D.Force);
    }

    public void JumpState()
    {
        victimStateController.victimRigidbody.AddForce(Vector2.up * victimJumpStrength, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
    }
}