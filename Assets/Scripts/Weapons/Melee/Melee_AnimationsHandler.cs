using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Melee_AnimationsHandler : SerializedMonoBehaviour
{
    public MeleeWeaponParameters meleeWeaponParameters;

    [HideLabel] [ProgressBar(0, "barSetter", r: 0, g: 1, b: 0, Height = 30)]
    public float AnimationTime;

    public Animator MeleeAnimator;

    public AnimationClip MeleeIdleAnimation;
    public AnimationClip MeleeAttack1Animation;
    public AnimationClip MeleeAttack2Animation;

    [HideInInspector] public float barSetter;


    [Button("Play Idle")]
    public void PlayIdle()
    {
        MeleeAnimator.Play("Melee_Idle");
        barSetter = MeleeAttack1Animation.length;
        AnimationTime = barSetter;
    }

    [Button("Play Attack 1")]
    public void PlayAttack1()
    {
        MeleeAnimator.Play("Melee_Attack1");
        barSetter = MeleeAttack1Animation.length;
        AnimationTime = barSetter;
    }

    [Button("Play Attack 2")]
    public void PlayAttack2()
    {
        MeleeAnimator.Play("Melee_Attack2");
        barSetter = MeleeAttack1Animation.length;
        AnimationTime = barSetter;
    }


    public bool didParry;

    [Button("Play Parry")]
    public void PlayParry()
    {
        MeleeAnimator.Play("Melee_Parry");
        barSetter = MeleeAttack1Animation.length;
        AnimationTime = barSetter;
    }

    public bool canDash;
    [Button("Play Dash Attack")]
    public void PlayDash()
    {
        MeleeAnimator.Play(("Melee_Dash"));
        barSetter = MeleeAttack1Animation.length;
        AnimationTime = barSetter;
    }

    public PlayerInput _inputSystem;
    public InputAction BasicAttackInput;
    public InputAction ParryOrGrenadeInput;
    private float timer;

    private void Awake()
    {
        MeleeAnimator = GetComponent<Animator>();
        _inputSystem = GetComponentInParent<PlayerInput>();
        BasicAttackInput = InputSystem.actions.FindAction("Attack");
        ParryOrGrenadeInput = InputSystem.actions.FindAction("AbilityOne");

        didParry = true;
        canDash = true;
    }

    private void Update()
    {
    }

    public IEnumerator AttackTime()
    {
        // secondStrike = false;
        PlayAttack1();
        timer = barSetter;
        yield return new WaitForSeconds(timer);
        // secondStrike = true;
        if (BasicAttackInput.IsInProgress())
        {
            PlayAttack2();
            timer = barSetter;
        }

        yield return new WaitForSeconds(timer);
        //secondStrike = false;
        // firstStrike = true;
        StartCoroutine(AttackTime());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            StartCoroutine(AttackTime());
            //firstStrike = false;
            //secondStrike = false;
        }
        else
        {
            StopAllCoroutines();
            // firstStrike = true;
            // secondStrike = false;
            PlayIdle();
        }
    }


    public void OnParry(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && didParry)
        {
            didParry = false;
            PlayParryCd();
            StartCoroutine(ParrySequencer());
        }
    }

    public IEnumerator ParrySequencer()
    {
        PlayParry();
        timer = barSetter;
        yield return new WaitForSeconds(timer);
        PlayIdle();
    }

    async Task ParryCd()
    {
        await Task.Delay((int)meleeWeaponParameters.ParryCd * 1000);
    }

    async void PlayParryCd()
    {
        didParry = false;
        await ParryCd();
        didParry = true;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && canDash)
        {
            PlayDash();
        }
    }

    IEnumerator DashCd()
    {
        canDash = false;
        yield return new WaitForSeconds(meleeWeaponParameters.dashAttackCD);
        canDash = true;
    }
}