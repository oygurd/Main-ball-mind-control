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
    }
}