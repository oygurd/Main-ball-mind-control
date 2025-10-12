using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Analytics;

public class Melee_AnimationsHandler : SerializedMonoBehaviour
{
    public List<AnimationClip> Animations = new List<AnimationClip>();
    public AnimationClip CurrentPlayingAnimation;
    [SerializeField] Animator meleeAnimator;
    public float attacksDuration;

    [SerializeField] int currentAnimationIndex;
    private int animationsCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAnimator = gameObject.GetComponent<Animator>();
        animationsCount = Animations.Count;
        CurrentPlayingAnimation = Animations[0];
    }

    public void PlayAnimationSequence()
    {
        meleeAnimator.Play(CurrentPlayingAnimation.name + 1);
        if (currentAnimationIndex >= animationsCount)
        {
            currentAnimationIndex = 0;
            meleeAnimator.Play(currentAnimationIndex);
        }
    }
    /*public void IdleAnimation()
    {
        meleeAnimator.SetBool("isIdle", true);
        meleeAnimator.SetBool("attack1", false);
        meleeAnimator.SetBool("attack2", false);
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation1()
    {
        meleeAnimator.SetBool("isIdle", false);
        meleeAnimator.SetBool("attack1", true);
        meleeAnimator.SetBool("attack2", false);
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation2()
    {
      // meleeAnimator.SetBool("isIdle", false);
       // meleeAnimator.SetBool("attack1", false);
        meleeAnimator.SetBool("attack2", true);
    }

    public void DashAnimation()
    {
        meleeAnimator.SetFloat("State", 1);
    }*/
}