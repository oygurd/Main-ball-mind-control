using System;
using System.Collections;
using Nomnom.RaycastVisualization;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Melee_AnimationsHandler))]
public class MeleeClassVictim : SerializedMonoBehaviour
{
    //this script is for the melee class attacks, ranged class will have a parallel class as well
    public MeleeWeaponParameters MeleeWeaponParameters;
    public Melee_AnimationsHandler melee_animationsHandler;

    InputAction melee_inputAction;
    InputAction Melee_Parry;

    public Transform VictimTransformReference;

    public Transform MeleeParrySpot;
    
   public RaycastHit2D weaponRaycastHit;
   public LayerMask WeaponLayerMask;
    
   public RaycastHit2D parryRaycastHit;
   public LayerMask parryLayerMask;
   private bool canParry;
   

    private void Update()
    {
        if (melee_inputAction.inProgress)
        {
           weaponRaycastHit = Physics2D.Raycast(transform.position,
                transform.right * VictimTransformReference.localScale.x,
                MeleeWeaponParameters.attackRange, WeaponLayerMask);
        }
    }

    private void Awake()
    {
        melee_animationsHandler = GetComponent<Melee_AnimationsHandler>();
        melee_inputAction = InputSystem.actions.FindAction("Attack");
        Melee_Parry = InputSystem.actions.FindAction("AbilityOne");

    }

    public void OnParryDisplayer()
    {
        StartCoroutine(ParryTime());
        if (canParry)
        { 
            parryRaycastHit = Physics2D.Raycast(MeleeParrySpot.transform.position,
                transform.right * VictimTransformReference.localScale.x,
                MeleeWeaponParameters.ParryRange, parryLayerMask);
        }

    }

    private void OnDrawGizmos()
    {
        //basic attack gizmo
        if (melee_inputAction.inProgress)
        {
            if (!weaponRaycastHit)
            {
                Gizmos.color = Color.red;
            }
            else if (weaponRaycastHit)
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawRay(transform.position, transform.right * VictimTransformReference.localScale.x * MeleeWeaponParameters.attackRange);
        }

        //parry gizmo
        if (canParry)
        {
            if (!parryRaycastHit&& canParry)
            {
                Gizmos.color = Color.red;
            }
            else if (parryRaycastHit && canParry)
            {
                Gizmos.color = Color.green;
                Debug.Log(parryRaycastHit.transform.name);
            }
            
            Gizmos.DrawRay(MeleeParrySpot.transform.position, transform.right * VictimTransformReference.localScale.x * MeleeWeaponParameters.ParryRange);
        }
        
        
    }


    IEnumerator ParryTime()
    {
        canParry = true;
        yield return new WaitForSeconds(2);
        canParry = false;
    }
    
}