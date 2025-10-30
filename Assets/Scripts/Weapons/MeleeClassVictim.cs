using System.Collections;
using Nomnom.RaycastVisualization;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Melee_AnimationsHandler))]
public class MeleeClassVictim : SerializedMonoBehaviour
{
    //this script is for the melee class attacks, ranged class will have a parallel class as well
    public MeleeWeaponParameters MeleeWeaponParameters;
    public Melee_AnimationsHandler melee_animationsHandler;

    InputAction melee_inputAction;
    float raycastDuration;

    private void Awake()
    {
        melee_animationsHandler = GetComponent<Melee_AnimationsHandler>();
        melee_inputAction = InputSystem.actions.FindAction("Attack");
    }

    public void OnAttack()
    {
        if (melee_inputAction.IsInProgress())
        {
            VisualPhysics2D.BoxCast(transform.position, new Vector2(MeleeWeaponParameters.attackRange,2),90,transform.forward);
        }
    }

    
}