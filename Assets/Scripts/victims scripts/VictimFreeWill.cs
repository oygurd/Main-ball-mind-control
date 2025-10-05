using UnityEngine;

public class VictimFreeWill : MonoBehaviour
{
    public enum FreeWillMovementStates
    {
        Idle,
        Moving,
        Jumping ,
        Dead
    }
    
    public FreeWillMovementStates freeWillMovementState;

    public enum FreeWillMoodStates
    {
        Idle,
        Roaming,
        Intrigued,
        Damaged,
    }
    public FreeWillMoodStates freeWillMoodState;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetDetector();
    }

    public void TargetDetector()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.2f);
    }
}
