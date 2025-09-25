using UnityEngine;

public class Melee_AnimationsHandler : MonoBehaviour
{
    [SerializeField] Animator meleeAnimator;
    public float attack1Duration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAnimator = gameObject.GetComponent<Animator>();
    }

    public void IdleAnimationTrue()
    {
        meleeAnimator.SetBool("isIdle", true);
        meleeAnimator.SetBool("attack1", false);
        meleeAnimator.SetBool("attack2", false);
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation1True()
    {
        meleeAnimator.SetBool("isIdle", false);
        meleeAnimator.SetBool("attack1", true);
        meleeAnimator.SetBool("attack2", false);
        attack1Duration = meleeAnimator.GetCurrentAnimatorStateInfo(0).length;
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation2True()
    {
        meleeAnimator.SetBool("isIdle", false);
        meleeAnimator.SetBool("attack1", false);
        meleeAnimator.SetBool("attack2", true);
    }

    public void DashAnimation()
    {
        meleeAnimator.SetFloat("State", 1);
    }
}