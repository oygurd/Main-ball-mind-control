using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Melee_AnimationsHandler))]
public class MeleeClassVictim : SerializedMonoBehaviour
{
    public MeleeWeaponParameters MeleeWeaponParameters;

    public Melee_AnimationsHandler melee_animationsHandler;

    [SerializeField] float time;

    public bool firstStrike;
    public bool secondStrike;
    public PlayerInput _inputSystem;
    public InputAction BasicAttackInput;
    public InputAction ParryOrGrenadeInput;
    //public InputAction ThrowableInput;

    private void Awake()
    {
        _inputSystem = GetComponentInParent<PlayerInput>();
        firstStrike = true;
        melee_animationsHandler = GetComponent<Melee_AnimationsHandler>();
        BasicAttackInput = InputSystem.actions.FindAction("Attack");
        ParryOrGrenadeInput = InputSystem.actions.FindAction("Parry/Grenade");
    }

    private void Update()
    {
        Idle();
       // Attack();
        
    }

    public void Idle()
    {
        if (!BasicAttackInput.IsPressed())
        {
            melee_animationsHandler.PlayIdle();
        }
    }
    
    
   public IEnumerator AttackTime()
    {
        secondStrike = false;
        melee_animationsHandler.PlayAttack1();
        time = melee_animationsHandler.barSetter;
        yield return new WaitForSeconds(time);
        secondStrike = true;
        if (BasicAttackInput.IsInProgress() && secondStrike)
        {
            melee_animationsHandler.PlayAttack2();
            time = melee_animationsHandler.barSetter;
        }
        yield return new WaitForSeconds(time);
        secondStrike = false;
        firstStrike = true;
    }

    public void Attack()
    {
        if (BasicAttackInput.IsPressed() && firstStrike)
        {
            StartCoroutine(AttackTime());
            firstStrike = false;
        }
    }

    public void OnAttack(InputValue attackVal)
    {
        
            StartCoroutine(AttackTime());
            firstStrike = false;
        
    }
    
    
}