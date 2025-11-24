using UnityEngine;
using Sirenix.OdinInspector;


public class VictimMindStateManager : SerializedMonoBehaviour
{
    //this script controls which state the victim is at, mind controlled or free willed, this script is also for enabling or disabling scripts in order for them to not be interrupted by others

    public bool isControlled;

    //controlled state scripts
    [InfoBox("These scripts will be enabled when the ball is held")]
    public VictimStateController _victimStateControllerScript;

    public VictimMoveStates _victimMoveStateScript;
    public VictimAnimationsManager _victimAnimationsScript;

    public Melee_AnimationsHandler _meleeAnimationsScript;

    //ball holder
    [InfoBox("Just the ball holding script")]
    public BallHolderScript _ballHolderScript;

    //free will scripts
    [InfoBox("These scripts are for when the victim is free ")]
    public VictimFreeWill _victimFreeWillScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlled)
        {
            _victimMoveStateScript.enabled = true;
            _victimStateControllerScript.enabled = true;
            _victimAnimationsScript.enabled = true;
            _meleeAnimationsScript.enabled = true;
        }
        else
        {
            _victimMoveStateScript.enabled = false;
            _victimStateControllerScript.enabled = false;
            _victimAnimationsScript.enabled = false;
            _meleeAnimationsScript.enabled = false;
        }
    }
}