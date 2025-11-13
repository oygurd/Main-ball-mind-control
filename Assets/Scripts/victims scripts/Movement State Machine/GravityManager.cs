using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class GravityManager : SerializedMonoBehaviour
{
    public static GravityManager instance;
    public int newPriority;
    Rigidbody2D victimRigidbody;
    float gravityScale = 1;
    public bool isGravityLocked;
    private int lockingPriority;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        victimRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetGravityScale(float newScale, int priority)
    {
        if (priority > GetCurrentPriority())
        {
            newPriority = priority;
            gravityScale = newScale;
            victimRigidbody.gravityScale = gravityScale;
        }
        else if (newPriority < GetCurrentPriority())
        {
            priority = newPriority;
        }
    }

    private int GetCurrentPriority()
    {
        return newPriority;
    }

    public void ResetPriority()
    {
        newPriority = 0;
        
    }
}