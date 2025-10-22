using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Analytics;

public class Melee_AnimationsHandler : SerializedMonoBehaviour
{
    [HideLabel] [ProgressBar(0, "barSetter", r: 0, g: 1, b: 0, Height = 30)]
    public float AnimationTime;
    float barSetter;

    [Button("Play Attack 1")]
    public void PlayAttack1()
    {
        meleeAnimator.Play(currentAnimationIndex);
    }

    public AnimationClip[] Animations;
    public AnimationClip CurrentPlayingAnimation;
    public Animator meleeAnimator;
    public float attacksDuration;

    [SerializeField] int currentAnimationIndex;
    public int animationsCount;


    private void Awake()
    {
        barSetter = Animations.Length;
        currentAnimationIndex = 0;
        CurrentPlayingAnimation = Animations[currentAnimationIndex];
        meleeAnimator = GetComponent<Animator>();
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //meleeAnimator = GetComponent<Animator>();
        //animationsCount = Animations.Count;
      //  CurrentPlayingAnimation = Animations[1];
    }

    /*public void PlayAnimationSequence()
    {
        meleeAnimator.Play(CurrentPlayingAnimation.name + 1);
        if (currentAnimationIndex >= animationsCount)
        {
            currentAnimationIndex = 0;
            meleeAnimator.Play(currentAnimationIndex);
        }
    }*/
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