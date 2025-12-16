using System.Collections;
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
    InputAction Melee_Parry;

    [Required("Put the victims's transform here!")]
    public Transform VictimTransformReference;

    [Required("Put the melee weapon's transform here!")]
    public Transform MeleeParrySpot;

    public RaycastHit2D weaponRaycastHit;
    public LayerMask WeaponLayerMask;
    //public Collider2D enemyHit;

    public RaycastHit2D parryRaycastHit;
    public LayerMask parryLayerMask;
    private bool ParryCd;
    private bool canParry;

    public bool CanDash;
    [SerializeField] Rigidbody2D victimRigidbody;

    private void Update()
    {
        if (melee_inputAction.inProgress)
        {
            weaponRaycastHit = Physics2D.Raycast(transform.position,
                transform.right * VictimTransformReference.localScale.x,
                MeleeWeaponParameters.attackRange, WeaponLayerMask);
            
           // enemyHit = weaponRaycastHit.collider;
        }
        
    }

    private void Awake()
    {
        melee_animationsHandler = GetComponent<Melee_AnimationsHandler>();
        melee_inputAction = InputSystem.actions.FindAction("Attack");
        Melee_Parry = InputSystem.actions.FindAction("AbilityOne");
        CanDash = true;

        victimRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public void OnParryDisplayer()
    {
        StartCoroutine(ParryCdSequencer());
        if (ParryCd == false)
            return;
        StartCoroutine(ParryTime());

        if (canParry)
        {
            parryRaycastHit = Physics2D.Raycast(MeleeParrySpot.transform.position,
                transform.right * VictimTransformReference.localScale.x,
                MeleeWeaponParameters.ParryRange, parryLayerMask);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && CanDash)
        {
            StartCoroutine(DashCd());
            /*VictimTransformReference.position +=
                VictimTransformReference.localScale.x * VictimTransformReference.right *
                MeleeWeaponParameters.DashStrengthX;*/
            GravityManager.instance.SetGravityScale(1, 3);
            victimRigidbody.AddForce(VictimTransformReference.localScale.x * VictimTransformReference.right *
                                     MeleeWeaponParameters.DashStrengthX, ForceMode2D.Impulse);
            victimRigidbody.linearDamping = 10;
            GravityManager.instance.ResetPriority();
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

            Gizmos.DrawRay(transform.position,
                transform.right * VictimTransformReference.localScale.x * MeleeWeaponParameters.attackRange);
        }

        //parry gizmo
        if (canParry)
        {
            if (!parryRaycastHit && canParry)
            {
                Gizmos.color = Color.red;
            }
            else if (parryRaycastHit && canParry)
            {
                Gizmos.color = Color.green;
                Debug.Log(parryRaycastHit.transform.name);
            }

            Gizmos.DrawRay(MeleeParrySpot.transform.position,
                transform.right * VictimTransformReference.localScale.x * MeleeWeaponParameters.ParryRange);
        }
    }

    #region ParryStuff

    IEnumerator ParryCdSequencer()
    {
        ParryCd = true;
        yield return new WaitForSeconds(MeleeWeaponParameters.ParryCd);
        ParryCd = false;
    }

    IEnumerator ParryTime()
    {
        canParry = true;
        yield return new WaitForSeconds(melee_animationsHandler.barSetter);
        canParry = false;
    }

    #endregion


    #region DashStuff

    IEnumerator DashCd()
    {
        CanDash = false;
        yield return new WaitForSeconds(MeleeWeaponParameters.dashAttackCD);
        CanDash = true;
    }

    #endregion
}