using Sirenix.OdinInspector;
using UnityEngine;

public class BallController : SerializedMonoBehaviour
{
    [SerializeField] private bool isHeld;
    public Transform victimHoldingBall;

    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D ballRb;

    [SerializeField] CircleCollider2D ballCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachToHost()
    {
        transform.position = Vector2.MoveTowards(transform.position, victimHoldingBall.position,0.1f);
    }

    public void DetachFromHost()
    {
        transform.position = Vector2.MoveTowards(transform.position, ballTransform.position,0.1f); //for now
    }
    
    
}