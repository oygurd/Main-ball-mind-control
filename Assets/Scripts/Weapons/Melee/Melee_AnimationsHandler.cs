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

    // public Animator meleeAnimator;
    public float attacksDuration;

    private void Awake()
    {
        MeleeAnimator = GetComponent<Animator>();
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