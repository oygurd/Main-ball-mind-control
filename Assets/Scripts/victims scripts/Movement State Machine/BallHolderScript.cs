using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallHolderScript : SerializedMonoBehaviour
{
    public Transform BallHolderEmpty;
    private BallAttachDettachController _ballController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ball")
        {
            _ballController = other.collider.GetComponent<BallAttachDettachController>();
            _ballController.isHeld = true;
            _ballController.victimHoldingBall = BallHolderEmpty;
        }
    }
}