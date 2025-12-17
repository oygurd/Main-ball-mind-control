using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class BallAttachDettachController : SerializedMonoBehaviour
{
    //public static BallController BallControllerInstance;
    public bool isHeld;
    public Transform victimHoldingBall;
    
    [SerializeField] GameObject BallGameObject;
    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D ballRb;

    [SerializeField] CircleCollider2D ballCollider;
    
    
    //temp UI
    public Image isControlledChanger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ballCollider = GetComponent<CircleCollider2D>();
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            AttachToHost();
            ballCollider.enabled = false;
            ballRb.simulated = false;
        }
        else
        {
            DetachFromHost();
        }
        
        
        
        //temp UI
        if (isHeld)
        {
            isControlledChanger.color = Color.green;
        }
        else
        {
            isControlledChanger.color = Color.red;
        }
    }

    public void AttachToHost()
    {
        transform.position = Vector2.MoveTowards(transform.position, victimHoldingBall.position, 1f);
        transform.SetParent(victimHoldingBall);
    }

    public void DetachFromHost()
    {
        transform.position = transform.position;
        ballRb.simulated = true;

        
    }
    
    //temporary UI stuff
    
    
    
}
