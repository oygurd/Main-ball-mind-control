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
    [SerializeField] private Animator animations;


    //public ClassManagerConfig ClassManager;
    [SerializeField] MeleeWeaponParameters melee;

    //prefab
    private GameObject weapon;

    public enum MeleeActions
    {
        Idle,
        Attack,
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

        playerRb = GetComponentInParent<Rigidbody2D>();
        playerTransform = GetComponentInParent<Transform>();
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
            actions = MeleeActions.Idle;
            enableGizmo = false;
        }
        else if (AttackInput.IsPressed() && canAttack)
        {
            Attack();
            actions = MeleeActions.Attack;
        }
        else if (dashAtackInput.IsPressed() && canDash)
        {
            DashAtack();
            actions = MeleeActions.DashAtack;
        }
    }

    public void Attack()
    {
        enableGizmo = true;
        canAttack = false;
        StartCoroutine(AttackCD());
        //play the animation

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
    }

    public void DashAtack()
    {
        playerRb.gravityScale = 0;
        canDash = false;
        playerRb.AddForceX(playerTransform.lossyScale.x * melee.DashStrengthX, ForceMode2D.Impulse);
        playerRb.AddForceY(melee.DashStrengthY,ForceMode2D.Impulse);
        playerRb.gravityScale = 1;

        StartCoroutine(DashAttackCD());
    }

    public IEnumerator DashAttackCD()
    {
        yield return new WaitForSeconds(melee.dashAttackCD);
        canDash = true;
    }


    private void OnDrawGizmos()
    {
        if (AttackInput.IsPressed() && enableGizmo)
        {
            Gizmos.DrawRay(transform.position, transform.right * melee.range);
        }
    }

    private void OnEnable()
    {
        //weapon
        weapon = Instantiate(melee.prefab, transform.position, transform.rotation, transform);
    }
}