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
    private PlayerInput PlayerInputs;
    
    private void Awake()
    {
        PlayerInputs = GetComponent<PlayerInput>();
        MeleeWeaponParameters = GetComponent<MeleeWeaponParameters>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            VisualPhysics2D.BoxCast(transform.position, new Vector2(), 90, Vector2.right);
        }
    }
    

    


    
}