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
    
    //animations
    [SerializeField] private Animator animations;
        
    
    

    //public ClassManagerConfig ClassManager;
    [SerializeField] MeleeWeaponParameters melee;

    public enum MeleeActions
    {
        Idle,
        Attack,
        DashAtack
    }

    private MeleeActions actions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackInput = InputSystem.actions.FindAction("Attack");
        dashAtackInput = InputSystem.actions.FindAction("Dash Attack");
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (actions)
        {
            case MeleeActions.Attack:
                Debug.Log("Currently attacking");
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
    }


    
    
    
    
    
    
    
    private void OnDrawGizmos()
    {
        if (AttackInput.IsPressed() && enableGizmo)
        {
            Gizmos.DrawRay(transform.position, transform.right * melee.range);
        }
    }

    
    

   
}