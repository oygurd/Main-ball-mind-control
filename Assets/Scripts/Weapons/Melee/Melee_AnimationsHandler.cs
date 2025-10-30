using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class Melee_AnimationsHandler : SerializedMonoBehaviour
{
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

    public PlayerInput _inputSystem;
    public InputAction BasicAttackInput;
    public InputAction ParryOrGrenadeInput;
    private float time;

    private void Awake()
    {
        MeleeAnimator = GetComponent<Animator>();
        _inputSystem = GetComponentInParent<PlayerInput>();
        BasicAttackInput = InputSystem.actions.FindAction("Attack");
        ParryOrGrenadeInput = InputSystem.actions.FindAction("Parry/Grenade");
    }

    public IEnumerator AttackTime()
    {
        // secondStrike = false;
        PlayAttack1();
        time = barSetter;
        yield return new WaitForSeconds(time);
        // secondStrike = true;
        if (BasicAttackInput.IsInProgress())
        {
            PlayAttack2();
            time = barSetter;
        }

        yield return new WaitForSeconds(time);
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
    public IEnumerator AttacksSequencer()
    {
        return null;
    }
}