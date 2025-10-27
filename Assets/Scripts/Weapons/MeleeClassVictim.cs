using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class MeleeClassVictim : SerializedMonoBehaviour
{
    public MeleeWeaponParameters MeleeWeaponParameters;

    public Melee_AnimationsHandler melee_animationsHandler;

    [SerializeField] float time;

    public bool firstStrike;
    public bool secondStrike;
    public InputAction BasicAttackInput;
    public InputAction ParryOrGrenadeInput;
    //public InputAction ThrowableInput;

    private void Awake()
    {
        melee_animationsHandler = GetComponent<Melee_AnimationsHandler>();
        BasicAttackInput = InputSystem.actions.FindAction("Attack");
        ParryOrGrenadeInput = InputSystem.actions.FindAction("Parry/Grenade");
    }

    private void Update()
    {
        Idle();
        Attack();
        
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
        time = melee_animationsHandler.AnimationTime;
        melee_animationsHandler.PlayAttack1();
        yield return new WaitForSeconds(0.5f);
        secondStrike = true;
        if (BasicAttackInput.IsInProgress() && secondStrike)
        {
            melee_animationsHandler.PlayAttack2();
        }
        secondStrike = false;
    }

    public void Attack()
    {
        BasicAttackInput.started += ctx => AttackTime();
        /*if (BasicAttackInput.IsPressed())
        {
            StartCoroutine(AttackTime());
        }*/
    }
    
    
    
}