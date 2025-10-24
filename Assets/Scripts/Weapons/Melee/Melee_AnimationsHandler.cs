using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Analytics;

public class Melee_AnimationsHandler : SerializedMonoBehaviour
{
    [HideLabel] [ProgressBar(0, "barSetter", r: 0, g: 1, b: 0, Height = 30)]
    public float AnimationTime;

    public Animator MeleeAnimator;

    public AnimationClip MeleeIdleAnimation;
    public AnimationClip MeleeAttack1Animation;
    public AnimationClip MeleeAttack2Animation;

    float barSetter;

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

    private void Awake()
    {
        MeleeAnimator = GetComponent<Animator>();
    }

    public IEnumerator AttacksSequencer()
    {
        return null;
    }
    
}