using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeClassVictimInputManagement : MonoBehaviour
{
    public bool enableGizmo;
    private InputAction AttackInput;
    private InputAction dashAtackInput;

    [SerializeField] RaycastHit2D attackRaycast;
    [SerializeField] LayerMask layerMask;

    ControlledMechanicVictim victimScript;

    public bool canAttack;
    public bool canDash;

    //player
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRb;

    //animations
    //[SerializeField] Melee_AnimationsHandler animationHandler;
    [SerializeField] bool canIdle;
    
    //New animations management
    [SerializeField] Melee_AnimationsHandler animationHandler;
    

    public float atckTime = 0;

    //public ClassManagerConfig ClassManager;
    [SerializeField] MeleeWeaponParameters melee;

    //prefab instantiating
    [SerializeField] GameObject weapon;

    public enum MeleeActions
    {
        Idle,
        Attack,
        attack2,
        DashAtack
    }

    public MeleeActions actions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackInput = InputSystem.actions.FindAction("Attack");
        dashAtackInput = InputSystem.actions.FindAction("Dash Attack");
        canAttack = true;
        canDash = true;
        canIdle = true;

        playerRb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (actions)
        {
            case MeleeActions.Attack:
                Debug.Log("Currently attacking");
                break;
            case MeleeActions.DashAtack:
                Debug.Log("Currently Dashing");
                break;
        }

        // attackRaycast = Physics2D.Raycast(transform.position, transform.right, melee.range, layerMask );
        UpdateStates();
    }

    public void UpdateStates()
    {
        if (AttackInput.IsPressed() == false && dashAtackInput.IsPressed() == false)
        {
            if (canIdle)
            {
                actions = MeleeActions.Idle;
                animationHandler.IdleAnimationTrue();
                enableGizmo = false;
            }
        }
        
        else if (AttackInput.IsPressed() && canAttack)
        {
            Attack1();
            canIdle = false;
            actions = MeleeActions.Attack;
            StartCoroutine(Attack1AnimationDuration());
        }
        else if (dashAtackInput.IsPressed() && canDash)
        {
            DashAtack();
            actions = MeleeActions.DashAtack;
        }
        
        if (AttackInput.IsPressed() == false)
        {
            atckTime = 0;
        }

        
    }

    public void Attack1()
    {
        enableGizmo = true;
        canAttack = false;
        StartCoroutine(AttackCD());
        
        //animation
        animationHandler.AttackAnimation1True();

        //check for raycasts
        attackRaycast = Physics2D.Raycast(transform.position, transform.forward, melee.range, layerMask);
        if (attackRaycast.collider != null)
        {
            Debug.Log("Hitting" + attackRaycast.collider.name);
        }
    }

    public IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(melee.attackCD);
        canAttack = true;
        canIdle = true;
    }


    public IEnumerator Attack1AnimationDuration()
    {
        yield return new WaitForSeconds(animationHandler.attack1Duration);
        atckTime = 1;
        
        if (AttackInput.IsInProgress())
        {
            Attack2();
            StartCoroutine(Attack2AnimationDuration());
        }
    }

    public void Attack2()
    {
        animationHandler.AttackAnimation2True();
    }

    public IEnumerator Attack2AnimationDuration() 
    {
        yield return new WaitForSeconds(animationHandler.attack2Duration);
        animationHandler.IdleAnimationTrue();
        canIdle = true;
        canAttack = true;
    }


    public void DashAtack()
    {
        playerTransform.position +=
            new Vector3(playerTransform.localScale.x * melee.DashStrengthX, playerTransform.position.y * melee.DashStrengthY);

        canDash = false;

        StartCoroutine(DashAttackCD());
    }

    public IEnumerator DashAttackCD()
    {
        yield return new WaitForSeconds(melee.dashAttackCD);
        canDash = true;
        animationHandler.IdleAnimationTrue();
        canAttack = true;
    }


    private void OnDrawGizmos()
    {
        if (AttackInput.IsPressed() && enableGizmo)
        {
            Gizmos.DrawRay(transform.position, new Vector3(transform.lossyScale.x, 0, 0) * melee.range);
        }
    }

    private void OnEnable()
    {
        //weapon
        weapon = Instantiate(melee.prefab, transform.position, transform.rotation, transform);
        animationHandler = gameObject.GetComponentInChildren<Melee_AnimationsHandler>();
    }
}