using UnityEngine;

public class ControlledMechanicVictim : MonoBehaviour
{ 
    [SerializeField] private Rigidbody2D victimRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victimRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    
}
