using UnityEngine;

public class Melee_AnimationsHandler : MonoBehaviour
{
    [SerializeField] Animator meleeAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAnimator = GetComponent<Animator>();
    }

    public void IdleAnimationTrue()
    {
        meleeAnimator.SetBool(1, true);
        meleeAnimator.SetBool(2, false);
        meleeAnimator.SetBool(3, false);
    }

    public void IdleAnimationFalse()
    {
        meleeAnimator.SetBool(1, false);
        meleeAnimator.SetBool(2, true);
        meleeAnimator.SetBool(3, true);
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation1True()
    {
        meleeAnimator.SetBool(1, false);
        meleeAnimator.SetBool(2, true);
        meleeAnimator.SetBool(3, false);
    }

    public void AttackAnimation1False()
    {
        meleeAnimator.SetBool(2, false);
    }
//--------------------------------------------------------------------------------------------//

    public void AttackAnimation2True()
    {
        meleeAnimator.SetBool(1, false);
        meleeAnimator.SetBool(2, false);
        meleeAnimator.SetBool(3, true);
    }

    public void AttackAnimation2False()
    {
        meleeAnimator.SetBool(3, false);
    }


    public void DashAnimation()
    {
        meleeAnimator.SetFloat("State", 1);
    }
}