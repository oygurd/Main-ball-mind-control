using UnityEngine;

public class ControlledMechanicVictim : MonoBehaviour
{ 
    //in this script I want the victim to move randomly (with a bit of intention to go to the ball, and when touching the ball, movement is possible
    
    
    [SerializeField] public Collider2D victimCollider;

    public Transform ballHolderInVictim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victimCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    
}
