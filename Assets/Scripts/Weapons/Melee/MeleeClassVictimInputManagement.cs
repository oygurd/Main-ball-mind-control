using UnityEngine;
using UnityEngine.InputSystem;
public class MeleeClassVictimInputManagement : MonoBehaviour
{
    private InputAction AttackInput;
    private InputAction dashAtackInput;
    public enum MeleeActions
    {
        Attack,
        DashAtack
    }
    private MeleeActions actions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackInput = InputSystem.actions.FindAction("Attack");
        dashAtackInput = InputSystem.actions.FindAction("Dash Attack");
    }

    // Update is called once per frame
    void Update()
    {
        switch (actions)
        {
            case MeleeActions.Attack:
                break;
        }
        
    }

    public void UpdateStates()
    {
        
    }
    
    public void Attack()
    {
        if (AttackInput.IsInProgress())
        {
            //play the animation
            
            
            //check for raycasts
            
        }
    }

    public void DashAtack()
    {
        
    }
}
