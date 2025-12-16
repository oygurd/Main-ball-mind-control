using Sirenix.OdinInspector;
using UnityEngine;

public class BallHolderScript : SerializedMonoBehaviour
{
    [Required("Must be the -Ball Holder- empty object")]
    public Transform BallHolderEmpty;

    private BallAttachDettachController _ballController;

    VictimMindStateManager _victimMindStateManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _victimMindStateManager = GetComponent<VictimMindStateManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ball")
        {
            _ballController = other.collider.GetComponent<BallAttachDettachController>();
            _ballController.isHeld = true;
            _ballController.victimHoldingBall = BallHolderEmpty;
            _victimMindStateManager.isControlled = true;
        }
    }
}