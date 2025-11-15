using UnityEngine;
using Sirenix.OdinInspector;


public class VictimMindStateManager : SerializedMonoBehaviour
{
    //this script controls which state the victim is at, mind controlled or free willed, this script is also for enabling or disabling scripts in order for them to not be interrupted by others

    public bool isControlled;
    
    //controlled state scripts
    VictimStateController _victimStateControllerScript;
    VictimMoveStates _victimMoveStateScript;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
